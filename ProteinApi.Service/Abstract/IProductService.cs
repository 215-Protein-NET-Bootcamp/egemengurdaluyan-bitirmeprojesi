using ProteinApi.Data;
using ProteinApi.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProteinApi.Service
{
    public interface IProductService :IBaseService<ProductDto, Product>
    {
        Task<List<Product>> GetAllOffers(int id);
    }
}
