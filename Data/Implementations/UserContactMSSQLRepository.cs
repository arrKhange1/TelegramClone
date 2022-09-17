using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramClone.Data.Interfaces;

namespace TelegramClone.Data.Implementations
{
    public class UserContactMSSQLRepository : IUserContactRepository
    {
        private readonly ApplicationContext _context;
        public UserContactMSSQLRepository(ApplicationContext context)
        {
            _context = context;
        }
        public void AddContact(Guid userId, Guid contactId)
        {
            
        }
    }
}
