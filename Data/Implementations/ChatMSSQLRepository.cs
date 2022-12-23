﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TelegramClone.Data.Interfaces;
using TelegramClone.Models;
using TelegramClone.Models.ResponseDTO;

namespace TelegramClone.Data.Implementations
{
    public class ChatMSSQLRepository : IChatRepository
    {
        ApplicationContext _context;

        public ChatMSSQLRepository(ApplicationContext context)
        {
            _context = context;
        }

        public GroupChat GetGroupChat(Guid chatId)
        {
            return _context.GroupChats.FirstOrDefault(chat => chat.GroupChatId == chatId);
        }

        public List<ChatElementResponseDTO> GetGroupChats(Guid userId)
        { 
            var result = from cu in _context.GroupChatUsers join
            c in _context.GroupChats on cu.GroupChatId equals c.GroupChatId
            join msg in _context.GroupChatMessages on c.LastMessageId equals msg.GroupChatMessageId
            join msgType in _context.GroupChatMessageTypes on msg.GroupChatMessageTypeId equals msgType.GroupChatMessageTypeId
            join u in _context.Users on msg.UserId equals u.UserId
            where cu.UserId == userId
            select new ChatElementResponseDTO
            {
                ChatId = c.GroupChatId,
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
                return new List<ChatElementResponseDTO>();
            return groupChats;
        }

        public PrivateChat GetPrivateChat(Guid firstParticipantId, Guid secondParticipantId)
        {
            var dialog = _context.PrivateChats.FirstOrDefault(dial => dial.FirstParticipantId == firstParticipantId && dial.SecondParticipantId == secondParticipantId ||
                dial.FirstParticipantId == secondParticipantId && dial.SecondParticipantId == firstParticipantId);
            return dialog;
        }
 
        public List<ChatElementResponseDTO> GetPrivateChats(Guid userId)
        {
            var firstParticipants = from pc in _context.PrivateChats join
            dialogUser in _context.Users on pc.FirstParticipantId equals dialogUser.UserId
            join msg in _context.PrivateChatMessages on pc.LastMessageId equals msg.PrivateChatMessageId
            join lastMsgUser in _context.Users on msg.SenderId equals lastMsgUser.UserId
            where pc.SecondParticipantId == userId
            select new ChatElementResponseDTO
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

            var secondParticipants = from pc in _context.PrivateChats join
            u in _context.Users on pc.SecondParticipantId equals u.UserId
            join msg in _context.PrivateChatMessages on pc.LastMessageId equals msg.PrivateChatMessageId
            join lastMsgUser in _context.Users on msg.SenderId equals lastMsgUser.UserId
            where pc.FirstParticipantId == userId
            select new ChatElementResponseDTO
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
                return new List<ChatElementResponseDTO>();
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

        
        public void UpdatePrivateChatLastMessage(PrivateChat dialog, Guid lastMessageId)
        {
            dialog.LastMessageId = lastMessageId;
            _context.SaveChanges();
        }

        public void UpdateGroupChatLastMessage(GroupChat chat, Guid lastMessageId)
        {
            chat.LastMessageId = lastMessageId;
            _context.SaveChanges();
        }

        public int IncreaseUnreadMsgsOfPrivateChat(PrivateChat dialog, Guid toId)
        {
            int unreadMsgs = 0;
            if (toId == dialog.FirstParticipantId)
            {
                dialog.UnreadMsgsByFirst += 1;
                unreadMsgs = dialog.UnreadMsgsByFirst;
            }
            else if (toId == dialog.SecondParticipantId)
            {
                dialog.UnreadMsgsBySecond += 1;
                unreadMsgs = dialog.UnreadMsgsBySecond;
            }
               
            _context.SaveChanges();
            return unreadMsgs;
        }
        
        public void CleanUnreadMsgsOfPrivateChat(PrivateChat dialog, Guid fromId) // если нет диалога в контактах то ошибка (диалог пустой)
        {
            if (fromId == dialog.FirstParticipantId)
                dialog.UnreadMsgsByFirst = 0;
            else if (fromId == dialog.SecondParticipantId)
                dialog.UnreadMsgsBySecond = 0;
            _context.SaveChanges();
        }

        public async Task<PrivateChat> AddPrivateChat(Guid fromId, Guid toId)
        {
            var newPrivateChat = new PrivateChat
            {
                PrivateChatId = Guid.NewGuid(),
                FirstParticipantId = fromId,
                SecondParticipantId = toId,
            };
            var addedChat = await _context.PrivateChats.AddAsync(newPrivateChat);
            if (addedChat != null)
            {
                _context.SaveChanges();
                return addedChat.Entity;
            }
            return null;
        }

        public async Task<GroupChat> AddGroupChat(string chatName, int groupMembers)
        {
            var newChatGuid = Guid.NewGuid();
            var newChat = new GroupChat
            {
                GroupChatId = newChatGuid,
                ChatName = chatName,
                ChatCategoryId = _context.ChatCategories.FirstOrDefault(cat => cat.ChatCategoryName == "group").ChatCategoryId,
                GroupMembers = groupMembers,
                CreateTime = DateTime.UtcNow
            };
            var addedChat = await _context.GroupChats.AddAsync(newChat);
            if (addedChat != null)
            {
                _context.SaveChanges();
                return addedChat.Entity;
            }
            return null;
        }
    }
}
