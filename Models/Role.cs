using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramClone.Models
{
    public class Role
    {
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }

        public List<User> Users { get; set; }

        public Role(string roleName)
        {
            RoleId = Guid.NewGuid();
            RoleName = roleName;
        }

    }
}
