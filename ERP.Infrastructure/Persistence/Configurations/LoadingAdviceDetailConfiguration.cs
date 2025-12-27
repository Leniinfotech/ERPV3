using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations;

public sealed class LoadingAdviceDetailConfiguration : IEntityTypeConfiguration<LoadingAdviceDetail>
{
    public void Configure(EntityTypeBuilder<LoadingAdviceDetail> b)
    {
        b.ToTable("LADET", "dbo");
        b.HasKey(x => new { x.Fran, x.Branch, x.Warehouse, x.LaType, x.LaNo, x.CrtnType, x.Crtn });

        b.Property(x => x.Fran).HasColumnName("FRAN").HasMaxLength(10).IsRequired();
        b.Property(x => x.Branch).HasColumnName("BRCH").HasMaxLength(10).IsRequired();
        b.Property(x => x.Warehouse).HasColumnName("WHSE").HasMaxLength(10).IsRequired();
        b.Property(x => x.LaType).HasColumnName("LATYPE").HasMaxLength(10).IsRequired();
        b.Property(x => x.LaNo).HasColumnName("LANO").HasMaxLength(100).IsRequired();
        b.Property(x => x.CrtnType).HasColumnName("CRTNTYPE").HasMaxLength(25).IsRequired();
        b.Property(x => x.Crtn).HasColumnName("CRTN").HasMaxLength(25).IsRequired();
        b.Property(x => x.DocDate).HasColumnName("DOCDT").IsRequired();
        b.Property(x => x.CntrNo).HasColumnName("CNTRNO").HasMaxLength(25).IsRequired();
        b.Property(x => x.CntrDate).HasColumnName("CNTRDT").IsRequired();
        b.Property(x => x.MsCrtn).HasColumnName("MSCRTN").HasMaxLength(25).IsRequired();
        b.Property(x => x.PackType).HasColumnName("PACKTYPE").HasMaxLength(10).IsRequired();
        b.Property(x => x.PackNo).HasColumnName("PACKNO").HasMaxLength(100).IsRequired();
        b.Property(x => x.Customer).HasColumnName("CUSTOMER").HasMaxLength(100).IsRequired();
        b.Property(x => x.InvType).HasColumnName("INVTYPE").HasMaxLength(50).IsRequired();
        b.Property(x => x.InvNo).HasColumnName("INVNO").HasMaxLength(100).IsRequired();
        b.Property(x => x.SubInvNo).HasColumnName("SUBINVNO").HasMaxLength(100).IsRequired();
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
