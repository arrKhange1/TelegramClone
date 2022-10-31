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

        [HttpGet ("getchat")]
        public IActionResult GetChat(string chatId)
        {
            Guid chatIdGuid = Guid.Parse(chatId);
            var chat = _chatService.GetChat(chatIdGuid);
            if (chat == null) // если чата с контактом еще нет
            {
                var user = _userService.GetUserById(chatIdGuid);
                return Ok(new ExpandedChatDTO
                {
                    ChatName = user.UserName,
                    ChatStatus = user.ConnectionStatus,
                    Messages = null
                });
            }
            else // если такой чат существует
            {
                var msgs = _chatService.GetMsgs(chatIdGuid); // получаем сообщения
                var chatCategory = _chatService.GetChatCategoryById(chat.ChatCategoryId);
                if (chatCategory.ChatCategoryName == "private")
                {
                    var user = _userService.GetUserById(chatIdGuid);
                    return Ok(new ExpandedChatDTO
                    {
                        ChatName = user.UserName,
                        ChatStatus = user.ConnectionStatus,
                        Messages = msgs
                    });
                }

                return Ok(new ExpandedChatDTO
                {
                    ChatName = chat.ChatName,
                    ChatStatus = chat.GroupMembers.ToString(),
                    Messages = msgs
                });
                
            }
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
                Debug.WriteLine($"isauth: {HttpContext.User.Identity.IsAuthenticated}, name: {User.Identity.Name}");

                var chatUserMembers = _chatService.FormChatUserList(newChatGuid,groupChat.membersIds);
                await _chatService.AddUsersToChat(chatUserMembers);
                await _hubContext.Clients.Users(groupChat.membersNames).SendAsync("GroupChat", groupChat.groupName);
                
                return Ok();
            }

            return BadRequest("Something went wrong..."); 
        }

    }
}
