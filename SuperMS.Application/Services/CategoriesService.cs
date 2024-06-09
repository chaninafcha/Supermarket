
using SuperMS.Application.Repository.Interface;

namespace SuperMS.Domain
{
    public class CategoriesService: ICategoriesService
    {
      

        private readonly IRepository<CategoriesEntity> _categoriesRepository;
        public CategoriesService(IRepository<CategoriesEntity> categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }


        public async Task<IEnumerable<CategoriesEntity>> GetCategories()
        {
            var result = await _categoriesRepository.GetAllAsync();
            return result;
   ;

        }



    }
}
