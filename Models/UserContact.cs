using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramClone.Models
{
    [Index(nameof(UserId), nameof(ContactId), IsUnique = true)]
    public class UserContact
    {
        public Guid UserContactId { get; set; }
        public Guid UserId { get; set; }
        public Guid ContactId { get; set; }
        
        public DateTime CreateTime { get; set; }
        public User Contact { get; set; }
        public User User { get; set; }

    }
}
