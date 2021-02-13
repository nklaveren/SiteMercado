using Microsoft.AspNetCore.Mvc;

using SiteMercado.Core.Entities;
using SiteMercado.SharedKernel.Interfaces;

using Swashbuckle.AspNetCore.Annotations;

using System.Threading.Tasks;

namespace SiteMercado.WebApi.Api.Products
{
    public class Get : BaseApiController
    {
        private readonly IRepository repository;

        public Get(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("Product/{id:int}.{format?}")]
        [FormatFilter]
        [SwaggerOperation(
            Summary = "Gets a single Product",
            Description = "Gets a single Product by Id",
            OperationId = "Product.GetById",
            Tags = new[] { "Products" })
        ]
        public async Task<IActionResult> HandleAsncy(int id)
        {
            var item = await repository.GetByIdAsync<Product>(id);
            if (item is null)
            {
                return NotFound();
            }
            return Ok(GetAllProductResponse.FromProduct(item));
        }
    }
}
