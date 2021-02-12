using SiteMercado.Core.Entities;
using SiteMercado.SharedKernel.Interfaces;

using System.Collections.Generic;

namespace SiteMercado.Core.UseCases.Products.Interfaces
{
    public interface IListAllProductsDataSource : IUseCase<List<Product>>
    {
    }
}
