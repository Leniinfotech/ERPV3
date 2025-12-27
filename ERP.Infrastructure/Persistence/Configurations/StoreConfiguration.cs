using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations;

public sealed class StoreConfiguration : IEntityTypeConfiguration<Store>
{
    public void Configure(EntityTypeBuilder<Store> builder)
    {
        builder.ToTable("STORE", "dbo");
        builder.HasKey(x => new { x.Fran, x.Branch, x.WarehouseCode, x.StoreCode });

        builder.Property(x => x.Fran).HasColumnName("FRAN").HasMaxLength(10).IsRequired();
        builder.Property(x => x.Branch).HasColumnName("BRCH").HasMaxLength(50).IsRequired();
        builder.Property(x => x.WarehouseCode).HasColumnName("WHSE").HasMaxLength(10).IsRequired();
        builder.Property(x => x.StoreCode).HasColumnName("STORE").HasMaxLength(250).IsRequired();
        builder.Property(x => x.Name).HasColumnName("NAME").HasMaxLength(250).IsRequired();

        builder.Property(x => x.CreateDt).HasColumnName("CREATEDT").IsRequired();
        builder.Property(x => x.CreateTm).HasColumnName("CREATETM").IsRequired();
        builder.Property(x => x.CreateBy).HasColumnName("CREATEBY").HasMaxLength(10).IsRequired();
        builder.Property(x => x.CreateRemarks).HasColumnName("CREATEREMARKS").HasMaxLength(100).IsRequired();
        builder.Property(x => x.UpdateDt).HasColumnName("UPDATEDT").IsRequired();
        builder.Property(x => x.UpdateTm).HasColumnName("UPDATETM").IsRequired();
        builder.Property(x => x.UpdateBy).HasColumnName("UPDATEBY").HasMaxLength(10).IsRequired();
        builder.Property(x => x.UpdateRemarks).HasColumnName("UPDATEREMARKS").HasMaxLength(100).IsRequired();
    }
}
