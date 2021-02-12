namespace SiteMercado.Infrastructure.HttpService
{
    public class ExternalServiceException : System.Exception
    {
        public ExternalServiceException(string error) : base(error)
        {

        }
    }
}
