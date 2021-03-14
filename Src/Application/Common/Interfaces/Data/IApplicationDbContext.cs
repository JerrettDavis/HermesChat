using System.Threading;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Server> Servers { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new());
    }
}