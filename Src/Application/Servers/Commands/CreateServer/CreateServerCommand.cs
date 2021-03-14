using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Data;
using Application.Servers.Models;
using AutoMapper;
using Domain.Models;
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

    public class CreateServerCommandHandler : 
        IRequestHandler<CreateServerCommand, ServerDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserEntityService _userService;
        private readonly IMapper _mapper;

        public CreateServerCommandHandler(
            IApplicationDbContext context, 
            ICurrentUserEntityService userService, 
            IMapper mapper)
        {
            _context = context;
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<ServerDto> Handle(
            CreateServerCommand request, 
            CancellationToken cancellationToken)
        {
            var server = new Server(
                request.ServerName, 
                _userService.GetAttachedUserAsync()!);

            await _context.Servers.AddAsync(server, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ServerDto>(server);
        }
    }
}