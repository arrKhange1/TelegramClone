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
using TelegramClone.Models.RequestDTO;

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
                var userName = userClaims.FirstOrDefault(claim => claim.Type == ClaimTypes.Name).Value;
                var roleId = _roleRepository.GetRoleByName(roleName).RoleId;
                return new User(userName, "", roleId);
            }

            return null;
        }

        public User GetUserByUserName (string userName) {
            return _userRepository.GetUserByUsername(userName);
        }
         public User GetUserByUserLoginDTO (UserLoginRequestDTO userLogin) {
            return _userRepository.GetUserByUserLoginDTO(userLogin);
        }

        public User GetUserById(Guid userId)
        {
            return _userRepository.GetUserById(userId);
        }

        public async Task<User> CreateUserFromDTO(UserLoginRequestDTO userLogin)
        {
            var userRole = _roleRepository.GetRoleByName("user");
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(userLogin.Password);
            var user = new User(userLogin.UserName, hashedPassword, userRole.RoleId);
            var createdUser = await _userRepository.AddUser(user);
            return createdUser;
        }

        public User Authenticate(UserLoginRequestDTO userLogin)
        {
            var databaseUser = _userRepository.GetUserByUserLoginDTO(userLogin);
            if (databaseUser == null)
                return null;
            if (_userRepository.VerifyUserPassword(userLogin, databaseUser))
                return databaseUser;
            return null;

           
        }
    }
}
