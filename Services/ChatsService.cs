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

        public List<ChatUser> GetChatMembers(Guid chatId)
        {
            return _chatUserRepository.GetChatMembers(chatId);
        }

        public List<ChatUser> IncreaseUnreadMsgsOfChatMembers(List<ChatUser> chatMembers)
        {
            return _chatUserRepository.IncreaseUnreadMsgsOfChatMembers(chatMembers);
        }

        public int IncreaseUnreadMsgsOfDialog(Dialog dialog, Guid toId)
        {
            return _chatRepository.IncreaseUnreadMsgsOfDialog(dialog, toId);
        }
        public void CleanUnreadMsgsOfChatMember(ChatUser chatUser)
        {
            _chatUserRepository.CleanUnreadMsgsOfChatMember(chatUser);
        }

        public void CleanUnreadMsgsOfDialog(Dialog dialog, Guid fromId)
        {
            _chatRepository.CleanUnreadMsgsOfDialog(dialog, fromId);
        }

        public ChatUser GetChatUser(Guid chatId, Guid userId)
        {
            return _chatUserRepository.GetChatUserByChatIdAndUserId(chatId, userId);
        }

        public ChatCategory GetChatCategoryById(Guid chatCategoryId)
        {
            return _chatCategoryRepository.GetChatCategoryById(chatCategoryId);
        }

        public async Task<Message> AddMsg(Guid chatId, Guid userId, string messageText, string messageType)
        {
            return await _messageRepository.AddMsg(chatId, userId, messageText, messageType);
        }

        public Chat GetChat(Guid chatId)
        {
            return _chatRepository.GetChat(chatId);
        }

        public GroupChatResponseDTO GetGroupChat(Guid chatId)
        {
            Chat chat = _chatRepository.GetChat(chatId); // mb vernut method v service
            var msgs = _messageRepository.GetMsgs(chatId);
            return new GroupChatResponseDTO
            {
                ChatName = chat.ChatName,
                GroupMembers = chat.GroupMembers.ToString(),
                Messages = msgs
            };
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

        public async Task<Chat> AddGroupChat(GroupChatRequestDTO groupChatRequestDTO, Guid createrId)
        {
            try
            {
                var chat = await _chatRepository.AddGroupChat(groupChatRequestDTO.groupName, groupChatRequestDTO.membersIds.Count);
                var chatMembers = FormChatUserList(chat.ChatId, groupChatRequestDTO.membersIds);
                await _chatUserRepository.AddUsersToChat(chatMembers);
                await AddMessageInGroupChat(chat, createrId, "created a chat!", "notification");
                _chatUserRepository.IncreaseUnreadMsgsOfChatMembers(chatMembers);
                return chat;
            }
            catch
            {
                return null;
            }
        }

        public async Task<Dialog> AddPrivateChat(Guid fromId, Guid toId)
        {
            return await _chatRepository.AddPrivateChat(fromId, toId);
        }

        public List<ChatElementResponseDTO> GetChats(Guid userId)
        {
            var privateChats = _chatRepository.GetPrivateChats(userId);
            var groupChats = _chatRepository.GetGroupChats(userId);

            var chats = privateChats.Concat(groupChats).ToList();
            chats.Sort();

            return chats;
        }

        public PrivateChatResponseDTO GetPrivateChat(Guid fromId, Guid toId)
        {
            var dialog = _chatRepository.GetPrivateChat(fromId, toId);
            var user = _userRepository.GetUserById(toId);
            if (dialog == null)
                return new PrivateChatResponseDTO
                {
                    UserId = toId.ToString().ToLower(),
                    UserName = user.UserName,
                    ConnectionStatus = user.ConnectionStatus,
                    Messages = new List<MessageResponseDTO>()
                };
            var msgs = _messageRepository.GetDialogMessages(dialog.DialogId);
            return new PrivateChatResponseDTO
            {
                UserId = toId.ToString().ToLower(),
                UserName = user.UserName,
                ConnectionStatus = user.ConnectionStatus,
                Messages = msgs
            };
        }

        public Dialog GetDialog(Guid fromId, Guid toId)
        {
            var dialog = _chatRepository.GetPrivateChat(fromId, toId);
            return dialog;
        }

        public async Task<DialogMessage> AddMessageInPrivateChat(Dialog dialog, Guid fromId, Guid toId, string messageText)
        {
            var addedMessage = await _messageRepository.AddDialogMessage(dialog.DialogId, fromId, messageText);
            _chatRepository.UpdatePrivateChatLastMessage(dialog, addedMessage.MessageId);

            return addedMessage;
        }

        public async Task<Message> AddMessageInGroupChat(Chat chat, Guid senderId, string messageText, string messageType)
        {
            var addedMessage = await AddMsg(chat.ChatId, senderId, messageText, messageType);
            _chatRepository.UpdateGroupChatLastMessage(chat, addedMessage.MessageId);

            return addedMessage;
        }
    }
}
