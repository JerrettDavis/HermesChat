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
using System.Threading.Tasks;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Mapping
{
    public static class MappingExtensions
    {
        public static Task<PaginatedList<TDestination>>
            PaginatedListAsync<TDestination>(
                this IQueryable<TDestination> queryable,
                int pageNumber,
                int pageSize)
        {
            return PaginatedList<TDestination>.CreateAsync(
                queryable,
                pageNumber,
                pageSize);
        }

        public static Task<List<TDestination>>
            ProjectToListAsync<TDestination>(
                this IQueryable queryable,
                IConfigurationProvider configuration)
        {
            return queryable.ProjectTo<TDestination>(configuration).ToListAsync();
        }
    }
}