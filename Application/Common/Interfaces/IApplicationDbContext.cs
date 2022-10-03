using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Surface> Surface { get; }

        DbSet<Robot> Robot { get; }

        DbSet<ExploredSurface> ExploredSurface { get; }

        DbSet<Output> Output { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}