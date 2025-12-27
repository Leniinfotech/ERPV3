using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations;

public sealed class ParamsConfiguration : IEntityTypeConfiguration<Params>
{
    public void Configure(EntityTypeBuilder<Params> b)
    {
        b.ToTable("PARAMS", "dbo");
        b.HasKey(x => new { x.Fran, x.ParamType, x.ParamValue });

        b.Property(x => x.Id).HasColumnName("ID").HasPrecision(22, 0).ValueGeneratedOnAdd();
        b.Property(x => x.Fran).HasColumnName("FRAN").HasMaxLength(10).IsRequired();
        b.Property(x => x.ParamType).HasColumnName("PARAMTYPE").HasMaxLength(100).IsRequired();
        b.Property(x => x.ParamValue).HasColumnName("PARAMVALUE").HasMaxLength(100).IsRequired();
        b.Property(x => x.ParamValueStr1).HasColumnName("PARAMVALUESTR1").HasMaxLength(100).IsRequired();
        b.Property(x => x.ParamValueNum1).HasColumnName("PARAMVALUENUM1").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.ParamDesc).HasColumnName("PARAMDESC").HasMaxLength(200).IsRequired();
        b.Property(x => x.ParamCategory).HasColumnName("PARAMCATEGORY").HasMaxLength(50).IsRequired();
        b.Property(x => x.ParamRemarks).HasColumnName("PARAMREMARKS").HasMaxLength(200).IsRequired();

        b.Property(x => x.CreateDt).HasColumnName("CREATEDT").IsRequired();
        b.Property(x => x.CreateTm).HasColumnName("CREATETM").IsRequired();
        b.Property(x => x.CreateBy).HasColumnName("CREATEBY").HasMaxLength(10).IsRequired();
        b.Property(x => x.CreateRemarks).HasColumnName("CREATEREMARKS").HasMaxLength(200).IsRequired();
        b.Property(x => x.UpdateDt).HasColumnName("UPDATEDT").IsRequired();
        b.Property(x => x.UpdateTm).HasColumnName("UPDATETM").IsRequired();
        b.Property(x => x.UpdateBy).HasColumnName("UPDATEBY").HasMaxLength(10).IsRequired();
        b.Property(x => x.UpdateMarks).HasColumnName("UPDATEMARKS").HasMaxLength(200).IsRequired();
    }
}
