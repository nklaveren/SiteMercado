using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SiteMercado.Core.UseCases.Products;
using SiteMercado.Core.UseCases.Products.Interfaces;
using SiteMercado.Infrastructure.Database;
using SiteMercado.Infrastructure.Database.DataSources.Products;
using SiteMercado.SharedKernel.Interfaces;
using SiteMercado.WebApi.Api.Login;

using System.Net.Http;

namespace SiteMercado.WebApi.StartupExtensions
{
    public static class StartupServicesConfig
    {
        public static IServiceCollection InjectUseCases(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<LoginExternalConfig>(
                configuration.GetSection(nameof(LoginExternalConfig))
            );

            services.AddScoped<IRepository, EfRepository>();
            services.AddScoped<HttpClient>();
            services.AddScoped<IFindProductByDescriptionDataSource, FindProductByDescriptionDataSource>();
            services.AddScoped<ICreateProductUseCase, CreateProductUseCase>();
            services.AddScoped<IUpdateProductUseCase, UpdateProductUseCase>();
            services.AddScoped<IListAllProductsDataSource, ListAllProductsDataSource>();

            return services;
        }
    }
}
