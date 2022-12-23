using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramClone.Models.ResponseDTO;
using TelegramClone.Services;

namespace TelegramClone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
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
        public async Task<IActionResult> AddContact(string userId, string contactName)
        {
            var contact = _userService.GetUserByUserName(contactName);
            Guid userIdFromString = Guid.Parse(userId);

            if (contact != null)
            {
                if (userIdFromString == contact.UserId)
                    return BadRequest("Trying to add yourself");

                var addStatus = await _contactsService.AddContact(userIdFromString, contact.UserId);
                if (addStatus)
                    return Ok(new ContactElementResponseDTO
                    {
                        ContactId = contact.UserId,
                        ContactName = contactName
                    });
                return BadRequest("Contact already exists");
            }
            else
                return BadRequest("No such user");
        }

        [HttpGet]
        public IActionResult GetContacts(string userId)
        {
            return Ok(_contactsService.GetContacts(Guid.Parse(userId)));
        }

    }
}
