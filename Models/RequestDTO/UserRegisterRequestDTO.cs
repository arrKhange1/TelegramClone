using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramClone.Models.RequestDTO
{
    public class UserRegisterRequestDTO : UserLoginRequestDTO
    {
        public string ConfirmPassword { get; set; }

    }
}
