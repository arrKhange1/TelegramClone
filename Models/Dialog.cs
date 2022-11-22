using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramClone.Models
{
    public class Dialog
    {
        public Guid DialogId { get; set; }
        public Guid FirstParticipantId { get; set; }
        public User FirstParticipant { get; set; }
        public Guid SecondParticipantId { get; set; }
        public User SecondParticipant { get; set; }
        public int UnreadMsgsByFirst { get; set; }
        public int UnreadMsgsBySecond { get; set; }
        public List<DialogMessage> DialogMessages { get; set; }

        public Guid? LastMessageId { get; set; }
        public DialogMessage LastMessage { get; set; }
    }
}
