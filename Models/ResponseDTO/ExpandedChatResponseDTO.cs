using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramClone.Models.ResponseDTO
{
    public class ExpandedChatResponseDTO
    { 
        public List<MessageResponseDTO> Messages { get; set; }

    }
}
