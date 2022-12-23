using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramClone.Models
{
    public class PrivateChatMessage
    {
        public Guid PrivateChatMessageId { get; set; }
        public Guid SenderId { get; set; }
        public User Sender { get; set; }
        public Guid PrivateChatId { get; set; }
        public PrivateChat PrivateChat { get; set; }
        public string MessageText { get; set; }
        public DateTime MessageTime { get; set; }


    }
}
