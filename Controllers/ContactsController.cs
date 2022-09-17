using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramClone.Services;

namespace TelegramClone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactsService _contactsService;
        private readonly UserService _userService;

        public ContactsController(ContactsService contactsService, UserService userService)
        {
            _contactsService = contactsService;
            _userService = userService;
        }

        [HttpPost(template: "add")]
        public IActionResult AddContact(string userId, string contactName)
        {
            var contact = _userService.GetUserByUserName(contactName);
            if (contact != null)
            {
                _contactsService.AddContact(Guid.Parse(userId), contact.UserId);
                return Ok();
            }
            else
                return BadRequest();
        }

        [HttpGet(template: "get")]
        public IActionResult GetContacts(string userId)
        {
            return Ok(_contactsService.GetContacts(Guid.Parse(userId)));
        }

    }
}
