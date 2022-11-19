using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramClone.Models;
using TelegramClone.Models.DTO;

namespace TelegramClone.Data.Interfaces
{
    public interface IMessageRepository
    {
        public List<MessageDTO> GetMsgs(Guid chatId);
        public List<MessageDTO> GetDialogMessages(Guid dialogId);
        public Task<Message> AddMsg(Guid chatUserId, string messageText, string messageType);
        public Task<DialogMessage> AddDialogMessage(Guid dialogId, Guid fromId, string messageText);
    }
}
