using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations;

public sealed class ReceiptDetailConfiguration : IEntityTypeConfiguration<ReceiptDetail>
{
    public void Configure(EntityTypeBuilder<ReceiptDetail> b)
    {
        b.ToTable("RECTDET", "dbo");
        b.HasKey(x => new { x.Fran, x.Branch, x.Warehouse, x.ReceiptType, x.ReceiptNo, x.ReceiptSerial });

        b.Property(x => x.Fran).HasColumnName("FRAN").HasMaxLength(10).IsRequired();
        b.Property(x => x.Branch).HasColumnName("BRCH").HasMaxLength(10).IsRequired();
        b.Property(x => x.Warehouse).HasColumnName("WHSE").HasMaxLength(10).IsRequired();
        b.Property(x => x.ReceiptType).HasColumnName("RECTTYPE").HasMaxLength(25).IsRequired();
        b.Property(x => x.ReceiptNo).HasColumnName("RECTNO").HasMaxLength(25).IsRequired();
        b.Property(x => x.ReceiptSerial).HasColumnName("RECTSRL").HasPrecision(22, 0).IsRequired();

        b.Property(x => x.Make).HasColumnName("MAKE").HasMaxLength(10).IsRequired();
        b.Property(x => x.Part).HasColumnName("PART").HasMaxLength(28).IsRequired();
        b.Property(x => x.Qty).HasColumnName("QTY").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.UnitPrice).HasColumnName("UNITPRICE").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.NetValue).HasColumnName("NETVALUE").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.Currency).HasColumnName("CURRENCY").HasMaxLength(10).IsRequired();
        b.Property(x => x.StoreId).HasColumnName("STOREID").HasMaxLength(10).IsRequired();
        b.Property(x => x.Vendor).HasColumnName("VENDOR").HasMaxLength(10).IsRequired();
        b.Property(x => x.PoType).HasColumnName("POTYPE").HasMaxLength(50).IsRequired();
        b.Property(x => x.PoNo).HasColumnName("PONO").HasMaxLength(100).IsRequired();
        b.Property(x => x.PoSrl).HasColumnName("POSRL").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.Remarks).HasColumnName("REMARKS").HasMaxLength(50);
        b.Property(x => x.Status).HasColumnName("STATUS").HasMaxLength(10).IsRequired();

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
            .HasForeignKey(d => new { d.Fran, d.Branch, d.Warehouse, d.ReceiptType, d.ReceiptNo })
            .HasPrincipalKey(h => new { h.Fran, h.Branch, h.Warehouse, h.ReceiptType, h.ReceiptNo });
    }
}
