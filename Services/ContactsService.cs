using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramClone.Data.Interfaces;
using TelegramClone.Models;
using TelegramClone.Models.ResponseDTO;

namespace TelegramClone.Services
{
    public class ContactsService
    {
        private readonly IUserContactRepository _userContactRepository;
        public ContactsService(IUserContactRepository userContactRepository)
        {
            _userContactRepository = userContactRepository;
        }

        public async Task<bool> AddContact(Guid userId, Guid contactId)
        {
            return await _userContactRepository.AddContact(userId, contactId);
        }
        public List<ContactElementResponseDTO> GetContacts(Guid userId)
        {
            return _userContactRepository.GetContacts(userId);
        }


    }
}
