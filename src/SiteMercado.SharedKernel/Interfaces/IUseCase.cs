using System.Threading.Tasks;

namespace SiteMercado.SharedKernel.Interfaces
{
    public interface IUseCase<TIn, TOut>
    {
        Task<TOut> Handle(TIn param);
    }
    public interface IUseCase<TOut>
    {
        Task<TOut> Handle();
    }
}
