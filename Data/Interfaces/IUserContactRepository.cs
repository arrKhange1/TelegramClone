using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramClone.Models;
using TelegramClone.Models.DTO;

namespace TelegramClone.Data.Interfaces
{
    public interface IUserContactRepository
    {
        public void AddContact(Guid userId, Guid contactId);
        public List<ContactElement> GetContacts(Guid userId);
    }
}
