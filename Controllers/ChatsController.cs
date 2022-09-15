using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramClone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ChatsController : ControllerBase
    {
        public IActionResult GetChat(string chatId, string initiatorId)
        {
            return Ok(new { chatId = chatId, initiator = initiatorId });
        }
    }
}
