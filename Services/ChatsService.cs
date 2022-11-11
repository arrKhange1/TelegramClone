using System;
using System.Collections.Generic;
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

        public ChatsService(IChatRepository chatRepository, IChatUserRepository chatUserRepository, 
            IMessageRepository messageRepository, IChatCategoryRepository chatCategoryRepository)
        {
            _chatRepository = chatRepository;
            _chatUserRepository = chatUserRepository;
            _messageRepository = messageRepository;
            _chatCategoryRepository = chatCategoryRepository;
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

        public async Task<List<ChatUser>> AddPrivateChat(Guid chatId, List<string> members)
        {
            await _chatRepository.AddPrivateChat(chatId);
            var chatUserMembers = FormChatUserList(chatId, members);
            await AddUsersToChat(chatUserMembers);
            return chatUserMembers;
        }

        public async Task<Guid> AddGroupChat(string chatName, int groupMembers)
        {
            return await _chatRepository.AddGroupChat(chatName, groupMembers);
        }

        public List<ChatElementDTO> GetChats(Guid userId)
        {
            return _chatRepository.GetChats(userId);
        }
    }
}
