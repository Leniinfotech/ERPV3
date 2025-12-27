using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations;

public sealed class CartonDetailConfiguration : IEntityTypeConfiguration<CartonDetail>
{
    public void Configure(EntityTypeBuilder<CartonDetail> b)
    {
        b.ToTable("CRTNDET", "dbo");
        b.HasKey(x => new { x.CDFRAN, x.CDBRCH, x.CDWHSE, x.CDCRTN, x.CDCRTNTYPE, x.CDCRTNSRL });

        b.Property(x => x.CDFRAN).HasColumnName("CDFRAN").HasMaxLength(10).IsRequired();
        b.Property(x => x.CDBRCH).HasColumnName("CDBRCH").HasMaxLength(10).IsRequired();
        b.Property(x => x.CDWHSE).HasColumnName("CDWHSE").HasMaxLength(10).IsRequired();
        b.Property(x => x.CDCRTN).HasColumnName("CDCRTN").HasMaxLength(25).IsRequired();
        b.Property(x => x.CDCRTNTYPE).HasColumnName("CDCRTNTYPE").HasMaxLength(25).IsRequired();
        b.Property(x => x.CDCRTNSRL).HasColumnName("CDCRTNSRL").HasPrecision(22, 0).IsRequired();

        b.Property(x => x.CDPART).HasColumnName("CDPART").HasMaxLength(28).IsRequired();
        b.Property(x => x.CDMAKE).HasColumnName("CDMAKE").HasMaxLength(10).IsRequired();
        b.Property(x => x.CDQTY).HasColumnName("CDQTY").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.CDCKDQTY).HasColumnName("CDCKDQTY").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.CDUNCKDQTY).HasColumnName("CDUNCKDQTY").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.CDPICKTYPE).HasColumnName("CDPICKTYPE").HasMaxLength(10).IsRequired();
        b.Property(x => x.CDPICKNO).HasColumnName("CDPICKNO").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.CDPICKSRL).HasColumnName("CDPICKSRL").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.CDREFTYPE).HasColumnName("CDREFTYPE").HasMaxLength(10).IsRequired();
        b.Property(x => x.CDREFNO).HasColumnName("CDREFNO").HasMaxLength(100).IsRequired();
        b.Property(x => x.CDREFSRL).HasColumnName("CDREFSRL").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.CDLOTNO).HasColumnName("CDLOTNO").HasMaxLength(100).IsRequired();
        b.Property(x => x.CDSTATUS).HasColumnName("CDSTATUS").HasMaxLength(10).IsRequired();
        b.Property(x => x.CDCUST).HasColumnName("CDCUST").HasMaxLength(100).IsRequired();
        b.Property(x => x.CDPKGCODE).HasColumnName("CDPKGCODE").HasMaxLength(50).IsRequired();
        b.Property(x => x.CDCOO).HasColumnName("CDCOO").HasMaxLength(100).IsRequired();
        b.Property(x => x.CDHSCODE).HasColumnName("CDHSCODE").HasMaxLength(100).IsRequired();
        b.Property(x => x.CDNETWEIGHT).HasColumnName("CDNETWEIGHT").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.CDGROSSWEIGHT).HasColumnName("CDGROSSWEIGHT").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.CDSUGGCOO).HasColumnName("CDSUGGCOO").HasMaxLength(100).IsRequired();
        b.Property(x => x.CDSUGGHSCODE).HasColumnName("CDSUGGHSCODE").HasMaxLength(100).IsRequired();
        b.Property(x => x.CDUNITNETWEIGHT).HasColumnName("CDUNITNETWEIGHT").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.CDUNITGROSSWEIGHT).HasColumnName("CDUNITGROSSWEIGHT").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.CDGROSSWEIGHT_ADJUSTED).HasColumnName("CDGROSSWEIGHT_ADJUSTED").HasPrecision(22, 13).IsRequired();
        b.Property(x => x.CDREMARKS).HasColumnName("CDREMARKS").HasMaxLength(200).IsRequired();

        // Audit (DATETIME columns in table)
        b.Property(x => x.CDCREATEDT).HasColumnName("CDCREATEDT").HasColumnType("datetime").IsRequired();
        b.Property(x => x.CDCREATETM).HasColumnName("CDCREATETM").HasColumnType("datetime").IsRequired();
        b.Property(x => x.CDCREATEBY).HasColumnName("CDCREATEBY").HasMaxLength(10).IsRequired();
        b.Property(x => x.CDCREATEREMARKS).HasColumnName("CDCREATEREMARKS").HasMaxLength(200).IsRequired();
        b.Property(x => x.CDUPDATEDT).HasColumnName("CDUPDATEDT").HasColumnType("datetime").IsRequired();
        b.Property(x => x.CDUPDATETM).HasColumnName("CDUPDATETM").HasColumnType("datetime").IsRequired();
        b.Property(x => x.CDUPDATEBY).HasColumnName("CDUPDATEBY").HasMaxLength(10).IsRequired();
        b.Property(x => x.CDUPDATEREMARKS).HasColumnName("CDUPDATEREMARKS").HasMaxLength(200).IsRequired();
    }
}
