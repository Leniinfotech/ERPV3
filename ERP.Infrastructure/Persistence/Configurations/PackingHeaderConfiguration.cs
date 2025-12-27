using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations;

public sealed class PackingHeaderConfiguration : IEntityTypeConfiguration<PackingHeader>
{
    public void Configure(EntityTypeBuilder<PackingHeader> b)
    {
        b.ToTable("PACKHDR", "dbo");
        b.HasKey(x => new { x.Fran, x.Branch, x.Warehouse, x.PackType, x.PackNo });

        b.Property(x => x.Fran).HasColumnName("FRAN").HasMaxLength(10).IsRequired();
        b.Property(x => x.Branch).HasColumnName("BRCH").HasMaxLength(10).IsRequired();
        b.Property(x => x.Warehouse).HasColumnName("WHSE").HasMaxLength(10).IsRequired();
        b.Property(x => x.PackType).HasColumnName("PACKTYPE").HasMaxLength(10).IsRequired();
        b.Property(x => x.PackNo).HasColumnName("PACKNO").HasMaxLength(100).IsRequired();
        b.Property(x => x.PackDate).HasColumnName("PACKDT").HasColumnType("date").IsRequired();
        b.Property(x => x.Customer).HasColumnName("CUSTOMER").HasMaxLength(50).IsRequired();
        b.Property(x => x.Currency).HasColumnName("CURRENCY").HasMaxLength(10).IsRequired();
        b.Property(x => x.CurrFactor).HasColumnName("CURRFACTOR").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.DespFactor).HasColumnName("DESPFACTOR").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.NoOfCrtn).HasColumnName("NOOFCRTN").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.GrossValue).HasColumnName("GROSSVALUE").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.NetValue).HasColumnName("NETVALUE").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.NetWeight).HasColumnName("NETWEIGHT").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.GrossWeight).HasColumnName("GROSSWEIGHT").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.SeqPrefix).HasColumnName("SEQPREFIX").HasMaxLength(100).IsRequired();
        b.Property(x => x.SeqNo).HasColumnName("SEQNO").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.NoOfItems).HasColumnName("NOOFITEMS").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.Status).HasColumnName("STATUS").HasMaxLength(10).IsRequired();

        // Audit
        b.Property(x => x.CreateDt).HasColumnName("CREATEDT").HasColumnType("date").IsRequired();
        b.Property(x => x.CreateTm).HasColumnName("CREATETM").HasColumnType("datetime").IsRequired();
        b.Property(x => x.CreateBy).HasColumnName("CREATEBY").HasMaxLength(10).IsRequired();
        b.Property(x => x.CreateRemarks).HasColumnName("CREATEREMARKS").HasMaxLength(100).IsRequired();
        b.Property(x => x.UpdateDt).HasColumnName("UPDATEDT").HasColumnType("date").IsRequired();
        b.Property(x => x.UpdateTm).HasColumnName("UPDATETM").HasColumnType("datetime").IsRequired();
        b.Property(x => x.UpdateBy).HasColumnName("UPDATEBY").HasMaxLength(10).IsRequired();
        b.Property(x => x.UpdateRemarks).HasColumnName("UPDATEREMARKS").HasMaxLength(100).IsRequired();

        b.HasMany(x => x.Lines)
         .WithOne(d => d.Header)
         .HasForeignKey(d => new { d.Fran, d.Branch, d.Warehouse, d.PackType, d.PackNo })
         .HasPrincipalKey(h => new { h.Fran, h.Branch, h.Warehouse, h.PackType, h.PackNo });
    }
}
