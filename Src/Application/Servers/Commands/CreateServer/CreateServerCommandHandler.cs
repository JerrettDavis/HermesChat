using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Data;
using Application.Servers.Hubs;
using Application.Servers.Models;
using Application.Servers.Models.Hubs.Responses;
using AutoMapper;
using Domain.Models;
using JetBrains.Annotations;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace Application.Servers.Commands.CreateServer
{
    [UsedImplicitly]
    public class CreateServerCommandHandler : 
        IRequestHandler<CreateServerCommand, ServerDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserEntityService _userService;
        private readonly IMapper _mapper;
        private readonly IHubContext<ServerHub, IServerHub> _hubContext;

        public CreateServerCommandHandler(
            IApplicationDbContext context, 
            ICurrentUserEntityService userService, 
            IMapper mapper, 
            IHubContext<ServerHub, IServerHub> hubContext)
        {
            _context = context;
            _userService = userService;
            _mapper = mapper;
            _hubContext = hubContext;
        }

        public async Task<ServerDto> Handle(
            CreateServerCommand request, 
            CancellationToken cancellationToken)
        {
            var user = _userService.GetAttachedUserAsync()!;
            var server = new Server(
                request.ServerName, 
                user);
            server.AddUser(user);

            await _context.Servers.AddAsync(server, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            await _hubContext.Clients.User(user.Id).JoinedServer(
                new JoinedServerResponse
                {
                    ServerId = server.Id, 
                    ServerName = server.Name
                });
            
            return _mapper.Map<ServerDto>(server);
        }
    }
}