using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations;

public sealed class SaleDetailConfiguration : IEntityTypeConfiguration<SaleDetail>
{
    public void Configure(EntityTypeBuilder<SaleDetail> b)
    {
        b.ToTable("SALEDET", "dbo");
        b.HasKey(x => new { x.Fran, x.Branch, x.Warehouse, x.SaleType, x.SaleNo, x.SalesRl });

        b.Property(x => x.Fran).HasColumnName("FRAN").HasMaxLength(10).IsRequired();
        b.Property(x => x.Branch).HasColumnName("BRCH").HasMaxLength(10).IsRequired();
        b.Property(x => x.Warehouse).HasColumnName("WHSE").HasMaxLength(10).IsRequired();
        b.Property(x => x.SaleType).HasColumnName("SALETYPE").HasMaxLength(50).IsRequired();
        b.Property(x => x.SaleNo).HasColumnName("SALENO").HasMaxLength(10).IsRequired();
        b.Property(x => x.SalesRl).HasColumnName("SALESRL").HasMaxLength(10).IsRequired();

        b.Property(x => x.SaleDate).HasColumnName("SALEDT").HasColumnType("date").IsRequired();
        b.Property(x => x.Make).HasColumnName("MAKE").HasMaxLength(10).IsRequired();
        b.Property(x => x.Part).HasColumnName("PART").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.Qty).HasColumnName("QTY").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.UnitPrice).HasColumnName("UNITPRICE").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.Discount).HasColumnName("DISCOUNT").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.VatPercentage).HasColumnName("VATPERCENTAGE").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.VatValue).HasColumnName("VATVALUE").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.DiscountValue).HasColumnName("DISCOUNTVALUE").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.TotalValue).HasColumnName("TOTALVALUE").HasPrecision(22, 3).IsRequired();

        // Audit
        b.Property(x => x.CreateDt).HasColumnName("CREATEDT").HasColumnType("date").IsRequired();
        b.Property(x => x.CreateTm).HasColumnName("CREATETM").HasColumnType("datetime").IsRequired();
        b.Property(x => x.CreateBy).HasColumnName("CREATEBY").HasMaxLength(10).IsRequired();
        b.Property(x => x.CreateRemarks).HasColumnName("CREATEREMARKS").HasMaxLength(100).IsRequired();
        b.Property(x => x.UpdateDt).HasColumnName("UPDATEDT").HasColumnType("date").IsRequired();
        b.Property(x => x.UpdateTm).HasColumnName("UPDATETM").HasColumnType("datetime").IsRequired();
        b.Property(x => x.UpdateBy).HasColumnName("UPDATEBY").HasMaxLength(10).IsRequired();
        b.Property(x => x.UpdateRemarks).HasColumnName("UPDATEREMARKS").HasMaxLength(100).IsRequired();

        b.HasOne(x => x.Header)
         .WithMany(h => h.Lines)
         .HasForeignKey(x => new { x.Fran, x.Branch, x.Warehouse, x.SaleType, x.SaleNo })
         .HasPrincipalKey(h => new { h.Fran, h.Branch, h.Warehouse, h.SaleType, h.SaleNo });
    }
}
