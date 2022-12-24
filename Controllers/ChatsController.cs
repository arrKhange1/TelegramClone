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
using TelegramClone.Models.ResponseDTO;
using System.Diagnostics;
using TelegramClone.Models.RequestDTO;

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
        public IActionResult GetPrivateChat(string fromId, string toId) // +
        {
            var firstParticipantIdGuid = Guid.Parse(fromId);
            var secondParticipantIdGuid = Guid.Parse(toId);
            var privateChat = _chatService.GetOpenedPrivateChat(firstParticipantIdGuid, secondParticipantIdGuid);
            return Ok(privateChat);
        }

        [HttpGet ("getgroupchat")]
        public IActionResult GetGroupChat(string chatId) // +
        {
            Guid chatIdGuid = Guid.Parse(chatId);
            var groupChat = _chatService.GetOpenedGroupChat(chatIdGuid);
            return Ok(groupChat);
        }

        [HttpGet]
        public IActionResult GetChats(string userId) // +
        {
            var chats = _chatService.GetAllChats(Guid.Parse(userId));
            return Ok(chats);
        }

        [HttpPost ("addgroupchat")]
        public async Task<IActionResult> AddGroupChat([FromBody] GroupChatRequestDTO groupChat) // +
        {
            var createrId = User.Identity.Name;
            var currentUserName = _userService.GetCurrentUser(HttpContext).UserName;

            var addedChat = await _chatService.AddGroupChat(groupChat, Guid.Parse(createrId));
            if (addedChat != null)
            {
                Debug.WriteLine($"isauth: {HttpContext.User.Identity.IsAuthenticated}, name: {User.Identity.Name}"); // в user identity name - userId
                await _hubContext.Clients.Users(groupChat.membersIds).SendAsync("GroupChat", groupChat.groupName, addedChat.GroupChatId.ToString().ToLower(), currentUserName);
                return Ok("Chat was added successfully!");
            }
            return BadRequest("Chat wasn't added"); 
        }

        [HttpPost("sendgroupchat")]
        public async Task<ActionResult> SendMessageInGroupChat(string chatId, string senderId, string messageText) // +
        {
            var chatIdGuid = Guid.Parse(chatId);
            var senderIdGuid = Guid.Parse(senderId);

            var chat = _chatService.GetGroupChat(chatIdGuid);
            var chatMembers = _chatService.GetGroupChatMembers(chatIdGuid);
            var addedMessage = await _chatService.AddMessageInGroupChat(chat, senderIdGuid, messageText, "message");
            var updatedChatMembers = _chatService.IncreaseUnreadMsgsOfGroupChatMembers(chatMembers);

            var senderName = _userService.GetCurrentUser(HttpContext).UserName;
            var chatMembersIds = chatMembers.Select(chatMember => chatMember.UserId.ToString().ToLower()).ToList();
            
            await _hubContext.Clients.Users(chatMembersIds).SendAsync("AddMessageGroupChat", senderName, messageText, chatId);
            
            foreach(var chatMember in updatedChatMembers) {
                int unreadMsgs = chatMember.UserId == senderIdGuid ? 0 : chatMember.UnreadMessages;
                await _hubContext.Clients.User(chatMember.UserId.ToString().ToLower()).SendAsync("NewMsgInChat", new ChatElementResponseDTO(chat.GroupChatId,
                    chat.ChatName, "group", senderName, addedMessage.MessageText, addedMessage.MessageTime, "message", unreadMsgs));
            }
            
            return Ok();
        }

        [HttpPost("sendprivatechat")]
        public async Task<ActionResult> SendMessageInPrivateChat(string fromId, string toId, string toName, string messageText) // +
        {
            var fromIdGuid = Guid.Parse(fromId);
            var toIdGuid = Guid.Parse(toId);

            var privateChat = _chatService.GetPrivateChat(fromIdGuid, toIdGuid);
            if (privateChat == null)
                privateChat = await _chatService.AddPrivateChat(fromIdGuid, toIdGuid);

            var addedMessage = await _chatService.AddMessageInPrivateChat(privateChat, fromIdGuid, toIdGuid, messageText);
            var toIdUnreadMsgs = _chatService.IncreaseUnreadMsgsOfPrivateChat(privateChat, toIdGuid);

            // if add msg ok
            var senderName = _userService.GetCurrentUser(HttpContext).UserName;
            var memberIds = new List<string> { fromId, toId };
            await _hubContext.Clients.Users(memberIds).SendAsync("AddMessagePrivateChat", senderName, messageText, fromId, toId);
            await _hubContext.Clients.User(fromId).SendAsync("NewMsgInChat", new ChatElementResponseDTO(toIdGuid, toName, "private", senderName,
                addedMessage.MessageText, addedMessage.MessageTime, "message", 0));

            await _hubContext.Clients.User(toId).SendAsync("NewMsgInChat", new ChatElementResponseDTO(fromIdGuid, senderName, "private", senderName,
                addedMessage.MessageText, addedMessage.MessageTime, "message", toIdUnreadMsgs));

            return Ok();
        }

        [HttpPut("readprivatechat")]
        public ActionResult ReadPrivateChat(string fromId, string toId) // +
        {
            var fromIdGuid = Guid.Parse(fromId);
            var toIdGuid = Guid.Parse(toId);


            var privateChat = _chatService.GetPrivateChat(fromIdGuid, toIdGuid);
            if (privateChat != null)
                _chatService.CleanUnreadMsgsOfPrivateChat(privateChat, fromIdGuid);
            return Ok();
        }

        [HttpPut("readgroupchat")]
        public ActionResult ReadGroupChat(string fromId, string chatId) // +
        {
            var fromIdGuid = Guid.Parse(fromId);
            var chatIdGuid = Guid.Parse(chatId);

            var chatUser = _chatService.GetGroupChatUser(chatIdGuid, fromIdGuid);
            _chatService.CleanUnreadMsgsOfGroupChatMember(chatUser);
            return Ok();
        }

    }
}
