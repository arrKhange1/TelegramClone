using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TelegramClone.Data.Interfaces;
using TelegramClone.Models;
using TelegramClone.Models.DTO;

namespace TelegramClone.Services
{
    public class ChatsService
    {
        private readonly IChatRepository _chatRepository;
        private readonly IChatUserRepository _chatUserRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly IChatCategoryRepository _chatCategoryRepository;
        private readonly IUserRepository _userRepository;

        public ChatsService(IChatRepository chatRepository, IChatUserRepository chatUserRepository, 
            IMessageRepository messageRepository, IChatCategoryRepository chatCategoryRepository,
            IUserRepository userRepository)
        {
            _chatRepository = chatRepository;
            _chatUserRepository = chatUserRepository;
            _messageRepository = messageRepository;
            _chatCategoryRepository = chatCategoryRepository;
            _userRepository = userRepository;
        }

        public List<string> GetChatMemberIds(Guid chatId)
        {
            return _chatUserRepository.GetChatMemberIds(chatId);
        }

        public ChatUser GetChatUser(Guid chatId, Guid userId)
        {
            return _chatUserRepository.GetChatUserByChatIdAndUserId(chatId, userId);
        }

        public ChatCategory GetChatCategoryById(Guid chatCategoryId)
        {
            return _chatCategoryRepository.GetChatCategoryById(chatCategoryId);
        }

        public List<MessageDTO> GetMsgs(Guid chatId)
        {
            return _messageRepository.GetMsgs(chatId);
        }

        public async Task<Message> AddMsg(Guid chatUserId, string messageText)
        {
            return await _messageRepository.AddMsg(chatUserId, messageText);
        }

        public Chat GetChat(Guid chatId)
        {
            return _chatRepository.GetChat(chatId);
        }

        public List<ChatUser> FormChatUserList(Guid newChatId, List<string> ids)
        {
            var guidsList = ids.Select(id => Guid.Parse(id));
            return guidsList.Select(userGuid => new ChatUser
            {
                ChatUserId = Guid.NewGuid(),
                ChatId = newChatId,
                UserId = userGuid
            }).ToList();
        }

        public async Task<bool> AddUsersToChat(List<ChatUser> members)
        {
            return await _chatUserRepository.AddUsersToChat(members);
        }


        public async Task<Guid> AddGroupChat(string chatName, int groupMembers)
        {
            return await _chatRepository.AddGroupChat(chatName, groupMembers);
        }

        public List<ChatElementDTO> GetChats(Guid userId)
        {
            var privateChats = _chatRepository.GetPrivateChats(userId);
            var groupChats = _chatRepository.GetGroupChats(userId);

            return privateChats.Concat(groupChats).ToList();
        }

        public PrivateChatDTO GetPrivateChat(Guid fromId, Guid toId)
        {
            var dialog = _chatRepository.GetPrivateChat(fromId, toId);
            var user = _userRepository.GetUserById(toId);
            if (dialog == null)
                return new PrivateChatDTO
                {
                    UserId = toId.ToString().ToLower(),
                    UserName = user.UserName,
                    ConnectionStatus = user.ConnectionStatus,
                    Messages = new List<MessageDTO>()
                };
            var msgs = _messageRepository.GetDialogMessages(dialog.DialogId);
            return new PrivateChatDTO
            {
                UserId = toId.ToString().ToLower(),
                UserName = user.UserName,
                ConnectionStatus = user.ConnectionStatus,
                Messages = msgs
            };
        }

        public async Task AddMessageInPrivateChat(Guid fromId, Guid toId, string messageText)
        {
            var dialog = _chatRepository.GetPrivateChat(fromId, toId);
            if (dialog == null)
                dialog = await _chatRepository.AddPrivateChat(fromId, toId);
            var addedMessage = await _messageRepository.AddDialogMessage(dialog.DialogId, fromId, messageText);
            _chatRepository.UpdatePrivateChatLastMessage(dialog, addedMessage.MessageId);
        }

        public async Task AddMessageInGroupChat(Guid chatId, Guid senderId, string messageText)
        {
            var chat = GetChat(chatId);
            var chatUser = GetChatUser(chatId, senderId);
            var addedMessage = await AddMsg(chatUser.ChatUserId, messageText);
            _chatRepository.UpdateGroupChatLastMessage(chat, addedMessage.MessageId);
        }
    }
}
