using Microsoft.AspNetCore.Mvc;

using SiteMercado.Core.UseCases.Products.Interfaces;

using System.Threading.Tasks;

namespace SiteMercado.WebApi.Api.Products
{
    public class Update : BaseApiController
    {
        private readonly IUpdateProductUseCase useCase;

        public Update(IUpdateProductUseCase useCase)
        {
            this.useCase = useCase;
        }

        [HttpPut("Product/{id:int}")]
        public async Task<ActionResult<GetAllProductResponse>> HandleAsncy(int id, ProductRequest request)
        {
            var product = await this.useCase.Handle(request.ToProduct(id));
            return Ok(ProductResponse.FromProduct(product));
        }
    }
}
