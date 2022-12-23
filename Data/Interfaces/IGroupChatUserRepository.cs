using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramClone.Models;

namespace TelegramClone.Data.Interfaces
{
    public interface IGroupChatUserRepository
    {
        public Task<bool> AddUsersToGroupChat(List<GroupChatUser> members);
        public GroupChatUser GetGroupChatUserByChatIdAndUserId(Guid chatId, Guid userId);
        public List<GroupChatUser> IncreaseUnreadMsgsOfGroupChatMembers(List<GroupChatUser> chatMembers);
        public void CleanUnreadMsgsOfGroupChatMember(GroupChatUser chatUser);
        public List<GroupChatUser> GetGroupChatMembers(Guid chatId);
    }
}
