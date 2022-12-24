using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramClone.Models.ResponseDTO
{
    public class ContactElementResponseDTO
    {
        public Guid ContactId { get; set; }
        public string ContactName { get; set; }

        public ContactElementResponseDTO(Guid contactId, string contactName)
        {
            ContactId = contactId;
            ContactName = contactName;
        }
    }
}
