using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramClone.Data.Interfaces;
using TelegramClone.Models;

namespace TelegramClone.Data.Implementations
{
    public class RoleMSSQLRepository: IRoleRepository
    {
        private readonly ApplicationContext _context;

        public RoleMSSQLRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Role GetRoleByName(string roleName)
        {
            return _context.Roles.FirstOrDefault(role => role.RoleName == roleName);
        }

        public Role GetRoleById(User user)
        {
            return _context.Roles.FirstOrDefault(role => role.RoleId == user.RoleId);
        }

    }
}
