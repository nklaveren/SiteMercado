using SiteMercado.Core.Entities;
using SiteMercado.Core.Errors;
using SiteMercado.Core.UseCases.Products.Interfaces;
using SiteMercado.SharedKernel.Interfaces;

using System.Threading.Tasks;

namespace SiteMercado.Core.UseCases.Products
{
   
    public class CreateProductUseCase : ICreateProductUseCase
    {
        private readonly IRepository repository;
        private readonly IFindProductByDescriptionDataSource dataSource;

        public CreateProductUseCase(IRepository repository, IFindProductByDescriptionDataSource dataSource)
        {
            this.repository = repository;
            this.dataSource = dataSource;
        }
        public async Task<Product> Handle(Product param)
        {
            var productInDb = await dataSource.Handle(param.Description);
            
            if (productInDb != null)
            {
                throw new ProductAlreadyExistsException();
            }

            return await repository.AddAsync(param);
        }
    }
}
