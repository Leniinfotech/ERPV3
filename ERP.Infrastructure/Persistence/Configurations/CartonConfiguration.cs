using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations;

public sealed class CartonConfiguration : IEntityTypeConfiguration<Carton>
{
    public void Configure(EntityTypeBuilder<Carton> b)
    {
        b.ToTable("CRTN", "dbo");
        b.HasKey(x => new { x.Fran, x.CrtnType, x.CrtnCatg });

        b.Property(x => x.Id).HasColumnName("ID").HasPrecision(22, 0).ValueGeneratedOnAdd();
        b.Property(x => x.Fran).HasColumnName("FRAN").HasMaxLength(10).IsRequired();
        b.Property(x => x.CrtnCatg).HasColumnName("CRTNCATG").HasMaxLength(50).IsRequired();
        b.Property(x => x.CrtnType).HasColumnName("CRTNTYPE").HasMaxLength(50).IsRequired();
        b.Property(x => x.CrtnDesc).HasColumnName("CRTNDESC").HasMaxLength(100).IsRequired();
        b.Property(x => x.Length).HasColumnName("LENGTH").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.Width).HasColumnName("WIDTH").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.Height).HasColumnName("HEIGHT").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.Volume).HasColumnName("VOLUME").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.MinWeight).HasColumnName("MINWEIGHT").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.MaxWeight).HasColumnName("MAXWEIGHT").HasPrecision(22, 3).IsRequired();

        // Audit
        b.Property(x => x.CreateDt).HasColumnName("CREATEDT").HasColumnType("date").IsRequired();
        b.Property(x => x.CreateTm).HasColumnName("CREATETM").HasColumnType("datetime").IsRequired();
        b.Property(x => x.CreateBy).HasColumnName("CREATEBY").HasMaxLength(10).IsRequired();
        b.Property(x => x.CreateRemarks).HasColumnName("CREATEREMARKS").HasMaxLength(200).IsRequired();
        b.Property(x => x.UpdateDt).HasColumnName("UPDATEDT").HasColumnType("date").IsRequired();
        b.Property(x => x.UpdateTm).HasColumnName("UPDATETM").HasColumnType("datetime").IsRequired();
        b.Property(x => x.UpdateBy).HasColumnName("UPDATEBY").HasMaxLength(10).IsRequired();
        b.Property(x => x.UpdateMarks).HasColumnName("UPDATEMARKS").HasMaxLength(200).IsRequired();

        // No reliable FK to CRTNDET (column names don't align with CRTN PK); keep aggregate independent.
        // Prevent EF from inferring a relationship that would create shadow FK columns on CRTNDET
        b.Ignore(x => x.Lines);
    }
}
