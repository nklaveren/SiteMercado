using Microsoft.EntityFrameworkCore;

using SiteMercado.Core.Entities;
using SiteMercado.Infrastructure.Database;

using System;
using System.Linq;

namespace SiteMercado.FunctionalTests
{
    public abstract class SqliteAppDbContextTest
    {
        public abstract string CurrentDb { get; }
        public SqliteAppDbContextTest()
        {
            ContextOptions = new DbContextOptionsBuilder<AppDbContext>().UseSqlite($"Filename={CurrentDb}.db").Options;
            Seed();
        }

        public DbContextOptions<AppDbContext> ContextOptions { get; }

        private void Seed()
        {
            using var context = new AppDbContext(ContextOptions);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var products = Enumerable.Range(1, 10)
                .Select(x => new Product(
                    description: $"Teste {x}",
                    price: x * 10,
                    image: "http://teste.image.com/" + x)
                );

            context.AddRange(products);
            context.SaveChanges();
        }
    }
}
