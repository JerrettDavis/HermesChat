using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Extensions;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Data;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;

namespace WebUi.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IApplicationDbContext _context;
        
        public CurrentUserService(
            IHttpContextAccessor httpContextAccessor, 
            IApplicationDbContext context)
        {
            _context = context;
            UserId = httpContextAccessor.HttpContext?.User
                .FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public string? UserId { get; }
        public Task<ApplicationUser?> GetLoadedUserAsync(
            CancellationToken cancellationToken)
        {
            if (UserId == null)
                return Task.FromResult((ApplicationUser)null!)!;
            
            return _context.Users.SingleOrDefaultAsync(u => u.Id == UserId,
                cancellationToken)!;
        }

        public ApplicationUser? GetAttachedUserAsync()
        {
            if (UserId == null)
                return null;
            
            var user = new ApplicationUser {Id = UserId};

            _context.EnsureAttached(user);

            return user;
        }
    }
}