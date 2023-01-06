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
        public bool VerifyUserPassword(UserLoginRequestDTO userLogin, User user);
        public User GetUserByUsername(string userName);
        public User GetUserByUserLoginDTO(UserLoginRequestDTO userLogin);
        public User GetUserById(Guid userId);
        public Task<User> AddUser(User user);


        
    }
}
