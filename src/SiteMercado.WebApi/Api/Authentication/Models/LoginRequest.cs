using SiteMercado.Core.Entities;

namespace SiteMercado.WebApi.Api.Authentication
{
    public class LoginRequest
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public Login ToLogin()
        {
            return new Login
            {
                UserName = this.UserName,
                Password = this.Password
            };
        }
    }
}
