using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProteinApi.Auth
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthTestController : ControllerBase
    {
        public AuthTestController() : base()
        {

        }

        [NonAction]
        [HttpGet("NoToken")]
        public string NoToken()
        {
            return "NoToken";
        }

        [NonAction]
        [HttpGet("Authorize")]
        [Authorize]
        public string Authorize()
        {
            return "Authorize";
        }



    }
}
