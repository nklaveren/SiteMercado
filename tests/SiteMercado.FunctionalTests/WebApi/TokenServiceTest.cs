using SiteMercado.WebApi.Services;

using Xunit;

namespace SiteMercado.FunctionalTests
{
    public class TokenServiceTest
    {
        [Fact]
        public void Generate_jwt_token()
        {
            var token = TokenService.GenerateToken("username");

            Assert.NotNull(token);
        }
    }
}
