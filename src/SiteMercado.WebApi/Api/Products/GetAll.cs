using Microsoft.AspNetCore.Mvc;

using SiteMercado.Core.UseCases.Products.Interfaces;

using System.Linq;
using System.Threading.Tasks;

namespace SiteMercado.WebApi.Api.Products
{
    public class GetAll : BaseApiController
    {
        private readonly IListAllProductsDataSource dataSource;

        public GetAll(IListAllProductsDataSource dataSource)
        {
            this.dataSource = dataSource;
        }

        [HttpGet("Product")]
        public async Task<IActionResult> HandleAsncy()
        {
            var items = await dataSource.Handle();
            return Ok(items.Select(GetAllProductResponse.FromProduct));
        }
    }
}
