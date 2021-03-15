using System.Threading.Tasks;
using Application.Servers.Models.Hubs.Responses;
using Microsoft.AspNetCore.SignalR;

namespace Application.Servers.Hubs
{
    public class ServerHub : Hub<IServerHub>
    {
        // public async Task JoinServer(JoinServerRequest request)
        // {
        //     //Clients.Caller.JoinedServer()
        // }
    }

    public interface IServerHub
    {
        Task JoinedServer(JoinedServerResponse response);
    }
}