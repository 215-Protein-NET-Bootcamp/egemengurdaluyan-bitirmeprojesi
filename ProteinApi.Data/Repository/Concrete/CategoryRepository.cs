using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProteinApi.Data
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<Category> GetByIdAsync(int id, bool hasToken)
        {
            var queryable = Context.Category.Where(x => x.CategoryId.Equals(id));
            return await queryable.SingleOrDefaultAsync();
        }
    }
}
