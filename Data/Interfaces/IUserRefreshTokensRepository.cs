using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramClone.Models;

namespace TelegramClone.Data.Interfaces
{
    public interface IUserRefreshTokensRepository
    {
        public Task<RefreshToken> AddUserRefreshTokens(RefreshToken user);
        public Task<RefreshToken> DeleteUserRefreshTokens(Guid userId, string refreshToken);
        public Task<RefreshToken> DeleteAllUserRefreshTokens(Guid userId);
        public RefreshToken GetSavedRefreshTokens(Guid userId, string refreshToken);
    }
}
