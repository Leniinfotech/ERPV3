using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations;

public sealed class InventoryLocationConfiguration : IEntityTypeConfiguration<InventoryLocation>
{
    public void Configure(EntityTypeBuilder<InventoryLocation> b)
    {
        b.ToTable("WHSE", "dbo");
        b.HasKey(x => x.WarehouseCode);

        b.Property(x => x.WarehouseCode).HasColumnName("WHSE").HasMaxLength(10).IsRequired();
        b.Property(x => x.Name).HasColumnName("NAME").HasMaxLength(100);
        b.Property(x => x.NameAr).HasColumnName("NAMEAR").HasMaxLength(100);

        // Required columns
        b.Property(x => x.Fran).HasColumnName("FRAN").HasMaxLength(10).IsRequired();
        b.Property(x => x.Branch).HasColumnName("BRCH").HasMaxLength(10).IsRequired();

        // Audit columns
        b.Property(x => x.CreateDt).HasColumnName("CREATEDT").HasColumnType("date").IsRequired();
        b.Property(x => x.CreateTm).HasColumnName("CREATETM").HasColumnType("datetime").IsRequired();
        b.Property(x => x.CreateBy).HasColumnName("CREATEBY").HasMaxLength(10).IsRequired();
        b.Property(x => x.CreateRemarks).HasColumnName("CREATEREMARKS").HasMaxLength(200).IsRequired();
        b.Property(x => x.UpdateDt).HasColumnName("UPDATEDT").HasColumnType("date").IsRequired();
        b.Property(x => x.UpdateTm).HasColumnName("UPDATETM").HasColumnType("datetime").IsRequired();
        b.Property(x => x.UpdateBy).HasColumnName("UPDATEBY").HasMaxLength(10).IsRequired();
        b.Property(x => x.UpdateRemarks).HasColumnName("UPDATEMARKS").HasMaxLength(200).IsRequired();
    }
}