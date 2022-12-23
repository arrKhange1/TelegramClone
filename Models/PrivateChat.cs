using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramClone.Models
{
    public class PrivateChat
    {
        public Guid PrivateChatId { get; set; }
        public Guid FirstParticipantId { get; set; }
        public User FirstParticipant { get; set; }
        public Guid SecondParticipantId { get; set; }
        public User SecondParticipant { get; set; }
        public int UnreadMsgsByFirst { get; set; }
        public int UnreadMsgsBySecond { get; set; }
        public List<PrivateChatMessage> PrivateChatMessages { get; set; }

        public Guid? LastMessageId { get; set; }
        public PrivateChatMessage LastMessage { get; set; }
    }
}
