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
using Application.Common.Interfaces;
using Application.Common.Interfaces.Data;
using Application.Common.Mapping;
using Application.Servers.Models;
using AutoMapper;
using JetBrains.Annotations;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Servers.Queries.GetCurrentUserServers
{
    [UsedImplicitly]
    public class GetCurrentUserServersQueryHandler : 
        IRequestHandler<GetCurrentUserServersQuery, IEnumerable<ServerDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserEntityService _entityService;
        private readonly IMapper _mapper;

        public GetCurrentUserServersQueryHandler(
            IApplicationDbContext context, 
            ICurrentUserEntityService entityService, 
            IMapper mapper)
        {
            _context = context;
            _entityService = entityService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ServerDto>> Handle(
            GetCurrentUserServersQuery request, 
            CancellationToken cancellationToken)
        {
            var user = _entityService.GetAttachedUser();
            return await _context.Users
                .Include(u => u.ServerUsers)
                .Where(u => Equals(u, user))
                .SelectMany(u => u.ServerUsers.Select(su => su.Server))
                .ProjectToListAsync<ServerDto>(_mapper.ConfigurationProvider);
        }
    }
}