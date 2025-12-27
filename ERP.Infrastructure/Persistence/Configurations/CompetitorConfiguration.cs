using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations;

public sealed class CompetitorConfiguration : IEntityTypeConfiguration<Competitor>
{
    public void Configure(EntityTypeBuilder<Competitor> b)
    {
        b.ToTable("COMPETITOR", "dbo");
        b.HasKey(x => x.CompetitorCode);

        b.Property(x => x.Id).HasColumnName("ID").HasPrecision(22, 0).ValueGeneratedOnAdd();
        b.Property(x => x.CompetitorCode).HasColumnName("COMPETITOR").HasMaxLength(10).IsRequired();
        b.Property(x => x.Name).HasColumnName("NAME").HasMaxLength(100).IsRequired();
        b.Property(x => x.NameAr).HasColumnName("NAMEAR").HasMaxLength(100).IsRequired();
        b.Property(x => x.Phone).HasColumnName("PHONE").HasMaxLength(50).IsRequired();
        b.Property(x => x.Email).HasColumnName("EMAIL").HasMaxLength(100).IsRequired();
        b.Property(x => x.Address).HasColumnName("ADDRESS").HasMaxLength(100).IsRequired();
        b.Property(x => x.VatNo).HasColumnName("VATNO").HasMaxLength(50).IsRequired();

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
