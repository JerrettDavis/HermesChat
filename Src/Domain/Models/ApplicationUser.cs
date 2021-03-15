using System.Collections.Generic;
using Domain.Common.Attributes;
using Microsoft.AspNetCore.Identity;

namespace Domain.Models
{
    [IsEntity]
    public sealed class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            ServerUsers = new HashSet<ServerUser>();
        }
        
        public string UserIdentifier { get; set; } = null!;
        
        public ICollection<ServerUser> ServerUsers { get; }
    }
}