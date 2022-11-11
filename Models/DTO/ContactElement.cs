using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramClone.Models.DTO
{
    public class ContactElement // response
    {
        public Guid ContactId { get; set; }
        public string ContactName { get; set; }
        public string ContactPhoto { get; set; }
        public string ConnectionStatus { get; set; }
        public string ChatCategory { get; set; }
    }
}
