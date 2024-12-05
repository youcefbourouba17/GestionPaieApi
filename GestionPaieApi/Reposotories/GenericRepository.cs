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
        }

        
        public void Delete(T entity)
        {
            _dbSet.Remove(entity); 
        }

        
        public async Task<ICollection<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public Task<ICollection<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            throw new NotImplementedException();
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

        
        public void Update(T entity)
        {
            _dbSet.Update(entity); 
        }
    }
}
