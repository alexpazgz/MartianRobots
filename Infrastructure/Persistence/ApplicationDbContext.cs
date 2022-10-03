using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        #region Ctor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        #endregion

        #region DbSet
        public DbSet<Surface> Surface { get; set; }

        public DbSet<Robot> Robot { get; set; }

        public DbSet<Output> Output { get; set; }

        //public DbSet<Scent> Scent { get; set; }

        public DbSet<ExploredSurface> ExploredSurface { get; set; }
        #endregion

        #region methods
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
        #endregion
    }
}
