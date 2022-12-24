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
        public List<MessageResponseDTO> GetGroupChatMsgs(Guid groupChatId);
        public List<MessageResponseDTO> GetPrivateChatMessages(Guid privateChatId);
        public Task<GroupChatMessage> AddGroupChatMsg(Guid groupChatId, Guid userId, string messageText, string messageType);
        public Task<PrivateChatMessage> AddPrivateChatMessage(Guid privateChatId, Guid fromId, string messageText);
    }
}
