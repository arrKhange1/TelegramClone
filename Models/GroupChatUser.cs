using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramClone.Models
{
    public class GroupChatUser
    {
        public Guid GroupChatUserId { get; set; }

        public Guid GroupChatId { get; set; }
        public GroupChat GroupChat { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
        
        public int UnreadMessages { get; set; }


        public GroupChatUser(Guid groupChatId, Guid userId)
        {
            GroupChatUserId = Guid.NewGuid();
            GroupChatId = groupChatId;
            UserId = userId;
        }
    }
}
