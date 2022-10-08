using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramClone.Hubs;
using Microsoft.AspNetCore.Authorization;
using TelegramClone.Services;
using TelegramClone.Models.DTO;

namespace TelegramClone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ChatsController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly UserService _userService;
        private readonly ChatsService _chatService;
        public ChatsController(IHubContext<ChatHub> hubContext, UserService userService, ChatsService chatService)
        {
            _hubContext = hubContext;
            _userService = userService;
            _chatService = chatService;
        }

        [HttpGet]
        public IActionResult GetChats(string userId)
        {
            return Ok(_chatService.GetChats(Guid.Parse(userId)));
        }

        [HttpPost ("addgroupchat")]
        public async Task<IActionResult> AddGroupChat([FromBody] GroupChat groupChat)
        {
            Guid newChatGuid = await _chatService.AddGroupChat(groupChat.groupName, groupChat.membersIds.Count);

            if (newChatGuid != Guid.Empty)
            {
                var chatUserMembers = _chatService.FormChatUserList(newChatGuid,groupChat.membersIds);
                await _chatService.AddUsersToChat(chatUserMembers);
                await _hubContext.Clients.Users(groupChat.membersNames).SendAsync("addGroupChat", groupChat.groupName);
                return Ok();
            }

            return BadRequest("Sometring went wrong..."); 
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(string msg, string to)
        {

            var senderName = _userService.GetCurrentUser(HttpContext).UserName;
            if (senderName != to)
                await _hubContext.Clients.User(to).SendAsync("Send", msg, senderName);
            await _hubContext.Clients.User(senderName).SendAsync("Send", msg,  senderName);
            return Ok();
        }



        [HttpPost ("testmsg")]
        public async Task<IActionResult> TestMessage()
        {
            await _hubContext.Clients.All.SendAsync("Message");
            return Ok();
        }

        [HttpPost("testchats")]
        public async Task<IActionResult> TestChats()
        {
            await _hubContext.Clients.All.SendAsync("Chat");
            return Ok();
        }
    }
}
