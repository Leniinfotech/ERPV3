using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations;

public sealed class MakeConfiguration : IEntityTypeConfiguration<Make>
{
    public void Configure(EntityTypeBuilder<Make> builder)
    {
        builder.ToTable("MAKE", "dbo");
        builder.HasKey(x => new { x.Fran, x.MakeCode });

        builder.Property(x => x.Id)
            .HasColumnName("ID")
            .HasPrecision(22, 0)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Fran).HasColumnName("FRAN").HasMaxLength(10).IsRequired();
        builder.Property(x => x.MakeCode).HasColumnName("MAKE").HasMaxLength(10).IsRequired();
        builder.Property(x => x.Name).HasColumnName("NAME").HasMaxLength(100).IsRequired();
        builder.Property(x => x.NameAr).HasColumnName("NAMEAR").HasMaxLength(100).IsUnicode().IsRequired();

        builder.Property(x => x.CreateDt).HasColumnName("CREATEDT").IsRequired();
        builder.Property(x => x.CreateTm).HasColumnName("CREATETM").IsRequired();
        builder.Property(x => x.CreateBy).HasColumnName("CREATEBY").HasMaxLength(10).IsRequired();
        builder.Property(x => x.CreateRemarks).HasColumnName("CREATEREMARKS").HasMaxLength(200).IsRequired();
        builder.Property(x => x.UpdateDt).HasColumnName("UPDATEDT").IsRequired();
        builder.Property(x => x.UpdateTm).HasColumnName("UPDATETM").IsRequired();
        builder.Property(x => x.UpdateBy).HasColumnName("UPDATEBY").HasMaxLength(10).IsRequired();
        builder.Property(x => x.UpdateRemarks).HasColumnName("UPDATEREMARKS").HasMaxLength(200).IsRequired();
    }
}
