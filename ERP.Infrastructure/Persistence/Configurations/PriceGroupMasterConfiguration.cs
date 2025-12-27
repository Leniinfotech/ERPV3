using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations;

public sealed class PriceGroupMasterConfiguration : IEntityTypeConfiguration<PriceGroupMaster>
{
    public void Configure(EntityTypeBuilder<PriceGroupMaster> b)
    {
        b.ToTable("PGRPMST", "dbo");
        b.HasKey(x => new { x.Fran, x.PrcType, x.PrcGrp });

        b.Property(x => x.Fran).HasColumnName("FRAN").HasMaxLength(10).IsRequired();
        b.Property(x => x.PrcType).HasColumnName("PRCTYPE").HasMaxLength(50).IsRequired();
        b.Property(x => x.PrcGrp).HasColumnName("PRCGRP").HasMaxLength(50).IsRequired();
        b.Property(x => x.Flag1).HasColumnName("FLAG1").HasMaxLength(10).IsRequired();
        b.Property(x => x.Flag2).HasColumnName("FLAG2").HasMaxLength(10).IsRequired();
        b.Property(x => x.Flag3).HasColumnName("FLAG3").HasMaxLength(10).IsRequired();
        b.Property(x => x.Factor1).HasColumnName("FACTOR1").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.Factor2).HasColumnName("FACTOR2").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.Factor3).HasColumnName("FACTOR3").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.Remarks).HasColumnName("REMARKS").HasMaxLength(200).IsRequired();

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
