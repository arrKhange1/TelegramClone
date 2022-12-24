using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramClone.Models.ResponseDTO
{
    public class ChatElementResponseDTO : IComparable<ChatElementResponseDTO>
    {
        public Guid ChatId { get; set; }
        public string ChatName { get; set; }
        public string ChatCategory { get; set; }
        public string LastMessageSender { get; set; }
        public string LastMessageText { get; set; }
        public DateTime LastMessageTime { get; set; }
        public string LastMessageType { get; set; }
        public int UnreadMsgs { get; set; }

        public ChatElementResponseDTO(Guid chatId, string chatName, string chatCategory, string lastMsgSender, 
            string lastMsgText, DateTime lastMsgTime, string lastMsgType, int unreadMsgs)
        {
            ChatId = chatId;
            ChatName = chatName;
            ChatCategory = chatCategory;
            LastMessageSender = lastMsgSender;
            LastMessageText = lastMsgText;
            LastMessageTime = lastMsgTime;
            LastMessageType = lastMsgType;
            UnreadMsgs = unreadMsgs;
        }

        public int CompareTo(ChatElementResponseDTO chatElement)
        {
            return (LastMessageTime != chatElement.LastMessageTime) ?
                (LastMessageTime < chatElement.LastMessageTime ? 1 : -1) : 0;
        }
    }
}
