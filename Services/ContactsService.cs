using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramClone.Data.Interfaces;
using TelegramClone.Models;
using TelegramClone.Models.DTO;

namespace TelegramClone.Services
{
    public class ContactsService
    {
        private readonly IUserContactRepository _userContactRepository;
        public ContactsService(IUserContactRepository userContactRepository)
        {
            _userContactRepository = userContactRepository;
        }

        public void AddContact(Guid userId, Guid contactId)
        {
            _userContactRepository.AddContact(userId, contactId);
        }
        public List<ContactElement> GetContacts(Guid userId)
        {
            return _userContactRepository.GetContacts(userId);
        }


    }
}
