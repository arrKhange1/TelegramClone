using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TelegramClone.Data.Interfaces;
using TelegramClone.Models;
using TelegramClone.Models.RequestDTO;
using TelegramClone.Models.ResponseDTO;

namespace TelegramClone.Services
{
    public class ChatsService
    {
        private readonly IChatRepository _chatRepository;
        private readonly IGroupChatUserRepository _chatUserRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly IChatCategoryRepository _chatCategoryRepository;
        private readonly IUserRepository _userRepository;

        public ChatsService(IChatRepository chatRepository, IGroupChatUserRepository chatUserRepository,
            IMessageRepository messageRepository, IChatCategoryRepository chatCategoryRepository,
            IUserRepository userRepository)
        {
            _chatRepository = chatRepository;
            _chatUserRepository = chatUserRepository;
            _messageRepository = messageRepository;
            _chatCategoryRepository = chatCategoryRepository;
            _userRepository = userRepository;
        }

        public List<GroupChatUser> GetGroupChatMembers(Guid chatId)
        {
            return _chatUserRepository.GetGroupChatMembers(chatId);
        }

        public List<GroupChatUser> IncreaseUnreadMsgsOfGroupChatMembers(List<GroupChatUser> chatMembers)
        {
            return _chatUserRepository.IncreaseUnreadMsgsOfGroupChatMembers(chatMembers);
        }

        public int IncreaseUnreadMsgsOfPrivateChat(PrivateChat privateChat, Guid toId)
        {
            return _chatRepository.IncreaseUnreadMsgsOfPrivateChat(privateChat, toId);
        }
        public void CleanUnreadMsgsOfGroupChatMember(GroupChatUser chatUser)
        {
            _chatUserRepository.CleanUnreadMsgsOfGroupChatMember(chatUser);
        }

        public void CleanUnreadMsgsOfPrivateChat(PrivateChat privateChat, Guid fromId)
        {
            _chatRepository.CleanUnreadMsgsOfPrivateChat(privateChat, fromId);
        }

        public GroupChatUser GetGroupChatUser(Guid chatId, Guid userId)
        {
            return _chatUserRepository.GetGroupChatUserByChatIdAndUserId(chatId, userId);
        }

        public ChatCategory GetGroupChatCategoryById(Guid chatCategoryId)
        {
            return _chatCategoryRepository.GetChatCategoryById(chatCategoryId);
        }

        public async Task<GroupChatMessage> AddGroupChatMsg(Guid chatId, Guid userId, string messageText, string messageType)
        {
            return await _messageRepository.AddGroupChatMsg(chatId, userId, messageText, messageType);
        }

        public GroupChat GetGroupChat(Guid chatId)
        {
            return _chatRepository.GetGroupChat(chatId);
        }

        public GroupChatResponseDTO GetOpenedGroupChat(Guid chatId)
        {
            GroupChat groupChat = GetGroupChat(chatId);
            var msgs = _messageRepository.GetGroupChatMsgs(chatId);
            return new GroupChatResponseDTO
            {
                ChatName = groupChat.ChatName,
                GroupMembers = groupChat.GroupMembers,
                Messages = msgs
            };
        }

        public List<GroupChatUser> FormGroupChatUserList(Guid newChatId, List<string> ids)
        {
            var guidsList = ids.Select(id => Guid.Parse(id));
            return guidsList.Select(userGuid => new GroupChatUser
            {
                GroupChatUserId = Guid.NewGuid(),
                GroupChatId = newChatId,
                UserId = userGuid
            }).ToList();
        }

        public async Task<GroupChat> AddGroupChat(GroupChatRequestDTO groupChatRequestDTO, Guid createrId)
        {
            try
            {
                var groupChat = await _chatRepository.AddGroupChat(groupChatRequestDTO.groupName, groupChatRequestDTO.membersIds.Count);
                var chatMembers = FormGroupChatUserList(groupChat.GroupChatId, groupChatRequestDTO.membersIds);
                await _chatUserRepository.AddUsersToGroupChat(chatMembers);
                await AddMessageInGroupChat(groupChat, createrId, "created a chat!", "notification");
                _chatUserRepository.IncreaseUnreadMsgsOfGroupChatMembers(chatMembers);
                return groupChat;
            }
            catch
            {
                return null;
            }
        }

        public async Task<PrivateChat> AddPrivateChat(Guid fromId, Guid toId)
        {
            return await _chatRepository.AddPrivateChat(fromId, toId);
        }

        public List<ChatElementResponseDTO> GetAllChats(Guid userId)
        {
            var privateChats = _chatRepository.GetPrivateChats(userId);
            var groupChats = _chatRepository.GetGroupChats(userId);

            var chats = privateChats.Concat(groupChats).ToList();
            chats.Sort();

            return chats;
        }

        public PrivateChatResponseDTO GetOpenedPrivateChat(Guid fromId, Guid toId)
        {
            var privateChat = _chatRepository.GetPrivateChat(fromId, toId);
            var user = _userRepository.GetUserById(toId);
            if (privateChat == null)
                return new PrivateChatResponseDTO
                {
                    UserId = toId.ToString().ToLower(),
                    UserName = user.UserName,
                    ConnectionStatus = user.ConnectionStatus,
                    Messages = new List<MessageResponseDTO>()
                };
            var msgs = _messageRepository.GetPrivateChatMessages(privateChat.PrivateChatId);
            return new PrivateChatResponseDTO
            {
                UserId = toId.ToString().ToLower(),
                UserName = user.UserName,
                ConnectionStatus = user.ConnectionStatus,
                Messages = msgs
            };
        }

        public PrivateChat GetPrivateChat(Guid fromId, Guid toId)
        {
            var privateChat = _chatRepository.GetPrivateChat(fromId, toId);
            return privateChat;
        }

        public async Task<PrivateChatMessage> AddMessageInPrivateChat(PrivateChat privateChat, Guid fromId, Guid toId, string messageText)
        {
            var addedMessage = await _messageRepository.AddPrivateChatMessage(privateChat.PrivateChatId, fromId, messageText);
            _chatRepository.UpdatePrivateChatLastMessage(privateChat, addedMessage.PrivateChatMessageId);

            return addedMessage;
        }

        public async Task<GroupChatMessage> AddMessageInGroupChat(GroupChat groupChat, Guid senderId, string messageText, string messageType)
        {
            var addedMessage = await AddGroupChatMsg(groupChat.GroupChatId, senderId, messageText, messageType);
            _chatRepository.UpdateGroupChatLastMessage(groupChat, addedMessage.GroupChatMessageId);

            return addedMessage;
        }
    }
}
