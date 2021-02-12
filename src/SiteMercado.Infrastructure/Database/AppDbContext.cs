using Microsoft.EntityFrameworkCore;

using SiteMercado.Core.Entities;
using SiteMercado.Infrastructure.Database.Config;

using System.Threading;
using System.Threading.Tasks;

namespace SiteMercado.Infrastructure.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return result;
        }
    }
}
