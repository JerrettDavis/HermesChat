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
using System.Security.Claims;
using System.Threading.Tasks;
using Application.Common.Claims;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services;
using JetBrains.Annotations;

namespace Infrastructure.Services
{
    [UsedImplicitly]
    public class ProfileService : IProfileService
    {
        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var email = context.Subject.FindFirst(JwtClaimTypes.Email);
            var name = context.Subject.FindFirst(JwtClaimTypes.Name);
            var identifier = context.Subject.FindFirst(ApplicationClaimTypes.UserIdentifier);

            var roles = new List<Claim>();
            if (!string.IsNullOrEmpty(name?.Value))
            {
                var expandedName = new Claim(ClaimTypes.Name, name.Value);

                roles.Add(expandedName);
                roles.Add(name);
            }

            if (email != null)
                roles.Add(email);

            if (identifier != null)
                roles.Add(identifier);

            context.IssuedClaims.AddRange(roles);
            return Task.CompletedTask;
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            // TODO: Implement this
            return Task.CompletedTask;
        }
    }
}