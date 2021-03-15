using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace WebUi.Hubs
{
    [Authorize]
    public class ChatHub : Hub<IChatHub>
    {
        public async Task SendMessage(string message)
        {
            var user = Context.User?.Identity?.Name!;
            await Clients.All.MessageReceived(user, message, DateTime.UtcNow);
        }
    }
}