using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations;

public sealed class PurchaseOrderConfiguration : IEntityTypeConfiguration<PurchaseOrder>
{
    public void Configure(EntityTypeBuilder<PurchaseOrder> b)
    {
        b.ToTable("POHDR", "dbo");
        b.HasKey(x => new { x.Fran, x.Branch, x.WarehouseCode, x.PoType, x.PoNumber });

        b.Property(x => x.Fran).HasColumnName("FRAN").HasMaxLength(10).IsRequired();
        b.Property(x => x.Branch).HasColumnName("BRCH").HasMaxLength(10).IsRequired();
        b.Property(x => x.WarehouseCode).HasColumnName("WHSE").HasMaxLength(10).IsRequired();
        b.Property(x => x.PoType).HasColumnName("POTYPE").HasMaxLength(50).IsRequired();
        b.Property(x => x.PoNumber).HasColumnName("PONO").HasMaxLength(10).IsRequired();
        b.Property(x => x.PoDate).HasColumnName("PODT").IsRequired();
        b.Property(x => x.SupplierCode).HasColumnName("VENDOR").HasMaxLength(10).IsRequired();
        b.Property(x => x.SupplierRefNo).HasColumnName("VENDORREFNO").HasMaxLength(10).IsRequired();
        b.Property(x => x.Currency).HasColumnName("CURRENCY").HasMaxLength(10).IsRequired();
        b.Property(x => x.NoOfItems).HasColumnName("NOOFITEMS").IsRequired();
        b.Property(x => x.Discount).HasColumnName("DISCOUNT").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.TotalValue).HasColumnName("TOTALVALUE").HasPrecision(22, 3).IsRequired();

        // Audit
        b.Property(x => x.CreateDt).HasColumnName("CREATEDT").IsRequired();
        b.Property(x => x.CreateTm).HasColumnName("CREATETM").IsRequired();
        b.Property(x => x.CreateBy).HasColumnName("CREATEBY").HasMaxLength(10).IsRequired();
        b.Property(x => x.CreateRemarks).HasColumnName("CREATEREMARKS").HasMaxLength(100).IsRequired();
        b.Property(x => x.UpdateDt).HasColumnName("UPDATEDT").IsRequired();
        b.Property(x => x.UpdateTm).HasColumnName("UPDATETM").IsRequired();
        b.Property(x => x.UpdateBy).HasColumnName("UPDATEBY").HasMaxLength(10).IsRequired();
        b.Property(x => x.UpdateRemarks).HasColumnName("UPDATEREMARKS").HasMaxLength(100).IsRequired();

        b.HasOne(x => x.Supplier)
            .WithMany(s => s.PurchaseOrders)
            .HasForeignKey(x => x.SupplierCode)
            .HasPrincipalKey(s => s.SupplierCode);
    }
}