using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramClone.Models.RequestDTO
{
    public class GroupChatMessageRequestDTO
    {
        public string ChatId { get; set; }
        public string SenderId { get; set; }
        public string MessageText { get; set; }
    }
}
