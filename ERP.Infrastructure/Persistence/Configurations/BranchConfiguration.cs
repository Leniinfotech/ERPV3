using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations;

public sealed class BranchConfiguration : IEntityTypeConfiguration<Branch>
{
    public void Configure(EntityTypeBuilder<Branch> builder)
    {
        builder.ToTable("BRCH", "dbo");

        // PK: BRCH (numeric(22,0))
        builder.HasKey(b => b.BranchCode);

        builder.Property(b => b.BranchCode)
            .HasColumnName("BRCH")
            .HasPrecision(22, 0)
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(b => b.Fran)
            .HasColumnName("FRAN")
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(b => b.RefNo)
            .HasColumnName("REFNO")
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(b => b.Name)
            .HasColumnName("NAME")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(b => b.NameAr)
            .HasColumnName("NAMEAR")
            .HasMaxLength(100)
            .IsUnicode()
            .IsRequired();

        // Audit
        builder.Property(b => b.CreateDt).HasColumnName("CREATEDT").IsRequired();
        builder.Property(b => b.CreateTm).HasColumnName("CREATETM").IsRequired();
        builder.Property(b => b.CreateBy).HasColumnName("CREATEBY").HasMaxLength(10).IsRequired();
        builder.Property(b => b.CreateRemarks).HasColumnName("CREATEREMARKS").HasMaxLength(200).IsRequired();
        builder.Property(b => b.UpdateDt).HasColumnName("UPDATEDT").IsRequired();
        builder.Property(b => b.UpdateTm).HasColumnName("UPDATETM").IsRequired();
        builder.Property(b => b.UpdateBy).HasColumnName("UPDATEBY").HasMaxLength(10).IsRequired();
        builder.Property(b => b.UpdateRemarks).HasColumnName("UPDATEMARKS").HasMaxLength(200).IsRequired();
    }
}
