using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

using System.Text.Json;
using System.Text.Json.Serialization;

namespace SiteMercado.WebApi.StartupExtensions
{
    public class ResultApiError
    {
        [JsonPropertyName("errors")]
        public string[] Errors { get; set; }
        [JsonPropertyName("stackTrace")]
        public string StackTrace { get; set; }

    }
    public static class StartupExceptionConfig
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(a => a.Run(async context =>
             {
                 var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                 var exception = exceptionHandlerPathFeature.Error;

                 var result = JsonSerializer.Serialize(new ResultApiError { Errors = new[] { exception.Message }, StackTrace = exception.StackTrace });
                 context.Response.ContentType = "application/json";
                 await context.Response.WriteAsync(result);
             }));
        }
    }
}
