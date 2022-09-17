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

        [HttpPost]
        public IActionResult AddContact(string userId, string contactName)
        {
            
        }
    }
}
