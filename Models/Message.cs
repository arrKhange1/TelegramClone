using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramClone.Models
{
    public class Message
    {
        public Guid MessageId { get; set; }
        public string MessageText { get; set; }
        public DateTime MessageTime { get; set; }

        public Guid MessageTypeId { get; set; }
        public MessageType MessageType { get; set; }

        public Guid ChatUserId { get; set; }
        public ChatUser ChatUser { get; set; }

        public Chat Chat { get; set; }
    }
}
