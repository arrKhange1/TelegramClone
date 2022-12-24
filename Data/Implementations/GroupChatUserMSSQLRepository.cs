using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramClone.Data.Interfaces;
using TelegramClone.Models;

namespace TelegramClone.Data.Implementations
{
    public class GroupChatUserMSSQLRepository : IGroupChatUserRepository
    {
        ApplicationContext _context;

        public GroupChatUserMSSQLRepository(ApplicationContext context)
        {
            _context = context;
        }

        public List<GroupChatUser> GetGroupChatMembers(Guid groupChatId)
        {
            return _context.GroupChatUsers.Where(cu => cu.GroupChatId == groupChatId).ToList();
        }

        public List<GroupChatUser> IncreaseUnreadMsgsOfGroupChatMembers(List<GroupChatUser> chatMembers)
        {
            List<GroupChatUser> updatedChatUsers = new List<GroupChatUser>();
            foreach(var chatMember in chatMembers)
            {
                chatMember.UnreadMessages += 1;
                updatedChatUsers.Add(chatMember);
            }
            
            _context.SaveChanges();
            return updatedChatUsers;
        }
        public void CleanUnreadMsgsOfGroupChatMember(GroupChatUser chatUser)
        {
            chatUser.UnreadMessages = 0;
            _context.SaveChanges();
        }

        public GroupChatUser GetGroupChatUserByChatIdAndUserId(Guid groupChatId, Guid userId)
        {
            return _context.GroupChatUsers.FirstOrDefault(cu => cu.GroupChatId == groupChatId && cu.UserId == userId);
        }
        public async Task<bool> AddUsersToGroupChat(List<GroupChatUser> members)
        {
            try
            {
                await _context.GroupChatUsers.AddRangeAsync(members);
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
