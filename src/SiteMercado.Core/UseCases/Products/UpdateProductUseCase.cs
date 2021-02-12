using SiteMercado.Core.Entities;
using SiteMercado.Core.Errors;
using SiteMercado.Core.UseCases.Products.Interfaces;
using SiteMercado.SharedKernel.Interfaces;

using System.Threading.Tasks;

namespace SiteMercado.Core.UseCases.Products
{
    public class UpdateProductUseCase : IUpdateProductUseCase
    {
        private readonly IRepository repository;

        public UpdateProductUseCase(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Product> Handle(Product param)
        {
            var product = await this.repository.GetByIdAsync<Product>(param.Id);

            if (product is null)
            {
                throw new ProductNotFoundException();
            }

            await this.repository.UpdateAsync(product);
            return product;
        }
    }
}
