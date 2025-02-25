using Aban.AbmClientes.Core.Entities;
using Aban.AbmClientes.Infrastructure.Repositories;
using GenFu;

namespace Aban.AbmClientes.IntegrationTests.Repositories
{
    public class ClienteRepositoryTests : BaseRepositoryTests<Cliente>
    {
        private readonly ClienteRepository _clienteRepository;

        public ClienteRepositoryTests(): base() {
            _asyncRepository = new ClienteRepository(_context);
            _clienteRepository = (ClienteRepository)_asyncRepository;

            _context.Database.EnsureCreated();

            //DELETE ALL SEEDED DATA
            _context.Clientes.RemoveRange(_context.Clientes);
            _context.SaveChanges();
        }

        protected override Cliente GetEntity()
        {
            A.Configure<Cliente>()
                .Fill(c => c.Id, 0);

            return A.New<Cliente>();
        }

        protected override void ModifyEntity(Cliente entity)
        {
            entity.Nombres = "Pablito";
        }

        [Theory]
        [InlineData("Luis")]
        [InlineData("José Luis")]
        [InlineData("José Luis Félix")]
        public async Task GetByNombresAsync_When_Cliente_Matches_Nombres_Returns_Cliente(string nombresToSearch)
        {
            string matchingNombres = "José Luis Félix";
            string nonMatchingNombres = "Marcelo Fabián";

            A.Configure<Cliente>()
                .Fill(c => c.Nombres, matchingNombres);

            _context.Set<Cliente>().Add(A.New<Cliente>());

            A.Configure<Cliente>()
                .Fill(c => c.Nombres, nonMatchingNombres);

            _context.Set<Cliente>().Add(A.New<Cliente>());

            await _context.SaveChangesAsync();

            var foundClientes = await _clienteRepository.GetByNombresAsync(nombresToSearch);

            Assert.NotNull(foundClientes);
            Assert.True(foundClientes.Count() == 1);
            Assert.Equal(foundClientes.First().Nombres, matchingNombres);
        }

        [Theory]
        [InlineData("Esteban Armando")]
        [InlineData("José")]
        public async Task GetByNombresAsync_When_No_Cliente_Matches_Nombres_Returns_Empty(string notFoundNombres)
        {
            string nonMatchingNombres = "Marcelo Fabián";
            string otherNonMatchingNombres = "Jose";

            A.Configure<Cliente>()
                .Fill(c => c.Nombres, nonMatchingNombres);

            _context.Set<Cliente>().Add(A.New<Cliente>());

            A.Configure<Cliente>()
                .Fill(c => c.Nombres, otherNonMatchingNombres);

            _context.Set<Cliente>().Add(A.New<Cliente>());

            await _context.SaveChangesAsync();

            var foundClientes = await _clienteRepository.GetByNombresAsync(notFoundNombres);

            Assert.NotNull(foundClientes);
            Assert.Empty(foundClientes);
        }
    }
}
