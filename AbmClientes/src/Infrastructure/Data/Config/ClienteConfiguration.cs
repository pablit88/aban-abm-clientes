using Aban.AbmClientes.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aban.AbmClientes.Infrastructure.Data.Config
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            // Primary Key
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            // Properties
            builder.Property(c => c.Nombres).IsRequired().HasMaxLength(64);
            builder.Property(c => c.Apellidos).IsRequired().HasMaxLength(64);
            builder.Property(c => c.FechaDeNacimiento).IsRequired().HasColumnType("date");

            builder.Property(c => c.Cuit)
                .IsRequired()
                .HasMaxLength(11)
                .IsUnicode(false);

            builder.Property(c => c.Domicilio).IsRequired().HasMaxLength(128);
            builder.Property(c => c.Celular).IsRequired().HasMaxLength(32);

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(512)
                .IsUnicode(false);

            // Indexes
            builder.HasIndex(c => c.Cuit)
                .IsUnique()
                .HasFilter("[Cuit] IS NOT NULL");

            builder.HasIndex(c => c.Email)
                .IsUnique()
                .HasFilter("[Email] IS NOT NULL");
        }
    }
}
