using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SiteMercado.Infrastructure.Database
{
    public static class StartupSetup
    {
        public static void AddAppDbContext(this IServiceCollection services, string connectionString) =>
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(connectionString));
    }
}
