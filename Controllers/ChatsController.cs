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
using System.Diagnostics;
using System.Security.Claims;

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



        [HttpGet("getprivatechat")]
        public IActionResult GetPrivateChat(string fromId, string toId)
        {
            var firstParticipantIdGuid = Guid.Parse(fromId);
            var secondParticipantIdGuid = Guid.Parse(toId);
            var dialog = _chatService.GetPrivateChat(firstParticipantIdGuid, secondParticipantIdGuid);
            return Ok(dialog);
        }

        [HttpGet ("getgroupchat")]
        public IActionResult GetGroupChat(string chatId)
        {
            Guid chatIdGuid = Guid.Parse(chatId);
            var chat = _chatService.GetChat(chatIdGuid);
            
            var msgs = _chatService.GetMsgs(chatIdGuid); // получаем сообщения
            return Ok(new GroupChatDTO
            {
                ChatName = chat.ChatName,
                GroupMembers = chat.GroupMembers.ToString(),
                Messages = msgs
            });
        }

        [HttpGet]
        public IActionResult GetChats(string userId)
        {
            var chats = _chatService.GetChats(Guid.Parse(userId));
            return Ok(chats);
        }

        [HttpPost ("addgroupchat")]
        public async Task<IActionResult> AddGroupChat([FromBody] GroupChat groupChat)
        {

            Guid newChatGuid = await _chatService.AddGroupChat(groupChat.groupName, groupChat.membersIds.Count);

            if (newChatGuid != Guid.Empty)
            {
                Debug.WriteLine($"isauth: {HttpContext.User.Identity.IsAuthenticated}, name: {User.Identity.Name}"); // в user identity name - userId

                var chatUserMembers = _chatService.FormChatUserList(newChatGuid,groupChat.membersIds);
                await _chatService.AddUsersToChat(chatUserMembers);
                await _hubContext.Clients.Users(groupChat.membersIds).SendAsync("GroupChat", groupChat.groupName, newChatGuid.ToString().ToLower());
                
                return Ok();
            }

            return BadRequest("Something went wrong..."); 
        }

        [HttpPost("sendgroupchat")]
        public async Task<ActionResult> SendMessageInGroupChat(string chatId, string senderId, string messageText)
        {
            var chatIdGuid = Guid.Parse(chatId);
            var senderIdGuid = Guid.Parse(senderId);

            await _chatService.AddMessageInGroupChat(chatIdGuid, senderIdGuid, messageText);
            var memberIds = _chatService.GetChatMemberIds(chatIdGuid);

            var senderName = _userService.GetCurrentUser(HttpContext).UserName;
            await _hubContext.Clients.Users(memberIds).SendAsync("AddMessageGroupChat", senderName, messageText, chatId);

            return Ok(memberIds);
        }

        [HttpPost("sendprivatechat")]
        public async Task<ActionResult> SendMessageInPrivateChat(string fromId, string toId, string messageText)
        {
            var fromIdGuid = Guid.Parse(fromId);
            var toIdGuid = Guid.Parse(toId);

            await _chatService.AddMessageInPrivateChat(fromIdGuid, toIdGuid, messageText);

            // if add msg ok
            var memberIds = new List<string>
            {
                fromId,
                toId
            };
            var senderName = _userService.GetCurrentUser(HttpContext).UserName;
            await _hubContext.Clients.Users(memberIds).SendAsync("AddMessagePrivateChat", senderName, messageText, fromId, toId);

            return Ok();
        }

    }
}
