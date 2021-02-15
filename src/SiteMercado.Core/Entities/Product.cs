using SiteMercado.SharedKernel;

using System;

namespace SiteMercado.Core.Entities
{
    public class Product : BaseEntity
    {

        public Product(string description, decimal price, string image = null)
        {
            
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Image = image;
            UpdatePrice(price);
        }

        public string Description { get; set; }


        public void UpdatePrice(decimal newPrice)
        {
            if (newPrice < 0.01M)
            {
                throw new ArgumentOutOfRangeException(nameof(Price));
            }
            this.Price = newPrice;
        }


        public decimal Price { get; set; }
        public string Image { get; set; }
    }
}
