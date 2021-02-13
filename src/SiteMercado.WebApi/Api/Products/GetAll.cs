using Microsoft.AspNetCore.Mvc;

using SiteMercado.Core.UseCases.Products.Interfaces;

using Swashbuckle.AspNetCore.Annotations;

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
        [SwaggerOperation(
            Summary = "Gets a list of all Products",
            Description = "Gets a list of all Products",
            OperationId = "Product.List",
            Tags = new[] { "Products" })
        ]
        public async Task<IActionResult> HandleAsncy()
        {
            var items = await dataSource.Handle();
            if (!items.Any())
            {
                return NotFound();
            }
            return Ok(items.Select(GetAllProductResponse.FromProduct));
        }
    }
}
