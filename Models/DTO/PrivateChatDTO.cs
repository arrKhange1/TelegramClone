using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramClone.Models.DTO
{
    public class PrivateChatDTO : ExpandedChatDTO
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string ConnectionStatus { get; set; }
    }
}
