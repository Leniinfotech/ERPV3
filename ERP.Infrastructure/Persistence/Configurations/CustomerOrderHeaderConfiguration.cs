using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations;

public sealed class CustomerOrderHeaderConfiguration : IEntityTypeConfiguration<CustomerOrderHeader>
{
    public void Configure(EntityTypeBuilder<CustomerOrderHeader> b)
    {
        b.ToTable("CORDHDR", "dbo");
        b.HasKey(x => new { x.Fran, x.Branch, x.Warehouse, x.CordType, x.CordNo });

        b.Property(x => x.Fran).HasColumnName("FRAN").HasMaxLength(10).IsRequired();
        b.Property(x => x.Branch).HasColumnName("BRCH").HasMaxLength(10).IsRequired();
        b.Property(x => x.Warehouse).HasColumnName("WHSE").HasMaxLength(10).IsRequired();
        b.Property(x => x.CordType).HasColumnName("CORDTYPE").HasMaxLength(50).IsRequired();
        b.Property(x => x.CordNo).HasColumnName("CORDNO").HasMaxLength(10).IsRequired();
        b.Property(x => x.CordDate).HasColumnName("CORDDT").IsRequired();
        b.Property(x => x.Customer).HasColumnName("CUSTOMER").HasMaxLength(10).IsRequired();
        b.Property(x => x.SeqNo).HasColumnName("SEQNO").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.SeqPrefix).HasColumnName("SEQPREFIX").HasMaxLength(10).IsRequired();
        b.Property(x => x.Currency).HasColumnName("CURRENCY").HasMaxLength(10).IsRequired();
        b.Property(x => x.NoOfItems).HasColumnName("NOOFITEMS").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.DiscountValue).HasColumnName("DISCOUNTVALUE").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.GrossValue).HasColumnName("GROSSVALUE").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.NetValue).HasColumnName("NETVALUE").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.VatValue).HasColumnName("VATVALUE").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.TotalValue).HasColumnName("TOTALVALUE").HasPrecision(22, 3).IsRequired();

        b.Property(x => x.CreateDt).HasColumnName("CREATEDT").IsRequired();
        b.Property(x => x.CreateTm).HasColumnName("CREATETM").IsRequired();
        b.Property(x => x.CreateBy).HasColumnName("CREATEBY").HasMaxLength(10).IsRequired();
        b.Property(x => x.CreateRemarks).HasColumnName("CREATEREMARKS").HasMaxLength(100).IsRequired();
        b.Property(x => x.UpdateDt).HasColumnName("UPDATEDT").IsRequired();
        b.Property(x => x.UpdateTm).HasColumnName("UPDATETM").IsRequired();
        b.Property(x => x.UpdateBy).HasColumnName("UPDATEBY").HasMaxLength(10).IsRequired();
        b.Property(x => x.UpdateRemarks).HasColumnName("UPDATEREMARKS").HasMaxLength(100).IsRequired();

        b.HasMany(x => x.Lines)
         .WithOne(x => x.Header)
         .HasForeignKey(x => new { x.Fran, x.Branch, x.Warehouse, x.CordType, x.CordNo });
    }
}
