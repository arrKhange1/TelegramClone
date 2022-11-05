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
        public IActionResult GetPrivateChat(string chatId)
        {
            Guid chatIdGuid = Guid.Parse(chatId);
            var chat = _chatService.GetChat(chatIdGuid);
            var user = _userService.GetUserById(chatIdGuid);
            if (chat == null) // если чата с контактом еще нет
            {
                return Ok(new PrivateChatDTO
                {
                    UserName = user.UserName,
                    ConnectionStatus = user.ConnectionStatus,
                    Messages = new List<MessageDTO>()
                });
            }
            else // если такой чат существует
            {
                var msgs = _chatService.GetMsgs(chatIdGuid); // получаем сообщения
                return Ok(new PrivateChatDTO
                {
                    UserName = user.UserName,
                    ConnectionStatus = user.ConnectionStatus,
                    Messages = msgs
                });
            }
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
            return Ok(_chatService.GetChats(Guid.Parse(userId)));
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

            var chatUser = _chatService.GetChatUser(chatIdGuid, senderIdGuid);
            await _chatService.AddMsg(chatUser.ChatUserId, messageText);
            var memberIds = _chatService.GetChatMemberIds(chatIdGuid);

            var senderName = _userService.GetCurrentUser(HttpContext).UserName;
            await _hubContext.Clients.Users(memberIds).SendAsync("AddMessageGroupChat", senderName, messageText);

            return Ok(memberIds);
        }

    }
}
