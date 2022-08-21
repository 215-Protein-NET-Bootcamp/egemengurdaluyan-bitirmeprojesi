using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProteinApi.Base;
using ProteinApi.Controllers;
using ProteinApi.Data;
using ProteinApi.Dto;
using ProteinApi.Service;

namespace ProteinApi.Auth
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : BaseController<CategoryDto, Category>
    {
        private readonly ICategoryService _categoryService;



        public CategoryController(ICategoryService categoryService, IMapper mapper) : base(categoryService, mapper)
        {
            this._categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CategoryDto resource)
        {

            var result = await _categoryService.InsertAsync(resource);

            if (!result.Success)
                return BadRequest(result);

            return StatusCode(201, result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateNameRequest resourse)
        {
            var result = await _categoryService.UpdateCategoryAsync(id,resourse);

            if (!result.Success)
                return BadRequest(result);

            return StatusCode(201, result);
        }

        [HttpDelete("{id:int}")]
        public new async Task<IActionResult> DeleteAsync(int id)
        {
            return await base.DeleteAsync(id);
        }

    }
}
