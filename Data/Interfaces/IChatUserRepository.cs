using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramClone.Models;

namespace TelegramClone.Data.Interfaces
{
    public interface IChatUserRepository
    {
        public Task<bool> AddUsersToChat(List<ChatUser> members);
    }
}
