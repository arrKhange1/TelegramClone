using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramClone.Models;
using TelegramClone.Models.ResponseDTO;

namespace TelegramClone.Data.Interfaces
{
    public interface IMessageRepository
    {
        public List<MessageResponseDTO> GetGroupChatMsgs(Guid chatId);
        public List<MessageResponseDTO> GetPrivateChatMessages(Guid dialogId);
        public Task<GroupChatMessage> AddGroupChatMsg(Guid chatId, Guid userId, string messageText, string messageType);
        public Task<PrivateChatMessage> AddPrivateChatMessage(Guid dialogId, Guid fromId, string messageText);
    }
}
