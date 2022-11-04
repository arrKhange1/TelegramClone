using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TelegramClone.Data;
using TelegramClone.Data.Interfaces;
using TelegramClone.Models;
using TelegramClone.Models.DTO;

namespace TelegramClone.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        public UserService(IUserRepository userRepository,
            IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
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
                    UserName = userClaims.FirstOrDefault(claim => claim.Type == ClaimTypes.Name).Value,
                    RoleId = _roleRepository.GetRoleByName(roleName).RoleId

                };
            }

            return null;
        }

        public User GetUserByUserName (string userName) {
            return _userRepository.GetUserByUsername(userName);
        }

        public User GetUserById(Guid userId)
        {
            return _userRepository.GetUserById(userId);
        }

        public async Task<User> CreateUserFromDTO(UserLogin userLogin)
        {
            var userRole = _roleRepository.GetRoleByName("user");
            var user = new User
            {
                UserName = userLogin.UserName,
                Password = userLogin.Password,
                RoleId = userRole.RoleId,
            };
            var createdUser = await _userRepository.AddUser(user);

            return createdUser;
        }

        public User GetUserByUsernameAndPassword(UserLogin userLogin)
        {
            return _userRepository.GetUserByUsernameAndPassword(userLogin);
        }

        public User Authenticate(UserLogin userLogin)
        {
            var authenticatedUser = _userRepository.GetUserByUsernameAndPassword(userLogin);
            if (authenticatedUser != null)
                return authenticatedUser;
            return null;
        }
    }
}
