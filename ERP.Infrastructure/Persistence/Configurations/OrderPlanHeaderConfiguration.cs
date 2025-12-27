using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations;

public sealed class OrderPlanHeaderConfiguration : IEntityTypeConfiguration<OrderPlanHeader>
{
    public void Configure(EntityTypeBuilder<OrderPlanHeader> b)
    {
        b.ToTable("OPLNHDR", "dbo");
        b.HasKey(x => new { x.Fran, x.Branch, x.Warehouse, x.PlanType, x.PlanNo });

        b.Property(x => x.Fran).HasColumnName("FRAN").HasColumnType("char(10)").IsRequired();
        b.Property(x => x.Branch).HasColumnName("BRCH").HasColumnType("char(10)").IsRequired();
        b.Property(x => x.Warehouse).HasColumnName("WHSE").HasColumnType("char(10)").IsRequired();
        b.Property(x => x.PlanType).HasColumnName("PLANTYPE").HasColumnType("char(10)").IsRequired();
        b.Property(x => x.PlanNo).HasColumnName("PLANNO").HasMaxLength(100).IsRequired();
        b.Property(x => x.PlanDate).HasColumnName("PLANDT").IsRequired();
        b.Property(x => x.TranType).HasColumnName("TRANTYPE").HasMaxLength(10).IsRequired();
        b.Property(x => x.SeqNo).HasColumnName("SEQNO").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.NoItems).HasColumnName("NOITEMS").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.NetValue).HasColumnName("NETVALUE").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.PlanSelection).HasColumnName("PLANSELECTION").IsRequired();
        b.Property(x => x.PlanCalculation).HasColumnName("PLANCALCULATION").HasMaxLength(500).IsRequired();
        b.Property(x => x.Status).HasColumnName("STATUS").HasMaxLength(10).IsRequired();

        b.Property(x => x.CreateDt).HasColumnName("CREATEDT").IsRequired();
        b.Property(x => x.CreateTm).HasColumnName("CREATETM").IsRequired();
        b.Property(x => x.CreateBy).HasColumnName("CREATEBY").HasMaxLength(10).IsRequired();
        b.Property(x => x.CreateRemarks).HasColumnName("CREATEREMARKS").HasMaxLength(100).IsRequired();
        b.Property(x => x.UpdateDt).HasColumnName("UPDATEDT").IsRequired();
        b.Property(x => x.UpdateTm).HasColumnName("UPDATETM").IsRequired();
        b.Property(x => x.UpdateBy).HasColumnName("UPDATEBY").HasMaxLength(10).IsRequired();
        b.Property(x => x.UpdateRemarks).HasColumnName("UPDATEREMARKS").HasMaxLength(100).IsRequired();

        // Note: No navigation to Details because OPLNHDR.PLANNO is varchar and OPLNDET.PLANNO is numeric - incompatible types
    }
}
