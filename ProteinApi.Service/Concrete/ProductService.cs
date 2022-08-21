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
    public class ProductService : BaseService<ProductDto, Product>, IProductService
    {
        private readonly IProductRepository productRepository;
        public ProductService(IProductRepository productRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(productRepository, mapper, unitOfWork)
        {
            this.productRepository = productRepository;
        }

        public async Task<List<Product>> GetAllOffers(int id)
        {
            try
            {
                var tempProduct = await productRepository.GetAllAsync();

                var offerList = tempProduct.Where(x => x.AccountId == id);
               

                return new List<Product>(offerList.ToList());
            }
            catch (Exception ex)
            {
                throw new MessageResultException("Account_Updating_Error", ex);
            }
        }

        
    }
}
