using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramClone.Models
{
    public class GroupChatMessage
    {
        public Guid GroupChatMessageId { get; set; }
        public string MessageText { get; set; }
        public DateTime MessageTime { get; set; }

        public Guid GroupChatMessageTypeId { get; set; }
        public GroupChatMessageType GroupChatMessageType { get; set; }

        public Guid GroupChatId { get; set; }
        public GroupChat GroupChat { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        
    }
}
