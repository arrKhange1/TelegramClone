using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramClone.Models
{
    public class RefreshToken
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string Token { get; set; }
        public bool isActive { get; set; } = true;
        public DateTime? ExpireDate { get; set; }

        [NotMapped]
        public bool IsExpired { get { return ExpireDate.Value.ToUniversalTime() <= DateTime.UtcNow; } }
    }
}
