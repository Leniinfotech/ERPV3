using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations;

public sealed class SubsPartConfiguration : IEntityTypeConfiguration<SubsPart>
{
    public void Configure(EntityTypeBuilder<SubsPart> b)
    {
        b.ToTable("SUBSPART", "dbo");
        b.HasKey(x => new { x.Fran, x.Make, x.Part, x.FinalPart, x.GrpNo });

        b.Property(x => x.Fran).HasColumnName("FRAN").HasMaxLength(10).IsRequired();
        b.Property(x => x.Make).HasColumnName("MAKE").HasMaxLength(28).IsRequired();
        b.Property(x => x.Part).HasColumnName("PART").HasMaxLength(28).IsRequired();
        b.Property(x => x.FinalPart).HasColumnName("FINLPART").HasMaxLength(28).IsRequired();
        b.Property(x => x.GrpNo).HasColumnName("GRPNO").HasPrecision(4, 0).IsRequired();
        b.Property(x => x.PsSubSeq).HasColumnName("PSSUBSEQ").HasPrecision(22, 0).IsRequired();

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
