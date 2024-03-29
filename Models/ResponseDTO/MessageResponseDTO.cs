﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramClone.Models.ResponseDTO
{
    public class MessageResponseDTO
    {
        public string UserName { get; set; }
        public string MessageText { get; set; }
        public string MessageType { get; set; }
        public DateTime MessageTime { get; set; }

        public MessageResponseDTO(string userName, string msgText, string msgType, DateTime msgTime)
        {
            UserName = userName;
            MessageText = msgText;
            MessageType = msgType;
            MessageTime = msgTime;
        }
    }
}
