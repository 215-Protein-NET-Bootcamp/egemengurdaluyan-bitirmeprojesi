using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProteinApi.Base;
using ProteinApi.Controllers;
using ProteinApi.Data;
using ProteinApi.Dto;
using ProteinApi.Service;
using System.Security.Claims;

namespace ProteinApi.Auth
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : BaseController<ProductDto, Product>
    {
        private readonly IProductService _productService;
        private readonly IAccountService _accountService;
        public ProductController(IProductService productService, IMapper mapper,IAccountService accountService) : base(productService, mapper)
        {
            this._productService = productService;
            this._accountService = accountService;

        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ProductDto resource)
        {

            var result = await _productService.InsertAsync(resource);

            if (!result.Success)
                return BadRequest(result);

            return StatusCode(201, result);
        }


        [HttpDelete("{id:int}")]
        public new async Task<IActionResult> DeleteAsync(int id)
        {
            return await base.DeleteAsync(id);
        }

        [HttpPost("give-offer")]
        public async Task<IActionResult> GiveOffer(OfferRequest resource)
        {
            var identifier = (User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.NameIdentifier).Value;

            var result = await _productService.GetByIdAsync(resource.OfferId);
            if (!result.Success)
            {
                return BadRequest();
            }
            try
            {

                if (result.Response.IsOfferable && result.Response.IsSolid)
                {
                    result.Response.AccountId = Convert.ToInt32(identifier);
                    result.Response.OfferedValue = resource.OfferPrice;
                    var check = _productService.UpdateAsync(resource.OfferId, result.Response);

                }
               
            }
            catch (Exception)
            {

                return BadRequest();
            }

            return StatusCode(201);

        }

        [HttpPost("cancel-product/{id:int}")]
        public async Task<IActionResult> CancelProduct(int id)
        {
            var identifier = (User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.NameIdentifier).Value;

            var result = await _productService.GetByIdAsync(id);

            if (!result.Success)
            {
                return BadRequest();
            }
            if(result.Response.IsOfferable && result.Response.IsSolid)
            {
                if (result.Response.AccountId == Convert.ToInt32(identifier))
                {
                    var tempProduct = result.Response;
                    tempProduct.OfferedValue = 0;
                    tempProduct.AccountId = 0;
                    var check = _productService.UpdateAsync(id, tempProduct);
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
            

            return StatusCode(201);
        }

        [HttpPost("buy-product")]
        public async Task<IActionResult> BuyProduct(OfferRequest resource)
        {
            var identifier = (User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.NameIdentifier).Value;

            var result = await _productService.GetByIdAsync(resource.OfferId);
            if (!result.Success)
            {
                return BadRequest();
            }
            try
            {

                if (result.Response.IsOfferable && result.Response.IsSolid)
                {
                    if(result.Response.Price == resource.OfferPrice)
                    {
                        result.Response.AccountId = Convert.ToInt32(identifier);
                        result.Response.OfferedValue = resource.OfferPrice;
                        result.Response.IsSolid = false;
                        result.Response.IsOfferable = false;
                        var check = _productService.UpdateAsync(resource.OfferId, result.Response);
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception)
            {

                return BadRequest();
            }

            return StatusCode(201);
        }
    }
}
