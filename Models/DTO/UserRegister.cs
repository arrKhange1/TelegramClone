using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramClone.Models.DTO
{
    public class UserRegister : UserLogin
    {
        public string ConfirmPassword { get; set; }

    }
}
