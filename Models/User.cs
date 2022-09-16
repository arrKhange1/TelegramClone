using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramClone.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConnectionStatus { get; set; }

        public Guid? RoleId { get; set; }
        public Role Role { get; set; }

        public List<RefreshToken> RefreshTokens { get; set; }
        public User()
        {
            RefreshTokens = new List<RefreshToken>();
            ChatUsers = new List<ChatUser>();
        }
        
        public List<ChatUser> ChatUsers { get; set; }

        public List<UserContact> UserContactsUsers { get; set; }
        public List<UserContact> UserContactsContacts { get; set; }


    }
}
