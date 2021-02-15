using SiteMercado.Core.Entities;

using System;
using System.Collections.Generic;
using System.Text;

using Xunit;

namespace SiteMercado.UnitTests.Products
{
    public class ProductTests
    {

        [Fact]
        public void Can_update_price()
        {
            var product = new Product("Teste 01", 10.0M, "URL");
            Assert.Throws<ArgumentOutOfRangeException>(() => product.UpdatePrice(-10M));
            Assert.Throws<ArgumentOutOfRangeException>(() => product.UpdatePrice(-100M));
            product.UpdatePrice(100M);
            Assert.Equal(100M, product.Price);
        }

        [Fact]
        public void Cannot_be_created_product_without_description()
        {
            Assert.Throws<ArgumentNullException>(() => new Product(null, 10.0M, "URL"));
            var product = new Product("Description", 10.0M, "URL");
            Assert.NotNull(product.Description);
        }


        [Fact]
        public void Can_be_created_without_url()
        {
            var product = new Product("Description", 10.0M);
            Assert.NotNull(product.Description);
            Assert.Null(product.Image);
        }
    }
}
