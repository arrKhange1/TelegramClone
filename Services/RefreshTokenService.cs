using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using TelegramClone.Data.Interfaces;
using TelegramClone.Models;

namespace TelegramClone.Services
{
    public class RefreshTokenService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserRefreshTokensRepository _refreshTokenRepository;
        private readonly IRoleRepository _roleRepository;
        public RefreshTokenService(IUserRepository userRepository,
           IUserRefreshTokensRepository refreshTokenRepository,
           IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _refreshTokenRepository = refreshTokenRepository;
            _roleRepository = roleRepository;
        }

        public void AddRefreshTokenInCookie(HttpContext httpContext, string token)
        {
            httpContext.Response.Cookies.Append("refresh", token);
            
        }

        public string GetRefreshTokenFromCookie(HttpContext httpContext)
        {
            return httpContext.Request.Cookies["refresh"];
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
        public async Task<string> RefreshToken(User user)
        {
            var newRefreshToken = GenerateRefreshToken();

            RefreshToken newUserToken = new RefreshToken
            {
                Token = newRefreshToken,
                UserId = user.UserId,
                ExpireDate = DateTime.Now.AddMinutes(0.5)
            };

            await _refreshTokenRepository.DeleteUserRefreshTokens(user.UserId);
            await _refreshTokenRepository.AddUserRefreshTokens(newUserToken);

            return newRefreshToken;
        }

        public async Task<string> AddNewRefreshToken(User user)
        {
            var refreshToken = GenerateRefreshToken();

            RefreshToken userToken = new RefreshToken
            {
                Token = refreshToken,
                UserId = user.UserId,
                ExpireDate = DateTime.Now.AddMinutes(0.5)
            };

            await _refreshTokenRepository.AddUserRefreshTokens(userToken);

            return refreshToken;
        }

        public RefreshToken GetSavedRefreshToken(User user, string token)
        {
            return _refreshTokenRepository.GetSavedRefreshTokens(user.UserId, token);
        }
    }
}
