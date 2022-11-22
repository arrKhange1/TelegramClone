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
        public ChatUser GetChatUserByChatIdAndUserId(Guid chatId, Guid userId);
        public void UpdateUnreadMsgsOfChatMembers(List<ChatUser> chatMembers);
        public List<ChatUser> GetChatMembers(Guid chatId);
    }
}
