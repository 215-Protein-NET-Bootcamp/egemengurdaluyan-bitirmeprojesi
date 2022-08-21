using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProteinApi.Data
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<Product> GetByIdAsync(int id, bool hasToken)
        {
            var queryable = Context.Product.Where(x => x.ProductId.Equals(id));
            return await queryable.SingleOrDefaultAsync();
        }

    }
}
