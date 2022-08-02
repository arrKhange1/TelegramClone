using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramClone.Models;

namespace TelegramClone.Data.Interfaces
{
    public interface IRoleRepository
    {
        public Role GetRoleByName(string roleName);
        public Role GetRoleById(User user);
    }
}
