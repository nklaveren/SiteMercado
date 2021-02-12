using SiteMercado.Core.Entities;

using System.Threading.Tasks;

namespace SiteMercado.Core.UseCases.Authentication.Interfaces
{
    public interface ILoginService
    {
        Task<LoginResult> Handle(Login login);
    }
}
