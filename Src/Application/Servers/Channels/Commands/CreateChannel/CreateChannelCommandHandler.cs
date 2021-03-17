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
using Application.Common.Interfaces.Data;
using Application.Servers.Channels.Models;
using AutoMapper;
using Domain.Models;
using JetBrains.Annotations;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Servers.Channels.Commands.CreateChannel
{
    [UsedImplicitly]
    public class CreateChannelCommandHandler : 
        IRequestHandler<CreateChannelCommand, ChannelDto>
    {
        private readonly IApplicationDbContext _context;
        public readonly IMapper _mapper;

        public CreateChannelCommandHandler(
            IApplicationDbContext context, 
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ChannelDto> Handle(
            CreateChannelCommand request, 
            CancellationToken cancellationToken)
        {
            var server = await _context.Servers
                .SingleAsync(s => s.Id == request.ServerId,
                    cancellationToken);
            var channel = new Channel(server, request.Input.Name)
            {
                Topic = request.Input.Topic,
                Nsfw = request.Input.Nsfw
            };
            server.AddChannel(channel);

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ChannelDto>(channel);
        }
    }
}