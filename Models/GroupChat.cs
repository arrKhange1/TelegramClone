using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramClone.Models
{
    public class GroupChat
    {
        public Guid GroupChatId { get; set; }
        public string ChatName { get; set; }
        public int GroupMembers { get; set; }
        public Guid ChatCategoryId { get; set; }
        public ChatCategory ChatCategory { get; set; }
        public DateTime CreateTime { get; set; }
        public List<GroupChatUser> GroupChatUsers { get; set; }
        public List<GroupChatMessage> GroupChatMessages { get; set; }

        public Guid? LastMessageId { get; set; }
        public GroupChatMessage LastMessage { get; set; }

        public GroupChat(string chatName, int groupMembers, Guid chatCategoryId, DateTime createTime)
        {
            GroupChatId = Guid.NewGuid();
            ChatName = chatName;
            GroupMembers = groupMembers;
            ChatCategoryId = chatCategoryId;
            CreateTime = createTime;
        }
    }
}
