using Microsoft.EntityFrameworkCore;
using SuperMS.Application;
using SuperMS.Application.Models;
using SuperMS.Application.Repository.Interface;


namespace SuperMS.Domain
{
    public class ProductService : IProductsService
    {
      

        private readonly IRepository<ProductEntity> _productRepository;
        public ProductService(IRepository<ProductEntity> productRepository)
        {
            _productRepository = productRepository;
        }


        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
           var query=await _productRepository.GetAllAsync();
           var result= query.GroupBy(x=>x.category).Select(x=>new ProductDTO { 
               name=x.Select(x=>x.name).FirstOrDefault(),
               category=x.Select(x=>x.category).FirstOrDefault(),
               quantity=x.Where(x=>x.name==x.name).Count(),
           }).Distinct();

            return result;
        }

        public async Task<IEnumerable<ProductEntity>> GetProductsByCategory(int category)
        {
            var result = await _productRepository.Queryable().Where(x => x.category == category).ToListAsync();
            return result;
        }

        public async Task<ResponseMessage<ProductEntity>>AddProducts(ProductDTO product)
        {
            if(product == null)
            {

                return new ResponseMessage<ProductEntity>(false,"no Data",null);
            }
            ProductEntity entity = new ProductEntity { name = product.name, category = product.id  };
            await _productRepository.AddAsync(entity);
            return new ResponseMessage<ProductEntity>(true,"succses", entity);
        }



    }
}
