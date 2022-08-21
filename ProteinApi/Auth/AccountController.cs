using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProteinApi.Base;
using ProteinApi.Controllers;
using ProteinApi.Data;
using ProteinApi.Dto;
using ProteinApi.Service;
using Serilog;
using System.Security.Claims;


namespace ProteinApi.Auth
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : BaseController<AccountDto, Account>
    {
        private readonly IAccountService _accountService;
        private readonly IEmailService _emailService;
        private readonly IProductService _productService;


        public AccountController(IAccountService accountService, IMapper mapper, IEmailService emailService,IProductService productService) : base(accountService, mapper)
        {
            this._accountService = accountService;
            this._emailService = emailService;
            this._productService = productService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] AccountDto resource)
        {
            resource.Password = HashExtension.HashPassword(resource.Password);

            var result = await _accountService.InsertAsync(resource);

            if (!result.Success)
                return BadRequest(result);

            EmailDto email = new EmailDto(resource);
            
            _emailService.SendEmail(email);

            return StatusCode(201, result);
        }

        [HttpGet("GetUserDetail")]
        public async Task<IActionResult> GetUserDetail()
        {
            var userId = (User.Identity as ClaimsIdentity).FindFirst("AccountId").Value;
            return await base.GetByIdAsync(int.Parse(userId));
        }

        [HttpPut("self-update/{id:int}")]

        public async Task<IActionResult> SelfUpdateAsync(int id, [FromBody] AccountDto resource)
        {
            Log.Information($"{User.Identity?.Name}: self-update account with Id is {id}.");

            var identifier = (User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.NameIdentifier).Value;

            if (!identifier.Equals(id.ToString()))
                return BadRequest(new BaseResponse<AccountDto>("Account_Not_Permitted"));

            var result = await _accountService.SelfUpdateAsync(id, resource);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("change-password/{id:int}")]
        public async Task<IActionResult> UpdatePasswordAsync(int id, [FromBody] UpdatePasswordRequest resource)
        {
            // Check if the id belongs to me
            var identifier = (User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.NameIdentifier).Value;
            if (!identifier.Equals(id.ToString()))
                return BadRequest(new BaseResponse<AccountDto>("Account_Not_Permitted"));

            // Checking duplicate password
            if (resource.OldPassword.Equals(resource.NewPassword))
                return BadRequest(new BaseResponse<AccountDto>("Account_Not_Permitted"));

            var result = await _accountService.UpdatePasswordAsync(id, resource);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }


        [HttpDelete("{id:int}")]
        public new async Task<IActionResult> DeleteAsync(int id)
        {
            return await base.DeleteAsync(id);
        }

        [HttpGet("get-all-offers")]
        public Task<List<Product>> GetAllOffers()
        {
            var identifier = (User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.NameIdentifier).Value;

            var result = _productService.GetAllOffers(Convert.ToInt32(identifier));

            return result;

        }

    }
}
