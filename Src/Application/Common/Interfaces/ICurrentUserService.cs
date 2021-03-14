using System.Threading;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        string? UserId { get; }

        Task<ApplicationUser?> GetLoadedUserAsync(
            CancellationToken cancellationToken);

        ApplicationUser? GetAttachedUserAsync();
    }
}