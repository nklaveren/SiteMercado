using Microsoft.AspNetCore.Mvc;

using SiteMercado.Core.UseCases.Authentication.Interfaces;

using System.Threading.Tasks;

namespace SiteMercado.WebApi.Api.Authentication
{

    public class PostWithUserAndPassword : BaseApiController
    {
        private readonly ILoginUseCase useCase;

        public PostWithUserAndPassword(ILoginUseCase useCase)
        {
            this.useCase = useCase;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<LoginResponse>> HandleAsncy(LoginRequest request)
        {
            var response = await useCase.Handle(request.ToLogin());
            if (response.Sucess)
            {
                return Ok(response);
            }
            return this.Unauthorized(response);
        }
    }
}
