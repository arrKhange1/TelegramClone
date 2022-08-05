using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramClone.Data.Interfaces;
using TelegramClone.Models;

namespace TelegramClone.Data.Implementations
{
    public class UserRefreshTokensMSSQLRepository : IUserRefreshTokensRepository
    {
		private readonly ApplicationContext _context;

		public UserRefreshTokensMSSQLRepository(ApplicationContext context)
		{
			_context = context;
		}

		public async Task<RefreshToken> AddUserRefreshTokens(RefreshToken user)
		{
			await _context.RefreshTokens.AddAsync(user);
			await _context.SaveChangesAsync();
			return user;
		}

        public async Task<RefreshToken> DeleteAllUserRefreshTokens(Guid userId)
        {
			var userToken = _context.RefreshTokens.FirstOrDefault(u => u.UserId == userId);
			if (userToken != null)
            {
				_context.RefreshTokens.Remove(userToken);
				await _context.SaveChangesAsync();
			}
			return userToken;


		}

		public async Task<RefreshToken> DeleteUserRefreshTokens(Guid userId) 
		{
			var userToken = _context.RefreshTokens.FirstOrDefault(u => u.UserId == userId);
			if (userToken != null)
			{
				_context.RefreshTokens.Remove(userToken);
				await _context.SaveChangesAsync();
			}
			return userToken;
		}

		public RefreshToken GetSavedRefreshTokens(Guid userId, string refreshToken)
		{
			return _context.RefreshTokens.FirstOrDefault(u => u.UserId == userId && u.Token == refreshToken && u.isActive == true);
		}
	}
}
