using SiteMercado.SharedKernel.Interfaces;

using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace SiteMercado.Infrastructure.HttpService
{
    public class GenericHttpService<TIn, TOut> : IHttpPost<TIn, TOut>
    {
        private readonly HttpClient httpClient;

        public GenericHttpService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<TOut> Post(string url, TIn param)
        {
            this.httpClient.BaseAddress = new Uri(url);
            var content = JsonContent.Create(JsonSerializer.Serialize(param));
            var result = await httpClient.PostAsync(url, content);
            if (result.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<TOut>(await result.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception(await result.Content.ReadAsStringAsync());
            }
        }
    }
}
