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

        public List<ChatUser> GetChatMembers(Guid chatId)
        {
            return _context.ChatUsers.Where(cu => cu.ChatId == chatId).ToList();
        }

        public List<ChatUser> IncreaseUnreadMsgsOfChatMembers(List<ChatUser> chatMembers)
        {
            List<ChatUser> updatedChatUsers = new List<ChatUser>();
            foreach(var chatMember in chatMembers)
            {
                chatMember.UnreadMessages += 1;
                updatedChatUsers.Add(chatMember);
            }
            
            _context.SaveChanges();
            return updatedChatUsers;
        }
        public void CleanUnreadMsgsOfChatMember(ChatUser chatUser)
        {
            chatUser.UnreadMessages = 0;
            _context.SaveChanges();
        }

        public ChatUser GetChatUserByChatIdAndUserId(Guid chatId, Guid userId)
        {
            return _context.ChatUsers.FirstOrDefault(cu => cu.ChatId == chatId && cu.UserId == userId);
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
