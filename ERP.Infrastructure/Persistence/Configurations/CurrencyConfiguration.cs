using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations;

public sealed class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
{
    public void Configure(EntityTypeBuilder<Currency> builder)
    {
        builder.ToTable("CURRENCY", "dbo");
        builder.HasKey(x => x.CurrencyCode);

        builder.Property(x => x.Id)
            .HasColumnName("ID")
            .HasPrecision(22, 0)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CurrencyCode).HasColumnName("CURRENCY").HasMaxLength(10).IsRequired();
        builder.Property(x => x.BaseCurrency).HasColumnName("BASECURRENCY").HasMaxLength(10).IsRequired();
        builder.Property(x => x.Factor1).HasColumnName("FACTOR1").HasPrecision(22, 3).IsRequired();
        builder.Property(x => x.Factor2).HasColumnName("FACTOR2").HasPrecision(22, 3).IsRequired();
        builder.Property(x => x.DecimalPlace).HasColumnName("DECIMALPLACE").HasPrecision(22, 3).IsRequired();

        builder.Property(x => x.CreateDt).HasColumnName("CREATEDT").IsRequired();
        builder.Property(x => x.CreateTm).HasColumnName("CREATETM").IsRequired();
        builder.Property(x => x.CreateBy).HasColumnName("CREATEBY").HasMaxLength(10).IsRequired();
        builder.Property(x => x.CreateRemarks).HasColumnName("CREATEREMARKS").HasMaxLength(200).IsRequired();
        builder.Property(x => x.UpdateDt).HasColumnName("UPDATEDT").IsRequired();
        builder.Property(x => x.UpdateTm).HasColumnName("UPDATETM").IsRequired();
        builder.Property(x => x.UpdateBy).HasColumnName("UPDATEBY").HasMaxLength(10).IsRequired();
        builder.Property(x => x.UpdateRemarks).HasColumnName("UPDATEMARKS").HasMaxLength(200).IsRequired();
    }
}
