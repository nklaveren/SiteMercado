using SiteMercado.Core.UseCases.Products;
using SiteMercado.Infrastructure.Database;
using SiteMercado.WebApi.Api.Products;

using System.Threading.Tasks;

using Xunit;

namespace SiteMercado.FunctionalTests.Products
{
    public class UpdateTests : SqliteAppDbContextTest
    {
        public override string CurrentDb => GetType().Name;

        [Fact]
        public async Task Can_update_a_product_before_get_by_id()
        {
            using var context = new AppDbContext(this.ContextOptions);
            var repository = new EfRepository(context);
            var controllerGet = new Get(repository);
            var productByGet = await controllerGet.HandleAsncy(1);


            var useCase = new UpdateProductUseCase(repository);
            var controller = new Update(useCase);
            var productRequest = productByGet.ToProductRequest();
            productRequest.Description = "Teste Update 01";
            var response = await controller.HandleAsncy(productByGet.Id, productRequest);

            var productOne = response.Value;

            Assert.NotEqual(0, productOne.Id);

            Assert.Equal(productRequest.Description, productOne.Description);
            Assert.Equal(productRequest.Price, productOne.Price);
            Assert.Equal(productRequest.Image, productOne.Image);
        }
    }
}
