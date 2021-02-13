using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SiteMercado.WebApi.Api.Login
{
    public class LoginRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string ToBase64
        {
            get
            {
                var keypair = $"{Username}:{Password}";
                var encoded = Encoding.GetEncoding("UTF-8").GetBytes(keypair);
                var base64 = Convert.ToBase64String(encoded);
                return base64;
            }
        }
    }
}
