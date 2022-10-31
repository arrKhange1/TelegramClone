using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramClone.Models.DTO;

namespace TelegramClone.Data.Interfaces
{
    public interface IMessageRepository
    {
        public List<MessageDTO> GetMsgs(Guid chatId);
    }
}
