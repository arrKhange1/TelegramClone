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
        public int GroupMembers { get; set; }
        public Guid ChatCategoryId { get; set; }
        public DateTime CreateTime { get; set; }
        public ChatCategory ChatCategory { get; set; }
        public List<ChatUser> ChatUsers { get; set; }
        public List<Message> Messages { get; set; }

        public Guid? LastMessageId { get; set; }
        public Message LastMessage { get; set; }
    }
}
