using Aban.AbmClientes.Core.Entities;

namespace Aban.AbmClientes.Core.Interfaces.Repositories
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
