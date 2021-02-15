using SiteMercado.Core.UseCases.Products;
using SiteMercado.Infrastructure.Database.DataSources.Products;
using SiteMercado.Infrastructure.Database;
using SiteMercado.WebApi.Api.Products;
using System.Threading.Tasks;
using Xunit;
using SiteMercado.Core.UseCases.Products.Interfaces;

namespace SiteMercado.FunctionalTests.Products
{
    public class CreateTests : SqliteAppDbContextTest
    {
        public override string CurrentDb => GetType().Name;

        [Fact]
        public async Task Can_create_a_product()
        {
            using var context = new AppDbContext(this.ContextOptions);
            var findProductByDescription = new FindProductByDescriptionDataSource(context);
            var repository = new EfRepository(context);
            ICreateProductUseCase useCase = new CreateProductUseCase(repository, findProductByDescription);
            var controller = new Create(useCase);
            var productRequest = new ProductRequest
            {
                Description = "Teste Create 1",
                Price = 10m,
                Image = "testeUrl"
            };
            var response = await controller.HandleAsncy(productRequest);

            var product = response.Value;

            Assert.NotEqual(0, product.Id);

            Assert.Equal(productRequest.Description, product.Description);
            Assert.Equal(productRequest.Price, product.Price);
            Assert.Equal(productRequest.Image, product.Image);
        }

    }
}
