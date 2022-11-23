using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TelegramClone.Data.Interfaces;
using TelegramClone.Models;
using TelegramClone.Models.DTO;

namespace TelegramClone.Data.Implementations
{
    public class ChatMSSQLRepository : IChatRepository
    {
        ApplicationContext _context;

        public ChatMSSQLRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Chat GetChat(Guid chatId)
        {
            return _context.Chats.FirstOrDefault(chat => chat.ChatId == chatId);
        }

        public List<ChatElementDTO> GetGroupChats(Guid userId)
        { // exchange chatuserid on user id and chatId
            var result = from cu in _context.ChatUsers join
            c in _context.Chats on cu.ChatId equals c.ChatId
            join msg in _context.Messages on c.LastMessageId equals msg.MessageId
            join msgType in _context.MessageTypes on msg.MessageTypeId equals msgType.Id
            join cuu in _context.ChatUsers on msg.ChatUserId equals cuu.ChatUserId
            join u in _context.Users on cuu.UserId equals u.UserId
            where cu.UserId == userId
            select new ChatElementDTO
            {
                ChatId = c.ChatId,
                ChatName = c.ChatName,
                ChatCategory = "group",
                LastMessageSender = u.UserName,
                LastMessageText = msg.MessageText,
                LastMessageTime = msg.MessageTime,
                LastMessageType = msgType.Type,
                UnreadMsgs = cu.UnreadMessages
            };
            var groupChats = result.ToList();
            if (groupChats == null)
                return new List<ChatElementDTO>();
            return groupChats;
        }

        public Dialog GetPrivateChat(Guid firstParticipantId, Guid secondParticipantId)
        {
            var dialog = _context.Dialogs.FirstOrDefault(dial => dial.FirstParticipantId == firstParticipantId && dial.SecondParticipantId == secondParticipantId ||
                dial.FirstParticipantId == secondParticipantId && dial.SecondParticipantId == firstParticipantId);
            return dialog;
        }
 
        public List<ChatElementDTO> GetPrivateChats(Guid userId)
        {
            var firstParticipants = from pc in _context.Dialogs join
            dialogUser in _context.Users on pc.FirstParticipantId equals dialogUser.UserId
            join msg in _context.DialogMessages on pc.LastMessageId equals msg.MessageId
            join lastMsgUser in _context.Users on msg.SenderId equals lastMsgUser.UserId
            where pc.SecondParticipantId == userId
            select new ChatElementDTO
            {
                ChatId = dialogUser.UserId,
                ChatName = dialogUser.UserName,
                ChatCategory = "private",
                LastMessageSender = lastMsgUser.UserName,
                LastMessageText = msg.MessageText,
                LastMessageTime = msg.MessageTime,
                LastMessageType = "message",
                UnreadMsgs = pc.UnreadMsgsBySecond
            };

            var secondParticipants = from pc in _context.Dialogs join
            u in _context.Users on pc.SecondParticipantId equals u.UserId
            join msg in _context.DialogMessages on pc.LastMessageId equals msg.MessageId
            join lastMsgUser in _context.Users on msg.SenderId equals lastMsgUser.UserId
            where pc.FirstParticipantId == userId
            select new ChatElementDTO
            {
                ChatId = u.UserId,
                ChatName = u.UserName,
                ChatCategory = "private",
                LastMessageSender = lastMsgUser.UserName,
                LastMessageText = msg.MessageText,
                LastMessageTime = msg.MessageTime,
                LastMessageType = "message",
                UnreadMsgs = pc.UnreadMsgsByFirst
            };

            if (firstParticipants == null && secondParticipants == null)
                return new List<ChatElementDTO>();
            else if (firstParticipants == null)
            {
                return secondParticipants.ToList();
            }
            else if (secondParticipants == null)
            {
                return firstParticipants.ToList();
            }
            return firstParticipants.Concat(secondParticipants).ToList();
        }

        
        public void UpdatePrivateChatLastMessage(Dialog dialog, Guid lastMessageId)
        {
            dialog.LastMessageId = lastMessageId;
            _context.SaveChanges();
        }

        public void UpdateGroupChatLastMessage(Chat chat, Guid lastMessageId)
        {
            chat.LastMessageId = lastMessageId;
            _context.SaveChanges();
        }

        public void UpdateUnreadMsgsOfDialog(Dialog dialog, Guid toId)
        {
            if (toId == dialog.FirstParticipantId)
                dialog.UnreadMsgsByFirst += 1;
            else if (toId == dialog.SecondParticipantId)
                dialog.UnreadMsgsBySecond += 1;
            _context.SaveChanges();
        }

        public async Task<Dialog> AddPrivateChat(Guid fromId, Guid toId)
        {
            var newDialog= new Dialog
            {
                DialogId = Guid.NewGuid(),
                FirstParticipantId = fromId,
                SecondParticipantId = toId,
            };
            var addedChat = await _context.Dialogs.AddAsync(newDialog);
            if (addedChat != null)
            {
                _context.SaveChanges();
                return addedChat.Entity;
            }
            return null;
        }

        public async Task<Chat> AddGroupChat(string chatName, int groupMembers)
        {
            var newChatGuid = Guid.NewGuid();
            var newChat = new Chat
            {
                ChatId = newChatGuid,
                ChatName = chatName,
                ChatCategoryId = _context.ChatCategories.FirstOrDefault(cat => cat.ChatCategoryName == "group").ChatCategoryId,
                GroupMembers = groupMembers,
                CreateTime = DateTime.UtcNow
            };
            var addedChat = await _context.Chats.AddAsync(newChat);
            if (addedChat != null)
            {
                _context.SaveChanges();
                return addedChat.Entity;
            }
            return null;
        }
    }
}
