using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramClone.Models.DTO
{
    [Serializable]
    public class Tokens
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
