using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramClone.Data.Interfaces;
using TelegramClone.Models;

namespace TelegramClone.Data.Implementations
{
    public class ChatUserMSSQLRepository : IChatUserRepository
    {
        ApplicationContext _context;

        public ChatUserMSSQLRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<bool> AddUsersToChat(List<ChatUser> members)
        {
            try
            {
                await _context.ChatUsers.AddRangeAsync(members);
                _context.SaveChanges();
                return true;
            }
            catch(DbUpdateException ex)
            {
                return false;
            }
        }
    }
}
