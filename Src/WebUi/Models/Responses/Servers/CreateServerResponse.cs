using Application.Servers.Models;
using JetBrains.Annotations;

namespace WebUi.Models.Responses.Servers
{
    [PublicAPI]
    public class CreateServerResponse
    {
        public CreateServerResponse(ServerDto server)
        {
            Server = server;
        }

        public ServerDto Server { get; }
    }
}