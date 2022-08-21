using AutoMapper;
using ProteinApi.Base;
using ProteinApi.Data;
using ProteinApi.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProteinApi.Service
{
    public class CategoryService : BaseService<CategoryDto, Category>, ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(categoryRepository, mapper, unitOfWork)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<BaseResponse<CategoryDto>> UpdateCategoryAsync(int id, UpdateNameRequest resource)
        {
            try
            {
                // Validate Id is existent?
                var tempCategory = await categoryRepository.GetByIdAsync(id, hasToken: true);
                if (tempCategory is null)
                    return new BaseResponse<CategoryDto>("Category_NoData");

                // Update infomation
                tempCategory.Name = resource.NewName;

                await UnitOfWork.CompleteAsync();

                return new BaseResponse<CategoryDto>(Mapper.Map<CategoryDto>(tempCategory));
            }
            catch (Exception ex)
            {
                throw new MessageResultException("Account_Updating_Error", ex);
            }
        }
    }
}
