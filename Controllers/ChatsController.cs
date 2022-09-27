using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramClone.Hubs;
using Microsoft.AspNetCore.Authorization;

namespace TelegramClone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ChatsController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hubContext;
        public ChatsController(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }
        [HttpGet]
        public IActionResult GetChat(string chatId, string initiatorId)
        {
            return Ok(new { chatId = chatId, initiator = initiatorId });
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(string msg, string userName)
        {
            await _hubContext.Clients.All.SendAsync("Send", msg, userName);
            return Ok();
        }
    }
}
