using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations;

public sealed class AuthorityConfiguration : IEntityTypeConfiguration<Authority>
{
    public void Configure(EntityTypeBuilder<Authority> b)
    {
        b.ToTable("AUTHORITY", "dbo");
        b.HasKey(x => new { x.Fran, x.Type, x.UserId, x.Menu, x.SubMenu });

        b.Property(x => x.Fran).HasColumnName("FRAN").HasMaxLength(10).IsRequired();
        b.Property(x => x.Type).HasColumnName("TYPE").HasMaxLength(50).IsRequired();
        b.Property(x => x.UserId).HasColumnName("USERID").HasMaxLength(50).IsRequired();
        b.Property(x => x.Menu).HasColumnName("MENU").HasMaxLength(200).IsRequired();
        b.Property(x => x.SubMenu).HasColumnName("SUBMENU").HasMaxLength(200).IsRequired();
        b.Property(x => x.MenuText).HasColumnName("AUMENUTEXT").HasMaxLength(200).IsRequired();
        b.Property(x => x.SubMenuText).HasColumnName("AUSUBMENUTEXT").HasMaxLength(200).IsRequired();
        b.Property(x => x.Status).HasColumnName("STATUS").HasMaxLength(10).IsRequired();

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
