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

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces.Data;
using Application.Common.Mapping;
using Application.Servers.Channels.Models;
using AutoMapper;
using JetBrains.Annotations;
using MediatR;

namespace Application.Servers.Channels.Queries.GetChannels
{
    [UsedImplicitly]
    public class GetChannelsQueryHandler : 
        IRequestHandler<GetChannelsQuery, IEnumerable<ChannelDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetChannelsQueryHandler(
            IApplicationDbContext context, 
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ChannelDto>> Handle(
            GetChannelsQuery request, 
            CancellationToken cancellationToken)
        {
            return await _context.Servers
                .Where(s => s.Id == request.ServerId)
                .SelectMany(s => s.Channels)
                .ProjectToListAsync<ChannelDto>(_mapper.ConfigurationProvider);
        }
    }
}