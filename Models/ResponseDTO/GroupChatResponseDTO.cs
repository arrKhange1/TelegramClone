using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramClone.Models.ResponseDTO
{
    public class GroupChatResponseDTO : ExpandedChatResponseDTO
    {
        public string ChatName { get; set; }
        public int GroupMembers { get; set; }

    }
}
