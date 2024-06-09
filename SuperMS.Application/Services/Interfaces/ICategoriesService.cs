namespace SuperMS.Domain
{
    public interface ICategoriesService
    {
        Task<IEnumerable<CategoriesEntity>> GetCategories();

    }
}
