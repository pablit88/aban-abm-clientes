using Aban.AbmClientes.Core.Entities;

namespace Aban.AbmClientes.Core.Interfaces.Repositories
{
    public interface IClienteRepository: IAsyncRepository<Cliente>
    {
        Task<IEnumerable<Cliente>> GetByNombresAsync(string nombres);
    }
}
