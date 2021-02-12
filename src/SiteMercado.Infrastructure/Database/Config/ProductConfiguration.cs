using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SiteMercado.Core.Entities;

namespace SiteMercado.Infrastructure.Databasebase.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.Price).IsRequired();
            builder.Property(p => p.Image).IsRequired(false);

            builder.HasIndex(x => x.Id).IsUnique();

            builder.HasIndex(x => x.Description);
        }
    }
}
