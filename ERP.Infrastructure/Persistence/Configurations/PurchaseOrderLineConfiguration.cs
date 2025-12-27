using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations;

public sealed class PurchaseOrderLineConfiguration : IEntityTypeConfiguration<PurchaseOrderLine>
{
    public void Configure(EntityTypeBuilder<PurchaseOrderLine> b)
    {
        b.ToTable("PODET", "dbo");
        b.HasKey(x => new { x.Fran, x.Branch, x.WarehouseCode, x.PoType, x.PoNumber, x.PoLineNumber });

        b.Property(x => x.Fran).HasColumnName("FRAN").HasMaxLength(10).IsRequired();
        b.Property(x => x.Branch).HasColumnName("BRCH").HasMaxLength(10).IsRequired();
        b.Property(x => x.WarehouseCode).HasColumnName("WHSE").HasMaxLength(10).IsRequired();
        b.Property(x => x.PoType).HasColumnName("POTYPE").HasMaxLength(50).IsRequired();
        b.Property(x => x.PoNumber).HasColumnName("PONO").HasMaxLength(10).IsRequired();
        b.Property(x => x.PoLineNumber).HasColumnName("POSRL").HasMaxLength(10).IsRequired();
        b.Property(x => x.PoDate).HasColumnName("PODT").IsRequired();
        b.Property(x => x.SupplierCode).HasColumnName("VENDOR").HasMaxLength(10).IsRequired();
        b.Property(x => x.PlanType).HasColumnName("PLANTYPE").HasMaxLength(10).IsRequired();
        b.Property(x => x.PlanNo).HasColumnName("PLANNO").HasMaxLength(100).IsRequired();
        b.Property(x => x.PlanSerial).HasColumnName("PLANSRL").IsRequired();
        b.Property(x => x.Make).HasColumnName("MAKE").HasMaxLength(10).IsRequired();

        b.Property(x => x.PartCode)
            .HasColumnName("PART")
            .HasMaxLength(10)
            .IsRequired();

        b.Property(x => x.Qty).HasColumnName("QTY").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.UnitPrice).HasColumnName("UNITPRICE").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.Discount).HasColumnName("DISCOUNT").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.VatPercentage).HasColumnName("VATPERCENTAGE").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.VatValue).HasColumnName("VATVALUE").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.DiscountValue).HasColumnName("DISCOUNTVALUE").HasPrecision(22, 3).IsRequired();
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

        b.HasOne(x => x.PurchaseOrder)
            .WithMany(h => h.Lines)
            .HasForeignKey(x => new { x.Fran, x.Branch, x.WarehouseCode, x.PoType, x.PoNumber })
            .HasPrincipalKey(h => new { h.Fran, h.Branch, h.WarehouseCode, h.PoType, h.PoNumber });

        b.HasOne(x => x.Part)
            .WithMany(p => p.PurchaseOrderLines)
            .HasForeignKey(x => x.PartCode);
    }
}