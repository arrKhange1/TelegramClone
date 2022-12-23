using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramClone.Models
{
    public class User
    {
        public User(Guid userId, string userName, string userPhoto, string connStatus)
        {
            UserId = userId;
            UserName = userName;
            UserPhoto = userPhoto;
            ConnectionStatus = connStatus;
        }

        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserPhoto { get; set; }
        public string Password { get; set; }
        public string ConnectionStatus { get; set; }

        public Guid? RoleId { get; set; }
        public Role Role { get; set; }

        public List<RefreshToken> RefreshTokens { get; set; }
        public User()
        {
            RefreshTokens = new List<RefreshToken>();
        }

        public List<GroupChatUser> GroupChatUsers { get; set; }

        public List<UserContact> UserContactsUsers { get; set; }
        public List<UserContact> UserContactsContacts { get; set; }

        public List<PrivateChat> PrivateChatsFirstParticipants { get; set; }
        public List<PrivateChat> PrivateChatsSecondParticipants { get; set; }
        public List<PrivateChatMessage> PrivateChatMessages { get; set; }
        public List<GroupChatMessage> GroupChatMessages { get; set; }

    }
}
