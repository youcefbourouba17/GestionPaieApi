using System.Linq.Expressions;

namespace GestionPaieApi.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<ICollection<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveAsync();
    }
}
