using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramClone.Models;
using TelegramClone.Models.DTO;

namespace TelegramClone.Data.Interfaces
{
    public interface IChatRepository
    {
        public Chat GetChat(Guid chatId);
        public Task<Dialog> AddPrivateChat(Guid fromId, Guid toId);
        public Task<Guid> AddGroupChat(string chatName, int groupMembers);
        public List<ChatElementDTO> GetPrivateChats(Guid userId);
        public Dialog GetPrivateChat(Guid firstParticipantId, Guid secondParticipantId);
        public List<ChatElementDTO> GetGroupChats(Guid userId);
        public void UpdatePrivateChatLastMessage(Dialog dialog, Guid lastMessageId);
        public void UpdateGroupChatLastMessage(Chat chat, Guid lastMessageId);
    }
}
