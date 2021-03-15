using Domain.Common.Attributes;
// ReSharper disable MemberInitializerValueIgnored

namespace Domain.Models
{
    [IsEntity]
    public class ServerUser : AuditableEntity
    {
        private ServerUser(string serverId, string userId)
        {
            ServerId = serverId;
            UserId = userId;
        }

        public ServerUser(Server server, ApplicationUser user) :
            this(server.Id, user.Id)
        {
            Server = server;
            User = user;
        }

        public string ServerId { get; }
        public string UserId { get; }

        public Server Server { get; } = null!;
        public ApplicationUser User { get; } = null!;
    }
}