using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramClone.Models;
using TelegramClone.Models.DTO;

namespace TelegramClone.Data.Interfaces
{
    public interface IUserRepository
    {
        public User GetUserByUsernameAndPassword(UserLogin newUser);
        public User GetUserByUsername(string userName);
        public User GetUserById(Guid userId);
        public Task<User> AddUser(User user);


        
    }
}
