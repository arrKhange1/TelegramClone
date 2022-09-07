﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramClone.Models
{
    public class ChatUser
    {
        public Guid ChatUserId { get; set; }

        public Guid ChatId { get; set; }
        public Chat Chat { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public ChatUser()
        {
            Messages = new List<Message>();
        }
        public List<Message> Messages { get; set; }
    }
}
