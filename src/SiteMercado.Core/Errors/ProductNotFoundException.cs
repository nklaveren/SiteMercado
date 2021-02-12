using System;

namespace SiteMercado.Core.Errors
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException() : base("Product Not Found")
        {
        }
    }
}
