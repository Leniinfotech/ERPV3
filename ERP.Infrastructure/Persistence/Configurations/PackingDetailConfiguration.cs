using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations;

public sealed class PackingDetailConfiguration : IEntityTypeConfiguration<PackingDetail>
{
    public void Configure(EntityTypeBuilder<PackingDetail> b)
    {
        b.ToTable("PACKDET", "dbo");
        b.HasKey(x => new { x.Fran, x.Branch, x.Warehouse, x.PackType, x.PackNo, x.PackSrl });

        b.Property(x => x.Fran).HasColumnName("FRAN").HasMaxLength(10).IsRequired();
        b.Property(x => x.Branch).HasColumnName("BRCH").HasMaxLength(10).IsRequired();
        b.Property(x => x.Warehouse).HasColumnName("WHSE").HasMaxLength(10).IsRequired();
        b.Property(x => x.PackType).HasColumnName("PACKTYPE").HasMaxLength(10).IsRequired();
        b.Property(x => x.PackNo).HasColumnName("PACKNO").HasMaxLength(100).IsRequired();
        b.Property(x => x.PackSrl).HasColumnName("PACKSRL").HasPrecision(22, 0).IsRequired();

        b.Property(x => x.Customer).HasColumnName("CUSTOMER").HasMaxLength(100).IsRequired();
        b.Property(x => x.CrtnType).HasColumnName("CRTNTYPE").HasMaxLength(25).IsRequired();
        b.Property(x => x.Crtn).HasColumnName("CRTN").HasMaxLength(25).IsRequired();
        b.Property(x => x.MsCrtn).HasColumnName("MSCRTN").HasMaxLength(25).IsRequired();
        b.Property(x => x.CrtnSrl).HasColumnName("CRTNSRL").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.Make).HasColumnName("MAKE").HasMaxLength(10).IsRequired();
        b.Property(x => x.Part).HasColumnName("PART").HasMaxLength(28).IsRequired();
        b.Property(x => x.Qty).HasColumnName("QTY").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.UnitRate).HasColumnName("UNITRATE").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.NetValue).HasColumnName("NETVALUE").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.PickType).HasColumnName("PICKTYPE").HasMaxLength(10).IsRequired();
        b.Property(x => x.PickNo).HasColumnName("PICKNO").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.PickSrl).HasColumnName("PICKSRL").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.CordType).HasColumnName("CORDTYPE").HasMaxLength(10).IsRequired();
        b.Property(x => x.CordNo).HasColumnName("CORDNO").HasMaxLength(100).IsRequired();
        b.Property(x => x.CordSrl).HasColumnName("CORDSRL").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.LotNo).HasColumnName("LOTNO").HasMaxLength(100).IsRequired();
        b.Property(x => x.PdCoo).HasColumnName("PDCOO").HasMaxLength(100).IsRequired();
        b.Property(x => x.PdHsCode).HasColumnName("PDHSCODE").HasMaxLength(100).IsRequired();
        b.Property(x => x.NetWeight).HasColumnName("NETWEIGHT").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.GrossWeight).HasColumnName("GROSSWEIGHT").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.UnitNetWeight).HasColumnName("UNITNETWEIGHT").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.UnitGrossWeight).HasColumnName("UNITGROSSWEIGHT").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.GrossValue).HasColumnName("GROSSVALUE").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.PdStoreId).HasColumnName("PDSTOREID").HasMaxLength(10).IsRequired();
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
         .HasForeignKey(x => new { x.Fran, x.Branch, x.Warehouse, x.PackType, x.PackNo })
         .HasPrincipalKey(h => new { h.Fran, h.Branch, h.Warehouse, h.PackType, h.PackNo });
    }
}
