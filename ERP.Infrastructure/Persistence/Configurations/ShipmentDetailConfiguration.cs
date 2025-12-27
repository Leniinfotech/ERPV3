using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations;

public sealed class ShipmentDetailConfiguration : IEntityTypeConfiguration<ShipmentDetail>
{
    public void Configure(EntityTypeBuilder<ShipmentDetail> b)
    {
        b.ToTable("SINVDET", "dbo");
        b.HasKey(x => new { x.Fran, x.Branch, x.WarehouseCode, x.ShipmentType, x.ShipmentNumber, x.ShipmentSerial });

        b.Property(x => x.Fran).HasColumnName("FRAN").HasMaxLength(10).IsRequired();
        b.Property(x => x.Branch).HasColumnName("BRCH").HasMaxLength(10).IsRequired();
        b.Property(x => x.WarehouseCode).HasColumnName("WHSE").HasMaxLength(10).IsRequired();
        b.Property(x => x.ShipmentType).HasColumnName("SINVTYPE").HasMaxLength(50).IsRequired();
        b.Property(x => x.ShipmentNumber).HasColumnName("SINVNO").HasMaxLength(10).IsRequired();
        b.Property(x => x.ShipmentSerial).HasColumnName("SINVSRL").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.ShipmentDate).HasColumnName("SINVDT").HasColumnType("date").IsRequired();

        b.Property(x => x.Vendor).HasColumnName("VENDOR").HasMaxLength(10).IsRequired();
        b.Property(x => x.Make).HasColumnName("MAKE").HasMaxLength(10).IsRequired();
        b.Property(x => x.Part).HasColumnName("PART").HasMaxLength(28).IsRequired();
        b.Property(x => x.OrdPart).HasColumnName("ORDPART").HasMaxLength(28).IsRequired();
        b.Property(x => x.Qty).HasColumnName("QTY").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.OrdQty).HasColumnName("ORDQTY").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.UnitPrice).HasColumnName("UNITPRICE").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.Discount).HasColumnName("DISCOUNT").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.VatPercentage).HasColumnName("VATPERCENTAGE").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.VatValue).HasColumnName("VATVALUE").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.DiscountValue).HasColumnName("DISCOUNTVALUE").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.TotalValue).HasColumnName("TOTALVALUE").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.CaseNo).HasColumnName("CASENO").HasMaxLength(20).IsRequired();
        b.Property(x => x.ContainerNo).HasColumnName("CONTAINERNO").HasMaxLength(20).IsRequired();
        b.Property(x => x.PoType).HasColumnName("POTYPE").HasMaxLength(50).IsRequired();
        b.Property(x => x.PoNo).HasColumnName("PONO").HasMaxLength(10).IsRequired();
        b.Property(x => x.PoSrl).HasColumnName("POSRL").HasPrecision(22, 0).IsRequired();

        // Audit
        b.Property(x => x.CreateDt).HasColumnName("CREATEDT").HasColumnType("date").IsRequired();
        b.Property(x => x.CreateTm).HasColumnName("CREATETM").HasColumnType("datetime").IsRequired();
        b.Property(x => x.CreateBy).HasColumnName("CREATEBY").HasMaxLength(10).IsRequired();
        b.Property(x => x.CreateRemarks).HasColumnName("CREATEREMARKS").HasMaxLength(100).IsRequired();
        b.Property(x => x.UpdateDt).HasColumnName("UPDATEDT").HasColumnType("date").IsRequired();
        b.Property(x => x.UpdateTm).HasColumnName("UPDATETM").HasColumnType("datetime").IsRequired();
        b.Property(x => x.UpdateBy).HasColumnName("UPDATEBY").HasMaxLength(10).IsRequired();
        b.Property(x => x.UpdateRemarks).HasColumnName("UPDATEREMARKS").HasMaxLength(100).IsRequired();

        b.HasOne(x => x.Shipment)
         .WithMany()
         .HasForeignKey(x => new { x.Fran, x.Branch, x.WarehouseCode, x.ShipmentType, x.ShipmentNumber })
         .HasPrincipalKey((Shipment s) => new { s.Fran, s.Branch, s.WarehouseCode, s.ShipmentType, s.ShipmentNumber });
    }
}
