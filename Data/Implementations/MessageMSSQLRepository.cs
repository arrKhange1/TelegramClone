using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramClone.Data.Interfaces;
using TelegramClone.Models;
using TelegramClone.Models.ResponseDTO;

namespace TelegramClone.Data.Implementations
{
    public class MessageMSSQLRepository : IMessageRepository
    {
        ApplicationContext _context;

        public MessageMSSQLRepository(ApplicationContext context)
        {
            _context = context;
        }
        public List<MessageResponseDTO> GetGroupChatMsgs(Guid groupChatId)
        {
            var msgs = from m in _context.GroupChatMessages
            join u in _context.Users on m.UserId equals u.UserId
            join msgType in _context.GroupChatMessageTypes on m.GroupChatMessageTypeId equals msgType.GroupChatMessageTypeId
            where groupChatId == m.GroupChatId
            orderby m.MessageTime
            select new MessageResponseDTO(u.UserName, m.MessageText, msgType.Type, m.MessageTime);
            
            return msgs.ToList();
        }

        public List<MessageResponseDTO> GetPrivateChatMessages(Guid privateChatId)
        {
            var msgs = from m in _context.PrivateChatMessages
            join d in _context.PrivateChats on m.PrivateChatId equals d.PrivateChatId
            join u in _context.Users on m.SenderId equals u.UserId
            where m.PrivateChatId == privateChatId
            orderby m.MessageTime
            select new MessageResponseDTO(u.UserName, m.MessageText, "message", m.MessageTime);
            
            return msgs.ToList();
        }

        public async Task<GroupChatMessage> AddGroupChatMsg(Guid groupChatId, Guid userId, string messageText, string messageType)
        {
            var msgTypeId = _context.GroupChatMessageTypes.FirstOrDefault(msgType => msgType.Type == messageType).GroupChatMessageTypeId;
            var added = await _context.GroupChatMessages.AddAsync(new GroupChatMessage(messageText, groupChatId, userId, DateTime.UtcNow, msgTypeId));
            await _context.SaveChangesAsync();
            return added.Entity;
        }

        public async Task<PrivateChatMessage> AddPrivateChatMessage(Guid privateChatId, Guid fromId, string messageText)
        {
            var added = await _context.PrivateChatMessages.AddAsync(new PrivateChatMessage(fromId, messageText, privateChatId, DateTime.UtcNow));
            await _context.SaveChangesAsync();
            return added.Entity;
        }

    }
}
