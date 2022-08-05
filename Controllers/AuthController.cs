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
        private readonly JWTService _jwtService;
        private readonly RefreshTokenService _refreshTokenService;
        private readonly RoleService _roleService;
        private readonly UserService _userService;

        public AuthController(JWTService jwtService,
            RefreshTokenService refreshTokenService,
            RoleService roleService,
            UserService userService)
        {
            _jwtService = jwtService;
            _refreshTokenService = refreshTokenService;
            _roleService = roleService;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("refresh")]
        public async Task<IActionResult> Refresh([FromBody] Tokens token)
        {
            var user = _jwtService.GetUserFromToken(token.AccessToken);

            var savedRefreshToken = _refreshTokenService.GetSavedRefreshToken(user, token.RefreshToken);

            if (savedRefreshToken == null)
                return Unauthorized("Invalid attempt!");

            if (savedRefreshToken.IsExpired)
                return Unauthorized("Refresh token expired");

            string newToken = await _refreshTokenService.RefreshToken(user);

            return Ok(new Tokens { 
                AccessToken = _jwtService.GenerateAccessToken(user),
                RefreshToken = newToken
            });
        }

        [AllowAnonymous]
        [HttpPost ("login")]
        public async Task<IActionResult> Login([FromBody] UserLogin userLogin)
        {
            var user = _userService.Authenticate(userLogin);
            if (user != null)
            {
                var accessToken = _jwtService.GenerateAccessToken(user);
                
                string newRefreshToken = await _refreshTokenService.RefreshToken(user);

                return Ok(new {
                    accessToken = accessToken,
                    refreshToken = newRefreshToken,
                    userName = user.UserName, 
                    role = _roleService.GetRoleById(user).RoleName });
            }

            return NotFound("User not found");
        }

        [AllowAnonymous]
        [HttpPost ("register")]
        public async Task<IActionResult> Register([FromBody] UserLogin userLogin)
        {
            var user = _userService.GetUserByUserName(userLogin.UserName);
            if (user == null)
            {
                var createdUser = await _userService.CreateUserFromDTO(userLogin);

                return Ok(new
                {
                    accessToken = _jwtService.GenerateAccessToken(createdUser),
                    refreshToken = await _refreshTokenService.AddNewRefreshToken(createdUser),
                    userName = createdUser.UserName,
                    role = "user"
                });
            }

            return BadRequest("User already exists");
        }

        

   
    }
}
