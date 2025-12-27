using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations;

public sealed class LoadingAdviceHeaderConfiguration : IEntityTypeConfiguration<LoadingAdviceHeader>
{
    public void Configure(EntityTypeBuilder<LoadingAdviceHeader> b)
    {
        b.ToTable("LAHDR", "dbo");
        b.HasKey(x => new { x.Fran, x.Branch, x.Warehouse, x.LaType, x.LaNo });

        b.Property(x => x.Fran).HasColumnName("FRAN").HasMaxLength(10).IsRequired();
        b.Property(x => x.Branch).HasColumnName("BRCH").HasMaxLength(10).IsRequired();
        b.Property(x => x.Warehouse).HasColumnName("WHSE").HasMaxLength(10).IsRequired();
        b.Property(x => x.LaType).HasColumnName("LATYPE").HasMaxLength(10).IsRequired();
        b.Property(x => x.LaNo).HasColumnName("LANO").HasMaxLength(100).IsRequired();
        b.Property(x => x.LaDate).HasColumnName("LADT").IsRequired();
        b.Property(x => x.InvType).HasColumnName("INVTYPE").HasMaxLength(50).IsRequired();
        b.Property(x => x.InvNo).HasColumnName("INVNO").HasMaxLength(100).IsRequired();
        b.Property(x => x.Customer).HasColumnName("CUSTOMER").HasMaxLength(100).IsRequired();
        b.Property(x => x.SeqNo).HasColumnName("SEQNO").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.Vessel).HasColumnName("VESSEL").HasMaxLength(100).IsRequired();
        b.Property(x => x.PortDest).HasColumnName("PORTDEST").HasMaxLength(100).IsRequired();
        b.Property(x => x.Etd).HasColumnName("ETD").IsRequired();
        b.Property(x => x.Eta).HasColumnName("ETA").IsRequired();
        b.Property(x => x.LoadDate).HasColumnName("LOADDT").IsRequired();
        b.Property(x => x.Status).HasColumnName("STATUS").HasMaxLength(10).IsRequired();
        b.Property(x => x.NoOfCrtn).HasColumnName("NOOOFCRTN").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.Remarks).HasColumnName("REMARKS").HasMaxLength(100).IsRequired();

        b.Property(x => x.CreateDt).HasColumnName("CREATEDT").IsRequired();
        b.Property(x => x.CreateTm).HasColumnName("CREATETM").IsRequired();
        b.Property(x => x.CreateBy).HasColumnName("CREATEBY").HasMaxLength(10).IsRequired();
        b.Property(x => x.CreateRemarks).HasColumnName("CREATEREMARKS").HasMaxLength(100).IsRequired();
        b.Property(x => x.UpdateDt).HasColumnName("UPDATEDT").IsRequired();
        b.Property(x => x.UpdateTm).HasColumnName("UPDATETM").IsRequired();
        b.Property(x => x.UpdateBy).HasColumnName("UPDATEBY").HasMaxLength(10).IsRequired();
        b.Property(x => x.UpdateRemarks).HasColumnName("UPDATEREMARKS").HasMaxLength(100).IsRequired();

        b.HasMany(x => x.Details)
         .WithOne(x => x.Header)
         .HasForeignKey(x => new { x.Fran, x.Branch, x.Warehouse, x.LaType, x.LaNo });
    }
}
