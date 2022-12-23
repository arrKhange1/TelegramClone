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
            return Ok(new GroupChatResponseDTO
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
        public async Task<IActionResult> AddGroupChat([FromBody] GroupChatRequestDTO groupChat)
        {

            var chat = await _chatService.AddGroupChat(groupChat.groupName, groupChat.membersIds.Count);
            var currentUserId = User.Identity.Name;
            var currentUserName = _userService.GetCurrentUser(HttpContext).UserName;

            if (chat != null)
            {
                Debug.WriteLine($"isauth: {HttpContext.User.Identity.IsAuthenticated}, name: {User.Identity.Name}"); // в user identity name - userId

                var chatMembers = _chatService.FormChatUserList(chat.ChatId, groupChat.membersIds);
                await _chatService.AddUsersToChat(chatMembers);
                await _chatService.AddMessageInGroupChat(chat, Guid.Parse(currentUserId), "created a chat!", "notification");
                _chatService.IncreaseUnreadMsgsOfChatMembers(chatMembers);
                await _hubContext.Clients.Users(groupChat.membersIds).SendAsync("GroupChat", groupChat.groupName, chat.ChatId.ToString().ToLower(), currentUserName);
                
                return Ok();
            }

            return BadRequest("Something went wrong..."); 
        }

        [HttpPost("sendgroupchat")]
        public async Task<ActionResult> SendMessageInGroupChat(string chatId, string senderId, string messageText)
        {
            var chatIdGuid = Guid.Parse(chatId);
            var senderIdGuid = Guid.Parse(senderId);

            var chat = _chatService.GetChat(chatIdGuid);
            var chatMembers = _chatService.GetChatMembers(chatIdGuid);
            var addedMessage = await _chatService.AddMessageInGroupChat(chat, senderIdGuid, messageText, "message");
            var updatedChatMembers = _chatService.IncreaseUnreadMsgsOfChatMembers(chatMembers);

            var senderName = _userService.GetCurrentUser(HttpContext).UserName;
            var chatMembersIds = chatMembers.Select(chatMember => chatMember.UserId.ToString().ToLower()).ToList();
            await _hubContext.Clients.Users(chatMembersIds).SendAsync("AddMessageGroupChat", senderName, messageText, chatId);
            
            foreach(var chatMember in updatedChatMembers) 
                await _hubContext.Clients.User(chatMember.UserId.ToString().ToLower()).SendAsync("NewMsgInChat", new ChatElementResponseDTO
                {
                    ChatId = chat.ChatId,
                    ChatName = chat.ChatName,
                    ChatCategory = "group",
                    LastMessageSender = senderName,
                    LastMessageText = addedMessage.MessageText,
                    LastMessageTime = addedMessage.MessageTime,
                    LastMessageType = "message",
                    UnreadMsgs = chatMember.UserId == senderIdGuid ? 0 : chatMember.UnreadMessages
                }); // add constructor!!!

            return Ok();
        }

        [HttpPost("sendprivatechat")]
        public async Task<ActionResult> SendMessageInPrivateChat(string fromId, string toId, string toName, string messageText)
        {
            var fromIdGuid = Guid.Parse(fromId);
            var toIdGuid = Guid.Parse(toId);

            var dialog = _chatService.GetDialog(fromIdGuid, toIdGuid);
            if (dialog == null)
                dialog = await _chatService.AddPrivateChat(fromIdGuid, toIdGuid);

            var addedMessage = await _chatService.AddMessageInPrivateChat(dialog, fromIdGuid, toIdGuid, messageText);
            var toIdUnreadMsgs = _chatService.IncreaseUnreadMsgsOfDialog(dialog, toIdGuid);

            // if add msg ok
            var memberIds = new List<string> { fromId, toId };
            var senderName = _userService.GetCurrentUser(HttpContext).UserName;
            await _hubContext.Clients.Users(memberIds).SendAsync("AddMessagePrivateChat", senderName, messageText, fromId, toId);
            
            await _hubContext.Clients.User(fromId).SendAsync("NewMsgInChat", new ChatElementResponseDTO
            {
                ChatId = toIdGuid,
                ChatName = toName,
                ChatCategory = "private",
                LastMessageSender = senderName,
                LastMessageText = addedMessage.MessageText,
                LastMessageTime = addedMessage.MessageTime,
                LastMessageType = "message",
                UnreadMsgs = 0
            });
            await _hubContext.Clients.User(toId).SendAsync("NewMsgInChat", new ChatElementResponseDTO
            {
                ChatId = fromIdGuid,
                ChatName = senderName,
                ChatCategory = "private",
                LastMessageSender = senderName,
                LastMessageText = addedMessage.MessageText,
                LastMessageTime = addedMessage.MessageTime,
                LastMessageType = "message",
                UnreadMsgs = toIdUnreadMsgs
            });

            return Ok();
        }

        [HttpPut("readprivatechat")]
        public ActionResult ReadPrivateChat(string fromId, string toId)
        {
            var fromIdGuid = Guid.Parse(fromId);
            var toIdGuid = Guid.Parse(toId);

            var dialog = _chatService.GetDialog(fromIdGuid, toIdGuid);
            _chatService.CleanUnreadMsgsOfDialog(dialog, fromIdGuid);
            return Ok();
        }

        [HttpPut("readgroupchat")]
        public ActionResult ReadGroupChat(string fromId, string chatId)
        {
            var fromIdGuid = Guid.Parse(fromId);
            var chatIdGuid = Guid.Parse(chatId);

            var chatUser = _chatService.GetChatUser(chatIdGuid, fromIdGuid);
            _chatService.CleanUnreadMsgsOfChatMember(chatUser);
            return Ok();
        }

    }
}
