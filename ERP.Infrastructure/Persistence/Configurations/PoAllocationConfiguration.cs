using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations;

public sealed class PoAllocationConfiguration : IEntityTypeConfiguration<PoAllocation>
{
    public void Configure(EntityTypeBuilder<PoAllocation> b)
    {
        b.ToTable("POALDT1", "dbo");
        b.HasKey(x => new { x.Fran, x.Branch, x.Warehouse, x.AlocSrl });

        b.Property(x => x.Fran).HasColumnName("FRAN").HasMaxLength(10).IsRequired();
        b.Property(x => x.Branch).HasColumnName("BRCH").HasMaxLength(10).IsRequired();
        b.Property(x => x.Warehouse).HasColumnName("WHSE").HasMaxLength(10).IsRequired();
        b.Property(x => x.AlocSrl).HasColumnName("ALOCSRL").HasPrecision(22, 0).ValueGeneratedOnAdd();
        b.Property(x => x.AlocType).HasColumnName("ALOCTYPE").HasMaxLength(25).IsRequired();
        b.Property(x => x.AlocDate).HasColumnName("ALOCDT").IsRequired();
        b.Property(x => x.Part).HasColumnName("PART").HasMaxLength(28).IsRequired();
        b.Property(x => x.Make).HasColumnName("MAKE").HasMaxLength(10).IsRequired();
        b.Property(x => x.OrdPart).HasColumnName("ORDPART").HasMaxLength(28).IsRequired();
        b.Property(x => x.Qty).HasColumnName("QTY").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.UnitPrice).HasColumnName("UNITPRICE").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.NetValue).HasColumnName("NETVALUE").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.Status).HasColumnName("STATUS").HasMaxLength(10).IsRequired();
        b.Property(x => x.RefType).HasColumnName("REFTYPE").HasMaxLength(25).IsRequired();
        b.Property(x => x.RefNo).HasColumnName("REFNO").HasMaxLength(100).IsRequired();
        b.Property(x => x.RefSrl).HasColumnName("REFSRL").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.RefSource).HasColumnName("REFSOURCE").HasMaxLength(25).IsRequired();
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
