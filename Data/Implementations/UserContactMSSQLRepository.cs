using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramClone.Data.Interfaces;
using TelegramClone.Models;
using TelegramClone.Models.DTO;

namespace TelegramClone.Data.Implementations
{
    public class UserContactMSSQLRepository : IUserContactRepository
    {
        private readonly ApplicationContext _context;
        public UserContactMSSQLRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<bool> AddContact(Guid userId, Guid contactId)
        {
            try
            {
                await _context.UserContacts.AddAsync(
                new UserContact
                {
                    UserContactId = Guid.NewGuid(),
                    UserId = userId,
                    ContactId = contactId
                });
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                return false;
            }
        }

        public List<ContactElement> GetContacts(Guid userId)
        {
            var contacts = from uc in _context.UserContacts
                       join u in _context.Users on uc.ContactId equals u.UserId
                       where uc.UserId == userId
                       select new ContactElement
                       {
                           ContactId = u.UserId,
                           ContactName = u.UserName,
                           ContactPhoto = u.UserPhoto,
                           ConnectionStatus = u.ConnectionStatus
                       };
            return contacts.ToList();
        }
    }
}
