using GestioneClientiOrdini.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestioneClientiOrdini.Core.EF.Configurations
{
    // definizione delle fluent API per l'entità Order
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // Id è Primary Key per convenzione

            builder
                .Property(o => o.Code)
                .HasMaxLength(4)
                .IsRequired();

            builder
                .Property(o => o.ProductCode)
                .HasMaxLength(4)
                .IsRequired();

            // relazione 1 a molti tra Ordine e Cliente:
            // un Ordine fa riferimento a un solo Cliente,
            // un Cliente può fare più Ordini
            builder
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId);

            builder
                .Property(o => o.Cancelled)
                .HasDefaultValue(false); // default value per Cancelled = false
        }
    }
}