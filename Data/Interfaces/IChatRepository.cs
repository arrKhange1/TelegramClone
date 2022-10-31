using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramClone.Models;
using TelegramClone.Models.DTO;

namespace TelegramClone.Data.Interfaces
{
    public interface IChatRepository
    {
        public Chat GetChat(Guid chatId);
        public Task<Guid> AddGroupChat(string chatName, int groupMembers);
        public List<ChatElementDTO> GetChats(Guid userId);
    }
}
