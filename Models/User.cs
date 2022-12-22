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

        public List<ChatUser> ChatUsers { get; set; }

        public List<UserContact> UserContactsUsers { get; set; }
        public List<UserContact> UserContactsContacts { get; set; }

        public List<Dialog> DialogsFirstParticipants { get; set; }
        public List<Dialog> DialogsSecondParticipants { get; set; }
        public List<DialogMessage> DialogMessages { get; set; }
        public List<Message> Messages { get; set; }

    }
}
