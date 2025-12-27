using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations;

public sealed class CustomerOrderDetailConfiguration : IEntityTypeConfiguration<CustomerOrderDetail>
{
    public void Configure(EntityTypeBuilder<CustomerOrderDetail> b)
    {
        b.ToTable("CORDDET", "dbo");
        b.HasKey(x => new { x.Fran, x.Branch, x.Warehouse, x.CordType, x.CordNo, x.CordSrl });

        b.Property(x => x.Fran).HasColumnName("FRAN").HasMaxLength(10).IsRequired();
        b.Property(x => x.Branch).HasColumnName("BRCH").HasMaxLength(10).IsRequired();
        b.Property(x => x.Warehouse).HasColumnName("WHSE").HasMaxLength(10).IsRequired();
        b.Property(x => x.CordType).HasColumnName("CORDTYPE").HasMaxLength(50).IsRequired();
        b.Property(x => x.CordNo).HasColumnName("CORDNO").HasMaxLength(10).IsRequired();
        b.Property(x => x.CordSrl).HasColumnName("CORDSRL").HasMaxLength(10).IsRequired();
        b.Property(x => x.CordDate).HasColumnName("CORDDT").IsRequired();
        b.Property(x => x.Make).HasColumnName("MAKE").HasMaxLength(10).IsRequired();
        b.Property(x => x.Part).HasColumnName("PART").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.Qty).HasColumnName("QTY").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.AccpQty).HasColumnName("ACCPQTY").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.NotAvlQty).HasColumnName("NOTAVLQTY").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.Price).HasColumnName("PRICE").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.Discount).HasColumnName("DISCOUNT").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.VatPercentage).HasColumnName("VATPERCENTAGE").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.VatValue).HasColumnName("VATVALUE").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.DiscountValue).HasColumnName("DISCOUNTVALUE").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.TotalValue).HasColumnName("TOTALVALUE").HasPrecision(22, 3).IsRequired();

        b.Property(x => x.CreateDt).HasColumnName("CREATEDT").IsRequired();
        b.Property(x => x.CreateTm).HasColumnName("CREATETM").IsRequired();
        b.Property(x => x.CreateBy).HasColumnName("CREATEBY").HasMaxLength(10).IsRequired();
        b.Property(x => x.CreateRemarks).HasColumnName("CREATEREMARKS").HasMaxLength(100).IsRequired();
        b.Property(x => x.UpdateDt).HasColumnName("UPDATEDT").IsRequired();
        b.Property(x => x.UpdateTm).HasColumnName("UPDATETM").IsRequired();
        b.Property(x => x.UpdateBy).HasColumnName("UPDATEBY").HasMaxLength(10).IsRequired();
        b.Property(x => x.UpdateRemarks).HasColumnName("UPDATEREMARKS").HasMaxLength(100).IsRequired();
    }
}
