using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations;

public sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> b)
    {
        b.ToTable("CUSTOMER", "dbo");
        b.HasKey(x => x.CustomerCode);

        b.Property(x => x.CustomerCode).HasColumnName("CUSTOMER").HasMaxLength(10).IsRequired();
        b.Property(x => x.Id).HasColumnName("ID").HasPrecision(22, 0).ValueGeneratedOnAdd();
        b.Property(x => x.Name).HasColumnName("NAME").HasMaxLength(100).IsRequired();
        b.Property(x => x.NameAr).HasColumnName("NAMEAR").HasMaxLength(100).IsRequired();
        b.Property(x => x.Phone).HasColumnName("PHONE").HasMaxLength(20).IsRequired();
        b.Property(x => x.Email).HasColumnName("EMAIL").HasMaxLength(100).IsRequired();
        b.Property(x => x.Address).HasColumnName("ADDRESS").HasMaxLength(200).IsRequired();
        b.Property(x => x.VatNo).HasColumnName("VATNO").HasMaxLength(20).IsRequired();

        // Audit
        b.Property(x => x.CreateDt).HasColumnName("CREATEDT").HasColumnType("date").IsRequired();
        b.Property(x => x.CreateTm).HasColumnName("CREATETM").HasColumnType("datetime").IsRequired();
        b.Property(x => x.CreateBy).HasColumnName("CREATEBY").HasMaxLength(10).IsRequired();
        b.Property(x => x.CreateRemarks).HasColumnName("CREATEREMARKS").HasMaxLength(200).IsRequired();
        b.Property(x => x.UpdateDt).HasColumnName("UPDATEDT").HasColumnType("date").IsRequired();
        b.Property(x => x.UpdateTm).HasColumnName("UPDATETM").HasColumnType("date").IsRequired();
        b.Property(x => x.UpdateBy).HasColumnName("UPDATEBY").HasMaxLength(10).IsRequired();
        b.Property(x => x.UpdateRemarks).HasColumnName("UPDATEMARKS").HasMaxLength(200).IsRequired();
    }
}
