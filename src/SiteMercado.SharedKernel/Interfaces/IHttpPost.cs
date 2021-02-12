using System.Threading.Tasks;

namespace SiteMercado.SharedKernel.Interfaces
{
    public interface IHttpPost<TIn, TOut>
    {
        Task<TOut> Post(string url, TIn param);
    }
}
