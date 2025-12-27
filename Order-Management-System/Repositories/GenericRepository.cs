using Order_Management_System.Context;
using Order_Management_System.Repositories.Interface;

namespace Order_Management_System.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly OrderManagementSystemContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(OrderManagementSystemContext _context)
        {
            this._context = _context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
            => await _dbSet.AddAsync(entity);

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await Task.CompletedTask;
        }
             

        public async Task<IEnumerable<T>> GetAllAsync()
            => await _dbSet.ToListAsync();

        public async Task<T?> GetByIdAsync(Guid id)
            => await _dbSet.FindAsync(id);

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await Task.CompletedTask;
        }
    }
}
