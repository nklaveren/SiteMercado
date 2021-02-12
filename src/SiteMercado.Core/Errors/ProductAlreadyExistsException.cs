using System;

namespace SiteMercado.Core.Errors
{
    public class ProductAlreadyExistsException : Exception
    {
        public ProductAlreadyExistsException() : base("product alread exists") { }
    }
}
