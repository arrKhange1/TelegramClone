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
        public List<MessageResponseDTO> GetMsgs(Guid chatId);
        public List<MessageResponseDTO> GetDialogMessages(Guid dialogId);
        public Task<Message> AddMsg(Guid chatId, Guid userId, string messageText, string messageType);
        public Task<DialogMessage> AddDialogMessage(Guid dialogId, Guid fromId, string messageText);
    }
}
