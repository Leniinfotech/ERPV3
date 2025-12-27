using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations;

public sealed class WorkshopConfiguration : IEntityTypeConfiguration<Workshop>
{
    public void Configure(EntityTypeBuilder<Workshop> b)
    {
        b.ToTable("WORKSHOP", "dbo");
        b.HasKey(x => new { x.Fran, x.WorkshopId });

        b.Property(x => x.Fran).HasColumnName("FRAN").HasMaxLength(10).IsRequired();
        b.Property(x => x.WorkshopId).HasColumnName("WORKSHOP").HasPrecision(10, 0).IsRequired();
        b.Property(x => x.Name).HasColumnName("NAME").HasMaxLength(150).IsRequired();

        // Audit
        b.Property(x => x.CreateDt).HasColumnName("CREATEDT").HasColumnType("date").IsRequired();
        b.Property(x => x.CreateTm).HasColumnName("CREATETM").HasColumnType("datetime").IsRequired();
        b.Property(x => x.CreateBy).HasColumnName("CREATEBY").HasMaxLength(10).IsRequired();
        b.Property(x => x.CreateRemarks).HasColumnName("CREATEREMARKS").HasMaxLength(100).IsRequired();
        b.Property(x => x.UpdateDt).HasColumnName("UPDATEDT").HasColumnType("date").IsRequired();
        b.Property(x => x.UpdateTm).HasColumnName("UPDATETM").HasColumnType("datetime").IsRequired();
        b.Property(x => x.UpdateBy).HasColumnName("UPDATEBY").HasMaxLength(10).IsRequired();
        b.Property(x => x.UpdateRemarks).HasColumnName("UPDATEREMARKS").HasMaxLength(100).IsRequired();
    }
}
