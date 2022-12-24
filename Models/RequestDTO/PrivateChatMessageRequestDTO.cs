using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramClone.Models.RequestDTO
{
    public class PrivateChatMessageRequestDTO
    {
        public string FromId { get; set; }
        public string ToId { get; set; }
        public string ToName { get; set; }
        public string MessageText { get; set; }
    }
}
