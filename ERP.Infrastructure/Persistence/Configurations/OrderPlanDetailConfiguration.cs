using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations;

public sealed class OrderPlanDetailConfiguration : IEntityTypeConfiguration<OrderPlanDetail>
{
    public void Configure(EntityTypeBuilder<OrderPlanDetail> b)
    {
        b.ToTable("OPLNDET", "dbo");
        b.HasKey(x => new { x.Fran, x.Branch, x.Warehouse, x.PlanType, x.PlanNo, x.PlanSrl });

        b.Property(x => x.Fran).HasColumnName("FRAN").HasMaxLength(10).IsRequired();
        b.Property(x => x.Branch).HasColumnName("BRCH").HasMaxLength(10).IsRequired();
        b.Property(x => x.Warehouse).HasColumnName("WHSE").HasMaxLength(10).IsRequired();
        b.Property(x => x.PlanType).HasColumnName("PLANTYPE").HasMaxLength(10).IsRequired();
        b.Property(x => x.PlanNo).HasColumnName("PLANNO").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.PlanSrl).HasColumnName("PLANSRL").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.PlanDate).HasColumnName("PLANDT").IsRequired();
        b.Property(x => x.Vendor).HasColumnName("VENDOR").HasMaxLength(10).IsRequired();
        b.Property(x => x.Make).HasColumnName("MAKE").HasColumnType("char(10)").IsRequired();
        b.Property(x => x.Part).HasColumnName("PART").HasColumnType("char(28)").IsRequired();
        b.Property(x => x.Qty).HasColumnName("QTY").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.UnitPrice).HasColumnName("UNITPRICE").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.NetValue).HasColumnName("NETVALUE").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.SuggQty).HasColumnName("SUGGQTY").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.SuggValue).HasColumnName("SUGGVALUE").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.Currency).HasColumnName("CURRENCY").HasMaxLength(10).IsRequired();
        b.Property(x => x.OhQty).HasColumnName("OHQTY").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.OoQty).HasColumnName("OOQTY").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.PoType).HasColumnName("POTYPE").HasColumnType("char(10)").IsRequired();
        b.Property(x => x.PoNo).HasColumnName("PONO").HasMaxLength(10).IsRequired();
        b.Property(x => x.PoSrl).HasColumnName("POSRL").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.Pmc).HasColumnName("PMC").HasColumnType("char(10)").IsRequired();
        b.Property(x => x.FlagParent).HasColumnName("FLAGPARENT").HasColumnType("char(10)").IsRequired();
        b.Property(x => x.SubsPart).HasColumnName("SUBSPART").HasMaxLength(28).IsRequired();
        b.Property(x => x.FinalPart).HasColumnName("FINALPART").HasMaxLength(28).IsRequired();
        b.Property(x => x.NoReorderCode).HasColumnName("NOREORDERCODE").HasMaxLength(150).IsRequired();
        b.Property(x => x.StopSaleCode).HasColumnName("STOPSALECODE").HasMaxLength(150).IsRequired();
        b.Property(x => x.PlanSelection).HasColumnName("PLANSELECTION").IsRequired();
        b.Property(x => x.Remarks).HasColumnName("REMARKS").HasMaxLength(100).IsRequired();

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
