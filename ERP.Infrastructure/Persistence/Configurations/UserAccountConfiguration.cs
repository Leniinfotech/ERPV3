using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations;

public sealed class UserAccountConfiguration : IEntityTypeConfiguration<UserAccount>
{
    public void Configure(EntityTypeBuilder<UserAccount> b)
    {
        b.ToTable("USERS", "dbo");
        b.HasKey(x => new { x.Fran, x.UserId });

        b.Property(x => x.Fran).HasColumnName("FRAN").HasMaxLength(10).IsRequired();
        b.Property(x => x.UserId).HasColumnName("USERID").HasMaxLength(50).IsRequired();
        b.Property(x => x.Password).HasColumnName("PASSWORD").HasMaxLength(50).IsRequired();
        b.Property(x => x.Name).HasColumnName("NAME").HasMaxLength(250).IsRequired();
        b.Property(x => x.Email).HasColumnName("EMAIL").HasMaxLength(100).IsRequired();
        b.Property(x => x.EmailGroup).HasColumnName("EMAILGROUP").HasMaxLength(100).IsRequired();
        b.Property(x => x.Team).HasColumnName("TEAM").HasMaxLength(10).IsRequired();
        b.Property(x => x.Status).HasColumnName("STATUS").HasMaxLength(250).IsRequired();

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
