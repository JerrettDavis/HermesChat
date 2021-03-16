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
using Application.Servers.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using JetBrains.Annotations;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Servers.Queries.GetServer
{
    [UsedImplicitly]
    public class GetServerQueryHandler : 
        IRequestHandler<GetServerQuery, ServerDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetServerQueryHandler(
            IApplicationDbContext context, 
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<ServerDto> Handle(
            GetServerQuery request, 
            CancellationToken cancellationToken)
        {
            return _context.Servers
                .ProjectTo<ServerDto>(_mapper.ConfigurationProvider)
                .SingleAsync(s => s.Id == request.ServerId, cancellationToken);
        }
    }
}