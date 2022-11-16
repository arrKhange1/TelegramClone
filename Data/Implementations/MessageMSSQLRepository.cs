﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramClone.Data.Interfaces;
using TelegramClone.Models;
using TelegramClone.Models.DTO;

namespace TelegramClone.Data.Implementations
{
    public class MessageMSSQLRepository : IMessageRepository
    {
        ApplicationContext _context;

        public MessageMSSQLRepository(ApplicationContext context)
        {
            _context = context;
        }
        public List<MessageDTO> GetMsgs(Guid chatId)
        {
            var msgs = from m in _context.Messages join
            cu in _context.ChatUsers on m.ChatUserId equals cu.ChatUserId join
            u in _context.Users on cu.UserId equals u.UserId
            where chatId == cu.ChatId
            orderby m.MessageTime
            select new MessageDTO
            {
                UserName = u.UserName,
                MessageText = m.MessageText,
                MessageTime = m.MessageTime
            };

            return msgs.ToList();
        }

        public List<MessageDTO> GetDialogMessages(Guid dialogId)
        { // add message time and message time sort
            var msgs = from m in _context.DialogMessages join
            d in _context.Dialogs on m.DialogId equals d.DialogId join
            u in _context.Users on m.SenderId equals u.UserId
            where m.DialogId == dialogId
            select new MessageDTO
            {
                UserName = u.UserName,
                MessageText = m.MessageText
            };
            return msgs.ToList();
        }

        public async Task<Message> AddMsg(Guid chatUserId, string messageText)
        {
            var added = await _context.Messages.AddAsync(new Message
            {
                MessageId = Guid.NewGuid(),
                MessageText = messageText,
                ChatUserId = chatUserId,
                MessageTime = DateTime.UtcNow
            });
            await _context.SaveChangesAsync();
            return added.Entity;
        }

        public async Task<DialogMessage> AddDialogMessage(Guid dialogId, Guid fromId, string messageText)
        {
            var added = await _context.DialogMessages.AddAsync(new DialogMessage
            {
                MessageId = Guid.NewGuid(),
                SenderId = fromId,
                MessageText = messageText,
                DialogId = dialogId
            });
            await _context.SaveChangesAsync();
            return added.Entity;
        }
    }
}
