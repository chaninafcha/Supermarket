using Microsoft.EntityFrameworkCore;
using SuperMS.Domain;
using System.Threading.Tasks;

namespace SuperMS.Application.Repository.Interface
{
    public interface IRepository<T>  where T : class
    {
         IQueryable<T> Queryable();
         IQueryable<T> Untracked();

         Task<IEnumerable<T>> GetAllAsync();
         Task<T> GetByIdAsync(int id);

          Task AddAsync(T entity);

          Task UpdateAsync(T entity);

          Task DeleteAsync(int id);
       
    }
}
