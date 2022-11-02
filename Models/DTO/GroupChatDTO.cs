using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramClone.Models.DTO
{
    public class GroupChatDTO : ExpandedChatDTO
    {
        public string ChatName { get; set; }
        public string GroupMembers { get; set; }
    }
}
