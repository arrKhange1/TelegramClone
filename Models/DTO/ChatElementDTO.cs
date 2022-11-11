using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramClone.Models.DTO
{
    public class ChatElementDTO
    {
        public Guid ChatId { get; set; }
        public string ChatName { get; set; }
        public string ChatCategory { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
