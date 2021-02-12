using SiteMercado.Core.Entities;
using SiteMercado.Core.Errors;
using SiteMercado.Core.UseCases.Authentication.Interfaces;
using SiteMercado.SharedKernel.Interfaces;

using System;
using System.Threading.Tasks;

namespace SiteMercado.Core.UseCases.Authentication
{
    public class LoginUseCase : IUseCase<Login, LoginResult>
    {
        private readonly ILoginService service;

        public LoginUseCase(ILoginService service )
        {
            this.service = service;
        }

        public async Task<LoginResult> Handle(Login param)
        {
            try
            {
                var serviceResponse = await this.service.Handle(param);
                if (serviceResponse.Sucess)
                {
                    return serviceResponse;
                }
                else throw new UserOrPasswordNotFoundException();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
