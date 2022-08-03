using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TelegramClone.Data;
using TelegramClone.Data.Interfaces;
using TelegramClone.Models;
using TelegramClone.Models.DTO;
using TelegramClone.Services;

namespace TelegramClone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserRefreshTokensRepository _userRefreshTokensRepository;
        private readonly JWTService _jwtService;

        public AuthController(ApplicationContext context, IConfiguration config,
            IRoleRepository roleRepository, IUserRepository userRepository, IUserRefreshTokensRepository userRefreshTokensRepository,
            JWTService jwtService)
        {
            _config = config;
            _roleRepository = roleRepository;
            _userRepository = userRepository;
            _userRefreshTokensRepository = userRefreshTokensRepository;
            _jwtService = jwtService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("refresh")]
        public async Task<IActionResult> Refresh([FromBody] Tokens token)
        {
            var principal = _jwtService.GetPrincipalFromExpiredToken(token.AccessToken);
            var userName = principal.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier).Value;

            var user = _userRepository.GetUserByUsername(userName);

            //retrieve the saved refresh token from database
            var savedRefreshToken = _userRefreshTokensRepository.GetSavedRefreshTokens(user.UserId, token.RefreshToken);

            if (savedRefreshToken == null)
            {
                return Unauthorized("Invalid attempt!");
            }

            var newRefreshToken = _jwtService.GenerateRefreshToken();

            if (newRefreshToken == null)
            {
                return Unauthorized("Invalid attempt!");
            }

            // saving refresh token to the db
            RefreshToken newUserToken = new RefreshToken
            {
                Token = newRefreshToken,
                UserId = user.UserId
            };

            await _userRefreshTokensRepository.DeleteUserRefreshTokens(user.UserId, token.RefreshToken);
            await _userRefreshTokensRepository.AddUserRefreshTokens(newUserToken);

            return Ok(new Tokens { 
                AccessToken = _jwtService.GenerateAccessToken(user),
                RefreshToken = newRefreshToken
            });
        }

        [AllowAnonymous]
        [HttpPost ("login")]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            var user = Authenticate(userLogin);
            if (user != null)
            {
                var accessToken = _jwtService.GenerateAccessToken(user);
                var refreshToken = _jwtService.GenerateRefreshToken();

                RefreshToken userToken = new RefreshToken
                {
                    Token = refreshToken,
                    UserId = user.UserId
                };

                _userRefreshTokensRepository.AddUserRefreshTokens(userToken);

                return Ok(new {
                    accessToken = accessToken,
                    refreshToken = refreshToken,
                    userName = user.UserName, 
                    role = _roleRepository.GetRoleById(user).RoleName });
            }

            return NotFound("User not found");
        }

        [AllowAnonymous]
        [HttpPost ("register")]
        public async Task<IActionResult> Register([FromBody] UserLogin userLogin)
        {
            var user = _userRepository.GetUserByUsername(userLogin.UserName);
            if (user == null)
            {
                Guid userRole = _roleRepository.GetRoleByName("user").RoleId;
                var createdUser = new User 
                {
                    UserName = userLogin.UserName,
                    Password = userLogin.Password,
                    RoleId = userRole,
                };
                await _userRepository.AddUser(createdUser);

                var accessToken = _jwtService.GenerateAccessToken(createdUser);
                var refreshToken = _jwtService.GenerateRefreshToken();

                RefreshToken userToken = new RefreshToken
                {
                    Token = refreshToken,
                    UserId = createdUser.UserId
                };

                await _userRefreshTokensRepository.AddUserRefreshTokens(userToken);

                return Ok(new
                {
                    ccessToken = accessToken,
                    refreshToken = refreshToken,
                    userName = createdUser.UserName,
                    role = "user"
                });
            }

            return BadRequest("User already exists");
        }

        

        private User Authenticate(UserLogin userLogin)
        {
            var authenticatedUser = _userRepository.GetUserByUsernameAndPassword(userLogin);
            if (authenticatedUser != null)
                return authenticatedUser;
            return null;
        }
    }
}
