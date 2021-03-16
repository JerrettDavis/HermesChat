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
using Application.Common.Extensions;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Data;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace WebUi.Services
{
    public class CurrentUserEntityService : ICurrentUserEntityService
    {
        private readonly IApplicationDbContext _context;
        private readonly string? _userId;

        public CurrentUserEntityService(
            ICurrentUserService userService,
            IApplicationDbContext context)
        {
            _context = context;
            _userId = userService.UserId;
        }

        public Task<ApplicationUser?> GetLoadedUserAsync(
            CancellationToken cancellationToken)
        {
            if (_userId == null)
                return Task.FromResult((ApplicationUser) null!)!;

            return _context.Users.SingleOrDefaultAsync(u => u.Id == _userId,
                cancellationToken)!;
        }

        public ApplicationUser? GetAttachedUser()
        {
            if (_userId == null)
                return null;

            var user = new ApplicationUser {Id = _userId};

            _context.EnsureAttached(user);

            return user;
        }
    }
}