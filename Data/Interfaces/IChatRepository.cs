using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramClone.Models;
using TelegramClone.Models.ResponseDTO;

namespace TelegramClone.Data.Interfaces
{
    public interface IChatRepository
    {
        public GroupChat GetGroupChat(Guid groupChatId);
        public Task<PrivateChat> AddPrivateChat(Guid fromId, Guid toId);
        public Task<GroupChat> AddGroupChat(string chatName, int groupMembers);
        public List<ChatElementResponseDTO> GetPrivateChats(Guid userId);
        public PrivateChat GetPrivateChat(Guid firstParticipantId, Guid secondParticipantId);
        public List<ChatElementResponseDTO> GetGroupChats(Guid userId);
        public void UpdatePrivateChatLastMessage(PrivateChat privateChat, Guid lastMessageId);
        public void UpdateGroupChatLastMessage(GroupChat groupChat, Guid lastMessageId);
        public int IncreaseUnreadMsgsOfPrivateChat(PrivateChat privateChat, Guid toId);
        public void CleanUnreadMsgsOfPrivateChat(PrivateChat privateChat, Guid fromId);
    }
}
