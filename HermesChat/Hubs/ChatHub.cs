using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace HermesChat.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string message)
        {
            var user = Context.User?.Identity?.Name;
            await Clients.All.SendAsync("MessageReceived", user, message, DateTime.UtcNow);
        }
    }
}