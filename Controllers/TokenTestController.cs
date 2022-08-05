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
        private readonly UserService _userService;
        public TokenTestController(UserService userService)
        {
            _userService = userService;
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
            var user = _userService.GetCurrentUser(HttpContext);
            return Ok($"Hi, {user.UserName}, {user.RoleId}");
        }

        [HttpGet("Users")]
        [Authorize(Roles = "user")]
        public IActionResult Users()
        {
            var user = _userService.GetCurrentUser(HttpContext);


            return Ok($"Hi, {user.UserName}, {user.RoleId}");
        }

        [HttpGet("Authorized")]
        [Authorize]
        public IActionResult Authorized()
        {
            var user = _userService.GetCurrentUser(HttpContext);


            return Ok($"Hi, {user.UserName}, {user.RoleId}");
        }

        
    }
}
