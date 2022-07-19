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

        public Guid? RoleId { get; set; }
        public Role Role { get; set; }

        public List<ChatUser> ChatUsers { get; set; }


    }
}
