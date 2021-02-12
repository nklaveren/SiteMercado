using SiteMercado.Core.Entities;
using SiteMercado.SharedKernel.Interfaces;

namespace SiteMercado.Core.UseCases.Authentication.Interfaces
{
    public interface ILoginUseCase : IUseCase<Login, LoginResult>
    {
    }
}
