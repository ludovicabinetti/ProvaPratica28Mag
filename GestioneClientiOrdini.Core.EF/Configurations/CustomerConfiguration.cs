using GestioneClientiOrdini.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestioneClientiOrdini.Core.EF.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        // definizione delle fluent API per l'entità Customer
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            // Id è Primary Key per convenzione

            builder
                .Property(c => c.Code)
                .HasMaxLength(4)
                .IsRequired();

            builder
                .Property(c => c.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder
                .Property(c => c.Surname)
                .HasMaxLength(255)
                .IsRequired();
        }
    }
}