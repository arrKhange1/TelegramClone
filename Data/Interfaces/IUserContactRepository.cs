using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramClone.Data.Interfaces
{
    public interface IUserContactRepository
    {
        public void AddContact(Guid userId, Guid contactId);
    }
}
