using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TelegramClone.Data;
using TelegramClone.Models;

namespace TelegramClone.Services
{
    public class UserService
    {
        private readonly ApplicationContext _context; // заменить все контексты на репозитории
        public UserService(ApplicationContext context)
        {
            _context = context;
        }
        public User GetCurrentUser(HttpContext httpContext)
        {
            var identity = httpContext.User.Identity as ClaimsIdentity;

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
