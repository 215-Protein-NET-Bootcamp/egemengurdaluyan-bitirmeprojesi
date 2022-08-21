using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProteinApi.Data
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category> GetByIdAsync(int id, bool hasToken);
    }
}
