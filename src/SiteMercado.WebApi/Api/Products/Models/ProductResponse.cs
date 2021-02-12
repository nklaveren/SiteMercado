using SiteMercado.Core.Entities;

using System.ComponentModel.DataAnnotations;

namespace SiteMercado.WebApi.Api.Products
{
    public class ProductResponse
    {
        [Required(ErrorMessage = "Description are required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price are required")]
        public decimal Price { get; set; }
        public string Image { get; set; }

        public static ProductResponse FromProduct(Product product)
        {
            if (product is null) return null;
            return new ProductResponse
            {
                Description = product.Description,
                Price = product.Price,
                Image = product.Image
            };
        }

    }
}
