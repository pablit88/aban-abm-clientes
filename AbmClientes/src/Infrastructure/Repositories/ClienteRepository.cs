using Aban.AbmClientes.Core.Entities;
using Aban.AbmClientes.Core.Interfaces.Repositories;
using Aban.AbmClientes.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Aban.AbmClientes.Infrastructure.Repositories
{
    public class ClienteRepository : EFRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(AbmClientesDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Cliente>> GetByNombresAsync(string nombres)
        {
            return await _dbContext.Clientes
                .Where(c=> EF.Functions.Like(c.Nombres, $"%{nombres}%") )
                .ToListAsync();
        }
    }
}
