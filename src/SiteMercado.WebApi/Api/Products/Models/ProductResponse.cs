using SiteMercado.Core.Entities;

using System;

namespace SiteMercado.WebApi.Api.Products
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }


        public static ProductResponse FromProduct(Product product)
        {
            if (product is null) return null;
            return new ProductResponse
            {
                Id = product.Id,
                Description = product.Description,
                Price = product.Price,
                Image = product.Image
            };
        }

        public ProductRequest ToProductRequest()
        {
            return new ProductRequest
            {
                Price = Price,
                Description = Description,
                Image = Image
            };
        }
    }
}
