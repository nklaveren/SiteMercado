using SiteMercado.WebApi.Api.Login;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

using Xunit;
using Microsoft.Extensions.Hosting;
using System;

namespace SiteMercado.IntegrationTests.SiteMercado
{
    public class LoginWithUserAndPasswordTests
    {
        private IOptions<LoginExternalConfig> option;

        public LoginWithUserAndPasswordTests()
        {
            this.option = Options.Create<LoginExternalConfig>(new LoginExternalConfig()
            {
                Url = "https://dev.sitemercado.com.br/api/login"
            });
        }

        [Fact]
        public void Create_encoded_base64()
        {
            var expectedEncode = "dGVzdGU6dGVzdGU=";

            var loginRequest = new LoginRequest()
            {
                Username = "teste",
                Password = "teste"
            };

            Assert.Equal(expectedEncode, loginRequest.ToBase64);
        }


        [Fact]
        public async Task Given_wrong_username_return_fail()
        {
            var controller = new LoginWithUserAndPassword(this.option);
            var loginRequest = new LoginRequest
            {
                Username = "teste",
                Password = "teste"
            };
            var response = await controller.HandleAsncy(loginRequest);
            var result = response.Value;

            Assert.False(result.Success);
            Assert.Equal("authentication username or password invalid", result.Error);
            Assert.Null(result.Token);
        }

        [Fact]
        public async Task Given_correct_username_return_success()
        {
            var controller = new LoginWithUserAndPassword(this.option);
            var userName = Environment.GetEnvironmentVariable("SiteMercadoUsername");
            var password = Environment.GetEnvironmentVariable("SiteMercadoPassword");

            var loginRequest = new LoginRequest
            {
                Username = userName,
                Password = password
            };
            var response = await controller.HandleAsncy(loginRequest);
            var result = response.Value;

            Assert.True(result.Success);
            Assert.Null(result.Error);
            Assert.NotNull(result.Token);
        }


    }
}
