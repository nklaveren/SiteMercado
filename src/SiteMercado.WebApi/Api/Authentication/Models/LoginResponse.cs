using System.Text.Json.Serialization;

namespace SiteMercado.WebApi.Api.Login
{
    public class LoginResponse
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }
        
        [JsonPropertyName("message")]
        public string Message { get; set; }
        public string Token { get; set; }
    }
}
