using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramClone.Data.Interfaces;
using TelegramClone.Models;

namespace TelegramClone.Services
{
    public class RoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
           _roleRepository = roleRepository;
        }

        public Role GetRoleById(User user)
        {
            return _roleRepository.GetRoleById(user);
        }
        
    }
}
