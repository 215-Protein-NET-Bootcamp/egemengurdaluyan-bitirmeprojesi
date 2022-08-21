using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProteinApi.Data
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<Product> GetByIdAsync(int id, bool hasToken);
    }
}
