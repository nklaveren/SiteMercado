﻿using SiteMercado.Core.Entities;
using SiteMercado.SharedKernel.Interfaces;

namespace SiteMercado.Core.UseCases.Products.Interfaces
{
    public interface IFindProductByDescriptionDataSource : IUseCase<string, Product>
    {
    }
}
