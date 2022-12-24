using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramClone.Models.ResponseDTO
{
    public class PrivateChatResponseDTO : ExpandedChatResponseDTO
    {
        public string UserId { get; set; }
        public string UserName { get; set; }

        public PrivateChatResponseDTO(string userId, string userName, List<MessageResponseDTO> msgs)
        {
            UserId = userId;
            UserName = userName;
            Messages = msgs;
        }
    }
}
