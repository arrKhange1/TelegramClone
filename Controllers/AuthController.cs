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

namespace TelegramClone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;
        

        public AuthController(ApplicationContext context, IConfiguration config,
            IRoleRepository roleRepository, IUserRepository userRepository)
        {
            _config = config;
            _roleRepository = roleRepository;
            _userRepository = userRepository;
        }

        [AllowAnonymous]
        [HttpPost ("login")]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            var user = Authenticate(userLogin);
            if (user != null)
            {
                var token = Generate(user);
                return Ok(new {
                    token = token,
                    userName = user.UserName, 
                    role = _roleRepository.GetRoleById(user).RoleName });
            }

            return NotFound("User not found");
        }

        [AllowAnonymous]
        [HttpPost ("register")]
        public async Task<IActionResult> Register([FromBody] UserLogin userLogin)
        {
            var user = _userRepository.GetUserByUsername(userLogin);
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

                var token = Generate(createdUser);
                return Ok(new
                {
                    token = token,
                    userName = createdUser.UserName,
                    role = "user"
                });
            }

            return BadRequest("User already exists");
        }

        private string Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userRole = _roleRepository.GetRoleById(user);

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
            var authenticatedUser = _userRepository.GetUserByUsernameAndPassword(userLogin);
            if (authenticatedUser != null)
                return authenticatedUser;
            return null;
        }
    }
}
