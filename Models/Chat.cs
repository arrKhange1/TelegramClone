using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramClone.Models
{
    public class Chat
    {
        public Guid ChatId { get; set; }
        public string ChatName { get; set; }

        public List<ChatUser> ChatUsers { get; set; }
    }
}
