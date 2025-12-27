using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations;

public sealed class PoB2BConfiguration : IEntityTypeConfiguration<PoB2B>
{
    public void Configure(EntityTypeBuilder<PoB2B> b)
    {
        b.ToTable("POB2B", "dbo");
        b.HasKey(x => new { x.Fran, x.Branch, x.Warehouse, x.B2BType, x.B2BNo, x.B2BSrl });

        b.Property(x => x.Fran).HasColumnName("FRAN").HasMaxLength(10).IsRequired();
        b.Property(x => x.Branch).HasColumnName("BRCH").HasMaxLength(10).IsRequired();
        b.Property(x => x.Warehouse).HasColumnName("WHSE").HasMaxLength(10).IsRequired();
        b.Property(x => x.B2BType).HasColumnName("B2BTYPE").HasMaxLength(25).IsRequired();
        b.Property(x => x.B2BNo).HasColumnName("B2BNO").HasMaxLength(100).IsRequired();
        b.Property(x => x.B2BSrl).HasColumnName("B2BSRL").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.B2BDate).HasColumnName("B2BDT").IsRequired();
        b.Property(x => x.Make).HasColumnName("MAKE").HasMaxLength(10).IsRequired();
        b.Property(x => x.Part).HasColumnName("PART").HasMaxLength(28).IsRequired();
        b.Property(x => x.OrdPart).HasColumnName("ORDPART").HasMaxLength(28);
        b.Property(x => x.Qty).HasColumnName("QTY").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.OrdQty).HasColumnName("ORDQTY").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.PoQty).HasColumnName("POQTY").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.UnitPrice).HasColumnName("UNITPRICE").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.NetValue).HasColumnName("NETVALUE").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.Currency).HasColumnName("CURRENCY").HasMaxLength(10).IsRequired();
        b.Property(x => x.Customer).HasColumnName("CUSTOMER").HasMaxLength(50).IsRequired();
        b.Property(x => x.Status).HasColumnName("STATUS").HasMaxLength(10).IsRequired();
        b.Property(x => x.RefType).HasColumnName("REFTYPE").HasMaxLength(25).IsRequired();
        b.Property(x => x.RefNo).HasColumnName("REFNO").HasMaxLength(100).IsRequired();
        b.Property(x => x.RefSrl).HasColumnName("REFSRL").HasPrecision(6, 0).IsRequired();
        b.Property(x => x.UnitPack).HasColumnName("UNITPACK").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.PoType).HasColumnName("POTYPE").HasMaxLength(50).IsRequired();
        b.Property(x => x.PoNo).HasColumnName("PONO").HasMaxLength(100).IsRequired();
        b.Property(x => x.PoSrl).HasColumnName("POSRL").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.Vendor).HasColumnName("VENDOR").HasMaxLength(10).IsRequired();
        b.Property(x => x.StoreId).HasColumnName("STOREID").HasMaxLength(10).IsRequired();

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
