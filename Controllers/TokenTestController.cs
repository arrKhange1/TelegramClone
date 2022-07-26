using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TelegramClone.Data;
using TelegramClone.Models;

namespace TelegramClone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenTestController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public TokenTestController(ApplicationContext context)
        {
            _context = context;
        }

       [HttpGet("Public")]
       public IActionResult Public()
        {
            return Ok("Hi, Public");
        }

        [HttpGet("Admins")]
        [Authorize(Roles = "admin")]
        public IActionResult Admin()
        {
            var user = GetCurrentUser();
            return Ok($"Hi, {user.UserName}, {user.RoleId}");
        }

        [HttpGet("Users")]
        [Authorize(Roles = "user")]
        public IActionResult Users()
        {
            var user = GetCurrentUser();
            return Ok($"Hi, {user.UserName}, {user.RoleId}");
        }

        private User GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;
                var roleName = userClaims.FirstOrDefault(claim => claim.Type == ClaimTypes.Role).Value;

                return new User
                {
                    UserName = userClaims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier).Value,
                    RoleId = _context.Roles.FirstOrDefault(role => role.RoleName == roleName).RoleId

                };
            }

            return null;
        }
    }
}
