using Microsoft.AspNetCore.Mvc;

using SiteMercado.Core.Entities;
using SiteMercado.SharedKernel.Interfaces;

using Swashbuckle.AspNetCore.Annotations;

using System.Threading.Tasks;

namespace SiteMercado.WebApi.Api.Products
{
    public class Delete : BaseApiController
    {
        private readonly IRepository _repository;

        public Delete(IRepository repository)
        {
            _repository = repository;
        }

        [HttpDelete("Product/{id:int}")]
        [SwaggerOperation(
            Summary = "Deletes a Product",
            Description = "Deletes a Product",
            OperationId = "Product.Delete",
            Tags = new[] { "Products" })
        ]
        public async Task HandleAsync(int id)
        {
            var product = await _repository.GetByIdAsync<Product>(id);
            await _repository.DeleteAsync(product);
        }
    }
}
