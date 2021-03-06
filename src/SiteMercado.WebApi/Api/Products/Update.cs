﻿using Microsoft.AspNetCore.Mvc;

using SiteMercado.Core.UseCases.Products.Interfaces;

using Swashbuckle.AspNetCore.Annotations;

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
        [SwaggerOperation(
            Summary = "Updates a Product",
            Description = "Updates a Product",
            OperationId = "Product.Update",
            Tags = new[] { "Products" })
        ]
        public async Task<ActionResult<ProductResponse>> HandleAsncy(int id, ProductRequest request)
        {
            var response = await this.useCase.Handle(request.ToProduct(id));
            return ProductResponse.FromProduct(response);

        }
    }
}
