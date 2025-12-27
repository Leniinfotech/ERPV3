using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations;

public sealed class PriceGroupFactorConfiguration : IEntityTypeConfiguration<PriceGroupFactor>
{
    public void Configure(EntityTypeBuilder<PriceGroupFactor> b)
    {
        b.ToTable("PGRPFACTOR", "dbo");
        b.HasKey(x => new { x.Fran, x.Type, x.PrcGrp, x.Name, x.Value });

        b.Property(x => x.Fran).HasColumnName("FRAN").HasMaxLength(10).IsRequired();
        b.Property(x => x.Type).HasColumnName("TYPE").HasMaxLength(20).IsRequired();
        b.Property(x => x.PrcGrp).HasColumnName("PRCGRP").HasMaxLength(50).IsRequired();
        b.Property(x => x.Name).HasColumnName("NAME").HasMaxLength(50).IsRequired();
        b.Property(x => x.Value).HasColumnName("VALUE").HasMaxLength(25).IsRequired();
        b.Property(x => x.Factor1).HasColumnName("FACTOR1").HasPrecision(22, 7).IsRequired();
        b.Property(x => x.Factor2).HasColumnName("FACTOR2").HasPrecision(22, 7).IsRequired();
        b.Property(x => x.Factor3).HasColumnName("FACTOR3").HasPrecision(22, 7).IsRequired();

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
