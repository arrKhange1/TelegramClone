using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramClone.Hubs
{
    public class ChatHub: Hub
    {
        public async Task Send(string msg, string username)
        {
            await this.Clients.All.SendAsync("Send", msg, username);
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("Send", "вошел в чат",  $"{Context.ConnectionId}");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception ex)
        {
            await Clients.All.SendAsync("Send", "вышел из чата", $"{Context.ConnectionId}");
            await base.OnDisconnectedAsync(ex);
        }
    }
}
