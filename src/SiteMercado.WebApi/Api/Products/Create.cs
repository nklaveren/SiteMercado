using Microsoft.AspNetCore.Mvc;

using SiteMercado.Core.UseCases.Products.Interfaces;

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
        public async Task<ActionResult<ProductResponse>> HandleAsncy(ProductRequest request)
        {
            var product = await useCase.Handle(request.ToProduct());
            return Ok(ProductResponse.FromProduct(product));
        }
    }
}
