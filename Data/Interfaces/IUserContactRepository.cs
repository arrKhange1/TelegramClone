using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramClone.Models;
using TelegramClone.Models.ResponseDTO;

namespace TelegramClone.Data.Interfaces
{
    public interface IUserContactRepository
    {
        public Task<bool> AddContact(Guid userId, Guid contactId);
        public List<ContactElementResponseDTO> GetContacts(Guid userId);
    }
}
