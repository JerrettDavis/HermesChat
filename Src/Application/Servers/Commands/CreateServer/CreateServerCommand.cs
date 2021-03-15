using Application.Servers.Models;
using MediatR;

namespace Application.Servers.Commands.CreateServer
{
    public class CreateServerCommand : IRequest<ServerDto>
    {
        public CreateServerCommand(string serverName)
        {
            ServerName = serverName;
        }

        public string ServerName { get; }
    }
}