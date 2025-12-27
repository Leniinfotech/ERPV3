using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations;

public sealed class ShipmentConfiguration : IEntityTypeConfiguration<Shipment>
{
    public void Configure(EntityTypeBuilder<Shipment> b)
    {
        b.ToTable("SINVHDR", "dbo");
        b.HasKey(x => new { x.Fran, x.Branch, x.WarehouseCode, x.ShipmentType, x.ShipmentNumber });

        b.Property(x => x.Fran).HasColumnName("FRAN").HasMaxLength(10).IsRequired();
        b.Property(x => x.Branch).HasColumnName("BRCH").HasMaxLength(10).IsRequired();
        b.Property(x => x.WarehouseCode).HasColumnName("WHSE").HasMaxLength(10).IsRequired();
        b.Property(x => x.ShipmentType).HasColumnName("SINVTYPE").HasMaxLength(50).IsRequired();
        b.Property(x => x.ShipmentNumber).HasColumnName("SINVNO").HasMaxLength(10).IsRequired();
        b.Property(x => x.ShipmentDate).HasColumnName("SINVDT");
        b.Property(x => x.SupplierCode).HasColumnName("VENDOR").HasMaxLength(10).IsRequired();
        b.Property(x => x.Currency).HasColumnName("CURRENCY").HasMaxLength(10).IsRequired();
        b.Property(x => x.BlNumber).HasColumnName("BLNO").HasMaxLength(10);
        b.Property(x => x.BlDate).HasColumnName("BLDT");
        b.Property(x => x.BuyerCode).HasColumnName("BUYERCODE").HasMaxLength(20);
        b.Property(x => x.ShippingStatus).HasColumnName("SHIPPINGSTATUS").HasMaxLength(20);
        b.Property(x => x.ShipCompanyCode).HasColumnName("SHIPCOMPANYCODE").HasMaxLength(20);

        b.Property(x => x.Status).HasColumnName("STATUS").HasMaxLength(20);
        b.Property(x => x.Eta).HasColumnName("ETA").HasColumnType("date");
        b.Property(x => x.ProdCountryCode).HasColumnName("PRODCOUNTRYCODE").HasMaxLength(10);
        b.Property(x => x.VesselNo).HasColumnName("VESSELNO").HasMaxLength(50);
        b.Property(x => x.VesselName).HasColumnName("VESSELNAME").HasMaxLength(100);
        b.Property(x => x.Sender).HasColumnName("SENDER").HasMaxLength(100);
        b.Property(x => x.PortArrivalDt).HasColumnName("PORTARRIVALDT").HasColumnType("date");
        b.Property(x => x.BondedArrivalDt).HasColumnName("BONDEDARRVALDT").HasColumnType("date");

        // Optional important fields / non-null defaults
        b.Property(x => x.NoOfItems).HasColumnName("NOOFITEMS").IsRequired();
        b.Property(x => x.SeaFreightCharges).HasColumnName("SEAFREIGHTCHARGES").HasPrecision(22,3).IsRequired();
        b.Property(x => x.InsuranceCharges).HasColumnName("INSURANCECHARGES").HasPrecision(22,3).IsRequired();
        b.Property(x => x.OdsCharges).HasColumnName("ODSCHARGES").HasPrecision(22,3).IsRequired();
        b.Property(x => x.AddlCharges).HasColumnName("ADDLCHARGES").HasPrecision(22,3).IsRequired();
        b.Property(x => x.InspectionDocNo).HasColumnName("INSPECTIONDOCNO").HasMaxLength(20);
        b.Property(x => x.LetterOfCreditNo).HasColumnName("LETTEROFCREDITNO").HasMaxLength(20);
        b.Property(x => x.DiscountValue).HasColumnName("DISCOUNTVALUE").HasPrecision(22,3).IsRequired();
        b.Property(x => x.GrossValue).HasColumnName("GROSSVALUE").HasPrecision(22,3).IsRequired();
        b.Property(x => x.NetValue).HasColumnName("NETVALUE").HasPrecision(22,3).IsRequired();
        b.Property(x => x.VatValue).HasColumnName("VATVALUE").HasPrecision(22,3).IsRequired();
        b.Property(x => x.TotalValue).HasColumnName("TOTALVALUE").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.CreateDt).HasColumnName("CREATEDT").HasColumnType("date").IsRequired();
        b.Property(x => x.CreateTm).HasColumnName("CREATETM").HasColumnType("datetime").IsRequired();
        b.Property(x => x.CreateBy).HasColumnName("CREATEBY").HasMaxLength(10);
        b.Property(x => x.CreateRemarks).HasColumnName("CREATEREMARKS").HasMaxLength(100);
        b.Property(x => x.UpdateDt).HasColumnName("UPDATEDT").HasColumnType("date").IsRequired();
        b.Property(x => x.UpdateTm).HasColumnName("UPDATETM").HasColumnType("datetime").IsRequired();
        b.Property(x => x.UpdateBy).HasColumnName("UPDATEBY").HasMaxLength(10);
        b.Property(x => x.UpdateRemarks).HasColumnName("UPDATEREMARKS").HasMaxLength(100);

        b.HasOne(x => x.Supplier)
            .WithMany(s => s.Shipments)
            .HasForeignKey(x => x.SupplierCode)
            .HasPrincipalKey(s => s.SupplierCode);
    }
}