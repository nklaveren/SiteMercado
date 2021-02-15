using SiteMercado.Infrastructure.Database;
using SiteMercado.WebApi.Api.Products;

using System.Threading.Tasks;

using Xunit;

namespace SiteMercado.FunctionalTests.Products
{
    public class DeleteTests : SqliteAppDbContextTest
    {
        public override string CurrentDb => GetType().Name;

        [Fact]
        public async Task Can_delete_a_product_before_get_by_id()
        {
            using var context = new AppDbContext(this.ContextOptions);
            var repository = new EfRepository(context);
            var controllerGet = new Get(repository);
            var productByGet = await controllerGet.HandleAsncy(1);

            Assert.NotNull(productByGet);

            var deleteController = new Delete(repository);
            await deleteController.HandleAsync(productByGet.Id);

            var response = await controllerGet.HandleAsncy(productByGet.Id);

            Assert.Null(response);
        }
    }
}
