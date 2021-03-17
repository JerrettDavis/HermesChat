// HermesChat - Simple real-time chat application.
// Copyright (C) 2021  Jerrett D. Davis
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.

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
        private readonly IHubContext<ServerHub, IServerHub> _hubContext;
        private readonly IMapper _mapper;
        private readonly ICurrentUserEntityService _userService;

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
            var user = _userService.GetAttachedUser()!;
            var server = new Server(
                request.ServerName,
                user);
            var channel = new Channel(
                server,
                "general");
            server.AddUser(user);
            server.AddChannel(channel);

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