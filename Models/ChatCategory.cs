using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramClone.Models
{
    public class ChatCategory
    {
        public Guid ChatCategoryId { get; set; }
        public string ChatCategoryName { get; set; }

        public ChatCategory(string chatCategoryName)
        {
            ChatCategoryId = Guid.NewGuid();
            ChatCategoryName = chatCategoryName;
        }
    }
}
