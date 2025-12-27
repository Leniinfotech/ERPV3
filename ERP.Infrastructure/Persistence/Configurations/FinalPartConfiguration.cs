using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations;

public sealed class FinalPartConfiguration : IEntityTypeConfiguration<FinalPart>
{
    public void Configure(EntityTypeBuilder<FinalPart> b)
    {
        b.ToTable("FINALPART", "dbo");
        b.HasKey(x => new { x.Fran, x.Make, x.Part });

        b.Property(x => x.Fran).HasColumnName("FRAN").HasColumnType("char(10)").IsRequired();
        b.Property(x => x.Make).HasColumnName("MAKE").HasColumnType("char(10)").IsRequired();
        b.Property(x => x.Part).HasColumnName("PART").HasColumnType("char(28)").IsRequired();
        b.Property(x => x.OhQty).HasColumnName("OHQTY").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.OoQty).HasColumnName("OOQTY").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.CmSaleQty).HasColumnName("CMSALEQTY").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.LmSaleQty).HasColumnName("LMSALEQTY").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.M3SaleQty).HasColumnName("M3SALEQTY").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.M6SaleQty).HasColumnName("M6SALEQTY").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.M12SaleQty).HasColumnName("M12SALEQTY").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.M24SaleQty).HasColumnName("M24SALEQTY").HasPrecision(22, 0).IsRequired();

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
