using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations;

public sealed class ReceiptHeaderConfiguration : IEntityTypeConfiguration<ReceiptHeader>
{
    public void Configure(EntityTypeBuilder<ReceiptHeader> b)
    {
        b.ToTable("RECTHDR", "dbo");
        b.HasKey(x => new { x.Fran, x.Branch, x.Warehouse, x.ReceiptType, x.ReceiptNo });

        b.Property(x => x.Fran).HasColumnName("FRAN").HasMaxLength(10).IsRequired();
        b.Property(x => x.Branch).HasColumnName("BRCH").HasMaxLength(10).IsRequired();
        b.Property(x => x.Warehouse).HasColumnName("WHSE").HasMaxLength(10).IsRequired();
        b.Property(x => x.ReceiptType).HasColumnName("RECTTYPE").HasMaxLength(25).IsRequired();
        b.Property(x => x.ReceiptNo).HasColumnName("RECTNO").HasMaxLength(25).IsRequired();
        b.Property(x => x.ReceiptDate).HasColumnName("RECTDT").HasColumnType("date").IsRequired();
        b.Property(x => x.NoOfItems).HasColumnName("NOOFITEMS").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.NetValue).HasColumnName("NETVALUE").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.Currency).HasColumnName("CURRENCY").HasMaxLength(10).IsRequired();
        b.Property(x => x.Vendor).HasColumnName("VENDOR").HasMaxLength(10).IsRequired();
        b.Property(x => x.SeqPrefix).HasColumnName("SEQPREFIX").HasMaxLength(10).IsRequired();
        b.Property(x => x.SeqNo).HasColumnName("SEQNO").HasPrecision(22, 0).IsRequired();
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

        b.HasMany(x => x.Lines)
            .WithOne(d => d.Header)
            .HasForeignKey(d => new { d.Fran, d.Branch, d.Warehouse, d.ReceiptType, d.ReceiptNo })
            .HasPrincipalKey(h => new { h.Fran, h.Branch, h.Warehouse, h.ReceiptType, h.ReceiptNo });
    }
}
