using Application.Common.Mapping;
using Application.Common.Models;
using Domain.Models;

namespace Application.Servers.Models
{
    public class ServerDto : AuditableDto, IMapFrom<Server>
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string OwnerId { get; set; } = null!;
    }
}