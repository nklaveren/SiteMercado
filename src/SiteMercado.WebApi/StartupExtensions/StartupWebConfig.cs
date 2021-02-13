using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

using SiteMercado.WebApi.Filters;

using System.Text;

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

                    options.Filters.Add(typeof(ApiExceptionFilter));

                });

            services.AddCors();

            return services;
        }
    }
}