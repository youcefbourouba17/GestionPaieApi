using GestionPaieApi.Data;
using GestionPaieApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GestionPaieApi.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly Db_context _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(Db_context context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveAsync();
        }

        
        public async void Delete(T entity)
        {
            _dbSet.Remove(entity);
            await SaveAsync();
        }

        

        public async Task<ICollection<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id); 
        }
        public async Task<T> GetByIdAsync(string id)
        {
            return await _dbSet.FindAsync(id);
        }


        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        
        public async void Update(T entity)
        {
             _dbSet.Update(entity);
            await SaveAsync();
        }
    }
}
