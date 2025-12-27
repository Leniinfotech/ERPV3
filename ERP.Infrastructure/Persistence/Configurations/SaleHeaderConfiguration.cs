using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations;

public sealed class SaleHeaderConfiguration : IEntityTypeConfiguration<SaleHeader>
{
    public void Configure(EntityTypeBuilder<SaleHeader> b)
    {
        b.ToTable("SALEHDR", "dbo");
        b.HasKey(x => new { x.Fran, x.Branch, x.Warehouse, x.SaleType, x.SaleNo });

        b.Property(x => x.Fran).HasColumnName("FRAN").HasMaxLength(10).IsRequired();
        b.Property(x => x.Branch).HasColumnName("BRCH").HasMaxLength(10).IsRequired();
        b.Property(x => x.Warehouse).HasColumnName("WHSE").HasMaxLength(10).IsRequired();
        b.Property(x => x.SaleType).HasColumnName("SALETYPE").HasMaxLength(50).IsRequired();
        b.Property(x => x.SaleNo).HasColumnName("SALENO").HasMaxLength(10).IsRequired();

        b.Property(x => x.SaleDate).HasColumnName("SALEDT").HasColumnType("date").IsRequired();
        b.Property(x => x.CustomerCode).HasColumnName("CUSTOMER").HasMaxLength(10).IsRequired();
        b.Property(x => x.Currency).HasColumnName("CURRENCY").HasMaxLength(10).IsRequired();
        b.Property(x => x.NoOfItems).HasColumnName("NOOFITEMS").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.Discount).HasColumnName("DISCOUNT").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.TotalValue).HasColumnName("TOTALVALUE").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.SeqNo).HasColumnName("SEQNO").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.SeqPrefix).HasColumnName("SEQPREFIX").HasMaxLength(20).IsRequired();
        b.Property(x => x.SalesChannel).HasColumnName("SALESCHANNEL").HasMaxLength(20).IsRequired();

        // Audit
        b.Property(x => x.CreateDt).HasColumnName("CREATEDT").HasColumnType("date").IsRequired();
        b.Property(x => x.CreateTm).HasColumnName("CREATETM").HasColumnType("datetime").IsRequired();
        b.Property(x => x.CreateBy).HasColumnName("CREATEBY").HasMaxLength(10).IsRequired();
        b.Property(x => x.CreateRemarks).HasColumnName("CREATEREMARKS").HasMaxLength(100).IsRequired();
        b.Property(x => x.UpdateDt).HasColumnName("UPDATEDT").HasColumnType("date").IsRequired();
        b.Property(x => x.UpdateTm).HasColumnName("UPDATETM").HasColumnType("datetime").IsRequired();
        b.Property(x => x.UpdateBy).HasColumnName("UPDATEBY").HasMaxLength(10).IsRequired();
        b.Property(x => x.UpdateRemarks).HasColumnName("UPDATEREMARKS").HasMaxLength(100).IsRequired();

        // NEW COLUMNS
        b.Property(x => x.InvoiceNo).HasColumnName("INVOICENO").HasMaxLength(20).IsRequired();
        b.Property(x => x.InvoiceDate).HasColumnName("INVOICEDATE").HasColumnType("date").IsRequired();
        b.Property(x => x.DueDate).HasColumnName("DUEDATE").HasColumnType("datetime").IsRequired();

    }
}
