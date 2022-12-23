using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramClone.Data.Interfaces;
using TelegramClone.Models;
using TelegramClone.Models.RequestDTO;

namespace TelegramClone.Data.Implementations
{
    public class UserMSSQLRepository: IUserRepository
    {
        private readonly ApplicationContext _context;
        public UserMSSQLRepository(ApplicationContext context)
        {
            _context = context;
        }
        public User GetUserByUsernameAndPassword(UserLoginRequestDTO userLogin)
        {
            return _context.Users.FirstOrDefault(user => user.UserName == userLogin.UserName &&
                user.Password == userLogin.Password);
        }
        public User GetUserByUsername(string userName)
        {
            return _context.Users.FirstOrDefault(user => user.UserName == userName);
        }

        public User GetUserById(Guid userId)
        {
            return _context.Users.FirstOrDefault(user => user.UserId == userId);
        }

        public async Task<User> AddUser(User createdUser)
        {
            await _context.Users.AddAsync(createdUser);
            await _context.SaveChangesAsync();
            return createdUser;
        }


    }
}
