using SiteMercado.Infrastructure.Database;
using SiteMercado.Infrastructure.Database.DataSources.Products;
using SiteMercado.WebApi.Api.Products;

using System.Linq;
using System.Threading.Tasks;

using Xunit;

namespace SiteMercado.FunctionalTests.Products
{
    public   class ReadTests : SqliteAppDbContextTest
    {
        public override string CurrentDb => GetType().Name;
        [Fact]
        public async Task Can_get_products()
        {
            using var context = new AppDbContext(this.ContextOptions);
            var listAllProductsDataSource = new ListAllProductsDataSource(context);
            var controller = new GetAll(listAllProductsDataSource);
            var products = await controller.HandleAsncy();
            var product = products.First();
            Assert.Equal(10, products.Count());
            Assert.Equal("Teste 1", product.Description);
            Assert.Equal(10, product.Price);
            Assert.Equal("http://teste.image.com/1", product.Image);
        }

        [Fact]
        public async Task Can_get_by_id_products()
        {
            using var context = new AppDbContext(this.ContextOptions);
            var repository = new EfRepository(context);
            var controller = new Get(repository);
            var product = await controller.HandleAsncy(1);

            Assert.Equal("Teste 1", product.Description);
            Assert.Equal("http://teste.image.com/1", product.Image);

            var productTwo = await controller.HandleAsncy(2);

            Assert.Equal("Teste 2", productTwo.Description);
            Assert.Equal("http://teste.image.com/2", productTwo.Image);
        }

    }
}
