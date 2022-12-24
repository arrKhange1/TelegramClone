using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramClone.Data.Interfaces;
using TelegramClone.Models;
using TelegramClone.Models.ResponseDTO;

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
                new UserContact(userId, contactId, DateTime.UtcNow));
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                return false;
            }
        }

        public List<ContactElementResponseDTO> GetContacts(Guid userId)
        {
            var contacts = from uc in _context.UserContacts
                       join u in _context.Users on uc.ContactId equals u.UserId
                       where uc.UserId == userId
                       orderby uc.CreateTime descending
                       select new ContactElementResponseDTO(u.UserId, u.UserName);
                      
            return contacts.ToList();
        }
    }
}
