using Microsoft.AspNetCore.Mvc;
using ProteinApi.Base;
using ProteinApi.Service;
using Serilog;

namespace ProteinApi.Auth
{
    [ApiController]
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly ITokenManagementService tokenManagementService;


        public TokenController(ITokenManagementService tokenManagementService) : base()
        {
            this.tokenManagementService = tokenManagementService;

        }


        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] TokenRequest tokenRequest)
        {

            string userAgent = Request.Headers["User-Agent"].ToString();
            var result = await tokenManagementService.GenerateTokensAsync(tokenRequest, DateTime.UtcNow, userAgent);

            if (result.Success)
            {
                return Ok(result);
            }

            return Unauthorized(result);
        }
    }
}
