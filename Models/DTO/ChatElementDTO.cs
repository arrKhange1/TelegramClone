using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramClone.Models.DTO
{
    public class ChatElementDTO : IComparable<ChatElementDTO>
    {
        public Guid ChatId { get; set; }
        public string ChatName { get; set; }
        public string ChatCategory { get; set; }
        public string LastMessageSender { get; set; }
        public string LastMessageText { get; set; }
        public DateTime LastMessageTime { get; set; }
        public string LastMessageType { get; set; }

        public int CompareTo(ChatElementDTO chatElement)
        {
            return (LastMessageTime != chatElement.LastMessageTime) ?
                (LastMessageTime < chatElement.LastMessageTime ? 1 : -1) : 0;
        }
    }
}
