using Smarti.Services.Interfaces;
using SuperMS.Application.Repository.Interface;
using SuperMS.Domain;

namespace Smarti.Services
{
    public class CategoriesService: Interfaces.CategoriesService
    {
      

        private readonly IRepository<CategoriesEntity> _categoriesRepository;
        public CategoriesService(IRepository<CategoriesEntity> categoriesRepository)
        {
            _categoriesRepository= categoriesRepository;
        }


        public async Task<IEnumerable<CategoriesEntity>> GetCategories()
        {
           var result=await _categoriesRepository.GetAllAsync();
            return result;

        }



    }
}
