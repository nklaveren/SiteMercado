namespace SiteMercado.Core.Entities
{
    public class Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
