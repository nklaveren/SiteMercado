using Microsoft.AspNetCore.Mvc;

using SiteMercado.Core.UseCases.Products.Interfaces;

using Swashbuckle.AspNetCore.Annotations;

using System.Threading.Tasks;

namespace SiteMercado.WebApi.Api.Products
{

    public class Create : BaseApiController
    {
        private readonly ICreateProductUseCase useCase;

        public Create(ICreateProductUseCase useCase)
        {
            this.useCase = useCase;
        }

        [HttpPost("Product")]
        [SwaggerOperation(
            Summary = "Creates a new Product",
            Description = "Creates a new Product",
            OperationId = "Product.Create",
            Tags = new[] { "Products" })
        ]
        public async Task<ActionResult<ProductResponse>> HandleAsncy(ProductRequest request)
        {
            var product = await useCase.Handle(request.ToProduct());
            return ProductResponse.FromProduct(product);
        }
    }
}
