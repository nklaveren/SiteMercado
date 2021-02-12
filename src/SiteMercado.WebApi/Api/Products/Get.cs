using Microsoft.AspNetCore.Mvc;

using SiteMercado.Core.Entities;
using SiteMercado.SharedKernel.Interfaces;

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

        [HttpGet("Product/{id:int}")]
        public async Task<IActionResult> HandleAsncy(int id)
        {
            var item = await repository.GetByIdAsync<Product>(id);
            return Ok(GetAllProductResponse.FromProduct(item));
        }
    }
}
