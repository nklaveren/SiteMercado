using Microsoft.Extensions.Options;

using SiteMercado.Core.Entities;
using SiteMercado.Core.UseCases.Authentication;
using SiteMercado.Core.UseCases.Authentication.Interfaces;
using SiteMercado.SharedKernel.Interfaces;

using System.Threading.Tasks;

namespace SiteMercado.Infrastructure.Services
{
    public class LoginServiceConfig
    {
        public string Url { get; set; }
    }

    public class LoginService : ILoginService
    {
        private readonly LoginServiceConfig config;
        private readonly IHttpPost<Login, LoginResult> service;

        public LoginService(IOptions<LoginServiceConfig> options, IHttpPost<Login, LoginResult> service)
        {
            this.config = options.Value;
            this.service = service;
        }

        public async Task<LoginResult> Handle(Login login)
        {
            if (this.config.Url is null) throw new System.Exception($"{nameof(LoginServiceConfig)} not configured");
            return await this.service.Post(this.config.Url, login);
        }
    }
}
