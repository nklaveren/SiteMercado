using Microsoft.EntityFrameworkCore;

using SiteMercado.Core.Entities;
using SiteMercado.Core.UseCases.Products.Interfaces;

using System.Threading.Tasks;

namespace SiteMercado.Infrastructure.Database.DataSources.Products
{
    public class FindProductByDescriptionDataSource : IFindProductByDescriptionDataSource
    {
        private readonly AppDbContext context;

        public FindProductByDescriptionDataSource(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<Product> Handle(string param)
        {
            return await this.context.Products.FirstOrDefaultAsync(x => x.Description == param);
        }
    }
}
