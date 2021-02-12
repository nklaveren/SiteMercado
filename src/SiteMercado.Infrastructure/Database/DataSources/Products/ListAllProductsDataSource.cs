using Microsoft.EntityFrameworkCore;

using SiteMercado.Core.Entities;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiteMercado.Infrastructure.Database.DataSources.Products
{
    public class ListAllProductsDataSource
    {
        private readonly AppDbContext context;

        public ListAllProductsDataSource(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<List<Product>> Handle()
        {
            return await this.context.Set<Product>().ToListAsync();
        }
    }
}
