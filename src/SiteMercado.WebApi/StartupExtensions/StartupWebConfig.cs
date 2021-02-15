using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace SiteMercado.WebApi.StartupExtensions
{
    public static class StartupWebConfig
    {
        public static IServiceCollection WebApiConfig(this IServiceCollection services)
        {
            services
                .AddControllers(options =>
                {
                    options.Filters.Add(new AuthorizeFilter(new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build()));

                });

            services.AddCors();

            return services;
        }
    }
}