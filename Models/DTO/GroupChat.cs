using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramClone.Models.DTO
{
    public class GroupChat
    {
        public List<string> membersIds { get; set; }
        public List<string> membersNames { get; set; }
        public string groupName { get; set; }
    }
}
