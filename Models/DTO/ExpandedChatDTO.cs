using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramClone.Models.DTO
{
    public class ExpandedChatDTO
    {
        public string ChatName { get; set; }
        public string ChatStatus { get; set; }

        public List<MessageDTO> Messages { get; set; }

    }
}
