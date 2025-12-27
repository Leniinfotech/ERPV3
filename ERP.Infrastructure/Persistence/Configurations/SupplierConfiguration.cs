using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations;

public sealed class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> b)
    {
        b.ToTable("VENDOR", "dbo");
        b.HasKey(x => x.SupplierCode);

        // Physical PK column name in legacy schema appears to be VENDOR
        // Change: Updated SupplierCode max length from old value to 10
        // Reason: Aligning with actual database column definition (VENDOR VARCHAR(10))
        // Added by: Vaishnavi
        // Added on: 10-12-2025
        b.Property(x => x.SupplierCode).HasColumnName("VENDOR").HasMaxLength(10).IsRequired();
        b.Property(x => x.Name).HasColumnName("NAME").HasMaxLength(100);
        b.Property(x => x.NameAr).HasColumnName("NAMEAR").HasMaxLength(100);
        b.Property(x => x.Phone).HasColumnName("PHONE").HasMaxLength(50);
        b.Property(x => x.Email).HasColumnName("EMAIL").HasMaxLength(100);
        b.Property(x => x.Address).HasColumnName("ADDRESS").HasMaxLength(200);
        b.Property(x => x.VatNo).HasColumnName("VATNO").HasMaxLength(50);
    }
}