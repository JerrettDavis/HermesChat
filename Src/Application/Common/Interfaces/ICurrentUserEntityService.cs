using System.Threading;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.Common.Interfaces
{
    public interface ICurrentUserEntityService
    {
        Task<ApplicationUser?> GetLoadedUserAsync(
            CancellationToken cancellationToken);

        ApplicationUser? GetAttachedUserAsync();
    }
}