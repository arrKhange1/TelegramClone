using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public async Task<IActionResult> Refresh()
        {
            var expiredAccessToken = _jwtService.GetAccessTokenFromCookie(HttpContext);
            if (string.IsNullOrEmpty(expiredAccessToken))
            {
                Debug.WriteLine("first");
                return Unauthorized("Invalid attempt!");
            }

            var user = _jwtService.GetUserFromToken(expiredAccessToken);

            var savedRefreshToken = _refreshTokenService.GetSavedRefreshToken(user, _refreshTokenService.GetRefreshTokenFromCookie(HttpContext));

            if (savedRefreshToken == null)
            {
                Debug.WriteLine("second");
                return Unauthorized("Invalid attempt!");
            }

            if (savedRefreshToken.IsExpired)
            {
                Debug.WriteLine("third");
                return Unauthorized("Refresh token expired");
            }

            string refreshToken = await _refreshTokenService.RefreshToken(user);
            string accessToken = _jwtService.GenerateAccessToken(user);

            _refreshTokenService.AddRefreshTokenInCookie(HttpContext, refreshToken);
            _jwtService.AddAccessTokenInCookie(HttpContext, accessToken);

            return Ok();
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

                _jwtService.AddAccessTokenInCookie(HttpContext, accessToken);
                _refreshTokenService.AddRefreshTokenInCookie(HttpContext, newRefreshToken);

                return Ok(new {
                    userId = user.UserId,
                    userName = user.UserName, 
                    role = _roleService.GetRoleById(user).RoleName });
            }

            return NotFound("User not found");
        }

        [AllowAnonymous]
        [HttpPost ("register")]
        public async Task<IActionResult> Register([FromBody] UserRegister userLogin)
        {
            var user = _userService.GetUserByUserName(userLogin.UserName);
            if (user == null)
            {
                var createdUser = await _userService.CreateUserFromDTO(userLogin);

                var accessToken = _jwtService.GenerateAccessToken(createdUser);
                var refreshToken = await _refreshTokenService.AddNewRefreshToken(createdUser);

                _jwtService.AddAccessTokenInCookie(HttpContext, accessToken);
                _refreshTokenService.AddRefreshTokenInCookie(HttpContext, refreshToken);

                return Ok(new
                {
                    userId = createdUser.UserId,
                    userName = createdUser.UserName,
                    role = "user"
                });
            }

            return BadRequest("User already exists");
        }

        [AllowAnonymous]
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete("access");
            HttpContext.Response.Cookies.Delete("refresh");

            return Ok();
        }



    }
}
