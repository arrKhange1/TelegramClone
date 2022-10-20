using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
			var token = _context.RefreshTokens.FirstOrDefault(tok => tok.UserId == user.UserId);
			if (token == null) // prevent concurrent operation
            {
				var added = await _context.RefreshTokens.AddAsync(user);
				Debug.WriteLine($"f: {added.Entity.Token}");
				await _context.SaveChangesAsync();
				return added.Entity;
			}
			Debug.WriteLine($"s: {token.Token}");
			return token;
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
				_context.Entry(userToken).State = EntityState.Deleted;

				bool saveFailed;
				do
				{
					saveFailed = false;
					try
					{
						await _context.SaveChangesAsync();
					}
					catch (DbUpdateConcurrencyException ex)
					{
						saveFailed = true;
						var entry = ex.Entries.Single();
						//The MSDN examples use Single so I think there will be only one
						//but if you prefer - do it for all entries
						//foreach(var entry in ex.Entries)
						//{
						if (entry.State == EntityState.Deleted)
							//When EF deletes an item its state is set to Detached
							//http://msdn.microsoft.com/en-us/data/jj592676.aspx
							entry.State = EntityState.Detached;
						else
							entry.OriginalValues.SetValues(entry.GetDatabaseValues());
						//throw; //You may prefer not to resolve when updating
						//}
					}
				} while (saveFailed);
			}
			return userToken;
		}

		public RefreshToken GetSavedRefreshTokens(Guid userId, string refreshToken)
		{
			//Debug.WriteLine(_context.RefreshTokens.FirstOrDefault(u => u.UserId == userId && u.Token == refreshToken && u.isActive == true).Token);
			return _context.RefreshTokens.FirstOrDefault(u => u.UserId == userId && u.Token == refreshToken && u.isActive == true);
		}
	}
}
