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
                return Task.FromResult((ApplicationUser)null!)!;
            
            return _context.Users.SingleOrDefaultAsync(u => u.Id == _userId,
                cancellationToken)!;
        }

        public ApplicationUser? GetAttachedUserAsync()
        {
            if (_userId == null)
                return null;
            
            var user = new ApplicationUser {Id = _userId};

            _context.EnsureAttached(user);

            return user;
        }
    }
}