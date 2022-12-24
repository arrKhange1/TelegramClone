using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramClone.Models
{
    public class GroupChatMessageType
    {
        public Guid GroupChatMessageTypeId { get; set; }
        public string Type { get; set; }
        public List<GroupChatMessage> GroupChatMessages { get; set; }

        public GroupChatMessageType(string type)
        {
            GroupChatMessageTypeId = Guid.NewGuid();
            Type = type;
        }
    }
}
