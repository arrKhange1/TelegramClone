using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramClone.Models;
using TelegramClone.Models.RequestDTO;

namespace TelegramClone.Data.Interfaces
{
    public interface IUserRepository
    {
        public User GetUserByUsernameAndPassword(UserLoginRequestDTO newUser);
        public User GetUserByUsername(string userName);
        public User GetUserById(Guid userId);
        public Task<User> AddUser(User user);


        
    }
}
