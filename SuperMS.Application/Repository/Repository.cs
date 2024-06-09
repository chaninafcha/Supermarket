using Microsoft.EntityFrameworkCore;
using SuperMS.Application.Repository.Interface;
using SuperMS.Domain;

namespace SuperMS.Application.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly CategoriesContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(CategoriesContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = context.Set<T>();
        }

        public IQueryable<T> Queryable() => _dbSet;
        public IQueryable<T> Untracked() => _dbSet.AsNoTracking();


        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }



}
