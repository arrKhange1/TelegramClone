using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramClone.Data.Interfaces;
using TelegramClone.Models;
using TelegramClone.Models.DTO;

namespace TelegramClone.Data.Implementations
{
    public class ChatMSSQLRepository : IChatRepository
    {
        ApplicationContext _context;

        public ChatMSSQLRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Chat GetChat(Guid chatId)
        {
            return _context.Chats.FirstOrDefault(chat => chat.ChatId == chatId);
        }

        public static string GetChatName(Chat chat, ChatUser chatUser, Guid userId)
        {
            if (chat.ChatName == null)
            {
                if (userId != chatUser.UserId)
                    return userId.ToString().ToLower();
                return chatUser.ChatId.ToString().ToLower();
            }
            return chat.ChatName;
            
        }

        public List<ChatElementDTO> GetChats(Guid userId, HttpContext httpContext)
        {
            var currentUser = httpContext.User.Identity.Name;
            
            var result = from cu in _context.ChatUsers join
            c in _context.Chats on cu.ChatId equals c.ChatId
            where (cu.UserId == userId || cu.ChatId == userId) && cu.ChatId != cu.UserId
            orderby c.CreateTime descending
            select new ChatElementDTO
            {
                ChatId = c.ChatId,
                ChatName = GetChatName(c, cu, userId),
                ChatCategory = c.ChatName == null ? "private" : "group",
                CreateTime = c.CreateTime
            };
            return result.ToList();
        }

        public async Task<Guid> AddPrivateChat(Guid chatId)
        {
            var newChat = new Chat
            {
                ChatId = chatId,
                ChatCategoryId = _context.ChatCategories.FirstOrDefault(cat => cat.ChatCategoryName == "private").ChatCategoryId,
                GroupMembers = 2,
                CreateTime = DateTime.UtcNow
            };
            var addedChat = await _context.Chats.AddAsync(newChat);
            if (addedChat != null)
            {
                _context.SaveChanges();
                return chatId;
            }
            return Guid.Empty;
        }

        public async Task<Guid> AddGroupChat(string chatName, int groupMembers)
        {
            var newChatGuid = Guid.NewGuid();
            var newChat = new Chat
            {
                ChatId = newChatGuid,
                ChatName = chatName,
                ChatCategoryId = _context.ChatCategories.FirstOrDefault(cat => cat.ChatCategoryName == "group").ChatCategoryId,
                GroupMembers = groupMembers,
                CreateTime = DateTime.UtcNow
            };
            var addedChat = await _context.Chats.AddAsync(newChat);
            if (addedChat != null)
            {
                _context.SaveChanges();
                return newChatGuid;
            }
            return Guid.Empty;
        }
    }
}
