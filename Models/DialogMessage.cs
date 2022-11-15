using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramClone.Models
{
    public class DialogMessage
    {
        [Key]
        public Guid MessageId { get; set; }
        public Guid SenderId { get; set; }
        public User Sender { get; set; }
        public Guid DialogId { get; set; }
        public Dialog Dialog { get; set; }
        public string MessageText { get; set; }
    }
}
