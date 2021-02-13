using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using SiteMercado.WebApi.Services;
using SiteMercado.WebApi.StartupExtensions;

using Swashbuckle.AspNetCore.Annotations;

using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SiteMercado.WebApi.Api.Login
{
    public class LoginWithUserAndPassword : BaseApiController
    {
        private readonly LoginExternalConfig config;

        public LoginWithUserAndPassword(IOptions<LoginExternalConfig> option)
        {
            this.config = option.Value;

            if (string.IsNullOrEmpty(config.Url))
            {
                throw new ArgumentNullException(nameof(LoginExternalConfig));
            }


        }
        [AllowAnonymous]
        [HttpPost("Login")]
        [SwaggerOperation(
            Summary = "Login",
            Description = "Login",
            OperationId = "Login.Post",
            Tags = new[] { "Login" })
        ]
        public async Task<ActionResult<LoginResponse>> HandleAsncy(LoginRequest login)
        {
            using var http = new HttpClient();
            http.DefaultRequestHeaders.Add("Authorization", $"Basic {login.ToBase64}");
            //var httpResponse = await http.PostAsync(this.config.Url, null);
            //if (!httpResponse.IsSuccessStatusCode)
            //{
            //    return NotFound("username or password incorrect");
            //}
            //var content = await httpResponse.Content.ReadAsStringAsync();
            //var resposne = JsonSerializer.Deserialize<LoginResponse>(content);
            //if (!resposne.Success)
            //{
            //    return base.Unauthorized(resposne);
            //}
            var resposne = new LoginResponse();
            var token = TokenService.GenerateToken(login.Username);
            resposne.Token = token;
            return Ok(resposne);
        }
    }
}
