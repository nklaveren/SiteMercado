
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SiteMercado.WebApi.Api
{
    [Route("api")]
    [ApiController]
    [Authorize]
    public abstract class BaseApiController : Controller
    {
    }
}
