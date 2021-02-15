using SiteMercado.Core.Entities;

namespace SiteMercado.WebApi.Api.Products
{
    public class GetAllProductResponse
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }

        public static GetAllProductResponse FromProduct(Product product)
        {
            if (product is null) return null;
            return new GetAllProductResponse
            {
                Id = product.Id,
                Description = product.Description,
                Price = product.Price,
                Image = product.Image
            };
        }
    }
}
