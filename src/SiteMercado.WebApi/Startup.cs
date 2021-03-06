using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using SiteMercado.Infrastructure.Database;
using SiteMercado.WebApi.StartupExtensions;

using System.Text.Json;

namespace SiteMercado.WebApi
{
    public class Startup
    {
        private readonly IConfiguration Configuration;

        public bool UseInMemoryDatabase { get; }

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
            this.UseInMemoryDatabase = bool.Parse(configuration.GetSection("UseInMemoryDatabase").Value);
        }

        public void ConfigureServices(IServiceCollection services)
        {

            string connectionString = Configuration.GetConnectionString("ConnectionString");
            services.AddAppDbContext(connectionString);
            services.WebApiConfig();
            services.AuthenticationConfig();
            services.InjectUseCases(this.Configuration);
            services.AddSwagger();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                options.OAuthClientId("sitemercado");
                options.OAuthAppName("SiteMercado - Api");
            });

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.ConfigureExceptionHandler();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
