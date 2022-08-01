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
using TelegramClone.Models;
using TelegramClone.Models.DTO;

namespace TelegramClone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ApplicationContext _context;

        public AuthController(ApplicationContext context, IConfiguration config)
        {
            _config = config;
            _context = context;

        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            var user = Authenticate(userLogin);
            if (user != null)
            {
                var token = Generate(user);
                return Ok(new {token = token, userName = user.UserName, role = _context.Roles.FirstOrDefault(role => role.RoleId == user.RoleId).RoleName });
            }

            return NotFound("User not found");
        }

        private string Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userRole = _context.Roles.FirstOrDefault(role => role.RoleId == user.RoleId);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Role, userRole.RoleName)

            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User Authenticate(UserLogin userLogin)
        {
            var authenticatedUser = _context.Users.FirstOrDefault(user => user.UserName == userLogin.UserName &&
                user.Password == userLogin.Password);
            if (authenticatedUser != null)
                return authenticatedUser;
            return null; // на продакшене так не аутентифицировать
        }
    }
}
