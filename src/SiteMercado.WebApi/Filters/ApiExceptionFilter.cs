using Microsoft.AspNetCore.Mvc.Filters;

namespace SiteMercado.WebApi.Filters
{
    public class ApiExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            var exceptionType = exception.GetType();
            //TODO: Adicionar padrão para tratamento de excessão
        }
    }
}
