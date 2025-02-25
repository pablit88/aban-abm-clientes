using Aban.AbmClientes.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Aban.AbmClientes.Infrastructure.Data
{
    public class AbmClientesDbContext : DbContext
    {
        public AbmClientesDbContext(DbContextOptions<AbmClientesDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            InitialClientesSeed(modelBuilder);
        }

        private void InitialClientesSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasData(
                new Cliente
                {
                    Id = 1,
                    Nombres = "Juan",
                    Apellidos = "Pérez",
                    FechaDeNacimiento = new DateOnly(1985, 5, 20),
                    Cuit = "20123456789",
                    Domicilio = "Calle Falsa 123",
                    Celular = "1122334455",
                    Email = "juan.perez@example.com"
                },
                new Cliente
                {
                    Id = 2,
                    Nombres = "María",
                    Apellidos = "González",
                    FechaDeNacimiento = new DateOnly(1990, 10, 15),
                    Cuit = "27345678901",
                    Domicilio = "Av. Siempre Viva 742",
                    Celular = "1198765432",
                    Email = "maria.gonzalez@example.com"
                },
                new Cliente
                {
                    Id = 3,
                    Nombres = "Mariano",
                    Apellidos = "Gomez",
                    FechaDeNacimiento = new DateOnly(1988, 5, 10),
                    Cuit = "27349878901",
                    Domicilio = "Av. Medrano 123",
                    Celular = "1132165432",
                    Email = "mariano.gomez@example.com"
                }
            );
        }
    }
}
