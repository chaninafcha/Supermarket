using SuperMS.Application;
using SuperMS.Application.Models;

namespace SuperMS.Domain
{
    public interface IProductsService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<IEnumerable<ProductEntity>> GetProductsByCategory(int category);
        Task<ResponseMessage<ProductEntity>> AddProducts(ProductDTO product);
    }
        
}
