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
using TelegramClone.Services;

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
       [AllowAnonymous]
       public IActionResult Public()
        {
            return Ok("Hi, Public");
        }

        [HttpGet("Admins")]
        [Authorize(Roles = "admin")]
        public IActionResult Admin()
        {
            var user = new UserService(_context).GetCurrentUser(HttpContext);
            return Ok($"Hi, {user.UserName}, {user.RoleId}");
        }

        [HttpGet("Users")]
        [Authorize(Roles = "user")]
        public IActionResult Users()
        {
            var user = new UserService(_context).GetCurrentUser(HttpContext);


            return Ok($"Hi, {user.UserName}, {user.RoleId}");
        }

        [HttpGet("Authorized")]
        [Authorize]
        public IActionResult Authorized()
        {
            var user = new UserService(_context).GetCurrentUser(HttpContext);


            return Ok($"Hi, {user.UserName}, {user.RoleId}");
        }

        
    }
}
