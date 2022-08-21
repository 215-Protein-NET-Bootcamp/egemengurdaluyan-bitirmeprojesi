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
    public interface ICategoryService : IBaseService<CategoryDto,Category>
    {
        Task<BaseResponse<CategoryDto>> UpdateCategoryAsync(int id, UpdateNameRequest resource);
    }
}
