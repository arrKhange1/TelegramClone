using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramClone.Models.ResponseDTO
{
    public class AuthenticatedUserResponseDTO
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public string AccessToken { get; set; }

        public AuthenticatedUserResponseDTO(Guid userId, string userName, string role, string accessToken)
        {
            UserId = userId;
            UserName = userName;
            Role = role;
            AccessToken = accessToken;
        }

    }
}
