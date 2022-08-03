using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramClone.Data.Interfaces;
using TelegramClone.Models;
using TelegramClone.Models.DTO;

namespace TelegramClone.Data.Implementations
{
    public class UserMSSQLRepository: IUserRepository
    {
        private readonly ApplicationContext _context;
        public UserMSSQLRepository(ApplicationContext context)
        {
            _context = context;
        }
        public User GetUserByUsernameAndPassword(UserLogin userLogin)
        {
            return _context.Users.FirstOrDefault(user => user.UserName == userLogin.UserName &&
                user.Password == userLogin.Password);
        }
        public User GetUserByUsername(string userName)
        {
            return _context.Users.FirstOrDefault(user => user.UserName == userName);
        }

        public async Task<User> AddUser(User createdUser)
        {
            await _context.Users.AddAsync(createdUser);
            await _context.SaveChangesAsync();
            return createdUser;
        }


    }
}
