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

using System.Linq;
using Application.Common.Interfaces.Data;

namespace Application.Common.Extensions
{
    public static class DbContextExtensions
    {
        public static bool Attached<T>(this IApplicationDbContext context, T entity)
            where T : class
        {
            return context.Set<T>().Local.Any(e => Equals(e, entity));
        }

        public static T? GetAttached<T>(this IApplicationDbContext context, T entity)
            where T : class
        {
            return context.Set<T>().Local
                .ToList()
                .SingleOrDefault(e => Equals(e, entity));
        }

        public static T EnsureAttached<T>(this IApplicationDbContext context, T entity)
            where T : class
        {
            var attached = GetAttached(context, entity);

            if (attached != null) return attached;

            context.Set<T>().Attach(entity);

            return entity;
        }
    }
}