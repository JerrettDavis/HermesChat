using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
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
            var roles = new List<Claim>();
            if (!string.IsNullOrEmpty(name?.Value))
            {
                var expandedName = new Claim(ClaimTypes.Name, name.Value);
                
                roles.Add(expandedName);
                roles.Add(name);
            }
            if (email != null)
                roles.Add(email);
            
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