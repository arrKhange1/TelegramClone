using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramClone.Models
{
    public class MessageType
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public List<Message> Message { get; set; }
    }
}
