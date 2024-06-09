using Microsoft.EntityFrameworkCore;
using Smarti.Services.Interfaces;
using SuperMS.Application;
using SuperMS.Application.Repository.Interface;
using SuperMS.Domain;

namespace Smarti.Services
{
    public class ProductService : Interfaces.ProductService
    {
      

        private readonly IRepository<ProductEntity> _productRepository;
        public ProductService(IRepository<ProductEntity> productRepository)
        {
            _productRepository = productRepository;
        }


        public async Task<IEnumerable<ProductEntity>> GetProducts()
        {
           var result=await _productRepository.GetAllAsync();
            return result;
        }

        public async Task<IEnumerable<ProductEntity>> GetProductsByCategory(int category)
        {
            var result = await _productRepository.Queryable().Where(x => x.Categories.id == category).ToListAsync();
            return result;
        }

        public async Task<ResponseMessage<ProductEntity>>AddProducts(ProductEntity product)
        {
            if(product == null)
            {

                return new ResponseMessage<ProductEntity>(false,"no Data",null);
            }

            await _productRepository.AddAsync(product);
            return new ResponseMessage<ProductEntity>(true,"succses", product);
        }



    }
}
