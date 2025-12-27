using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations;

public sealed class PartConfiguration : IEntityTypeConfiguration<Part>
{
    public void Configure(EntityTypeBuilder<Part> b)
    {
        b.ToTable("PARTS", "dbo");
        b.HasKey(x => x.PartCode);

        b.Property(x => x.PartCode).HasColumnName("PART").HasMaxLength(10).IsRequired();
        b.Property(x => x.Description).HasColumnName("DESC").HasMaxLength(200);
        b.Property(x => x.Make).HasColumnName("MAKE").HasMaxLength(10);
        b.Property(x => x.StockKey).HasColumnName("STOCKKEY").HasMaxLength(50);
        b.Property(x => x.Barcode).HasColumnName("BARCODE").HasMaxLength(100);
        b.Property(x => x.SubsPart).HasColumnName("SUBSPART").HasMaxLength(28);
        b.Property(x => x.FinalPart).HasColumnName("FINALPART").HasMaxLength(28);
        b.Property(x => x.InvClass).HasColumnName("INVCLASS").HasMaxLength(50);
        b.Property(x => x.Category).HasColumnName("CATEGORY").HasMaxLength(50);
        b.Property(x => x.Group).HasColumnName("GROUP").HasMaxLength(50);
        b.Property(x => x.CountryOfOrigin).HasColumnName("COO").HasMaxLength(100);
        b.Property(x => x.Lc).HasColumnName("LC");
        b.Property(x => x.Fob).HasColumnName("FOB");
        b.Property(x => x.NetWeight).HasColumnName("NETWEIGHT");
        b.Property(x => x.Stock).HasColumnName("STOCK");
        b.Property(x => x.Cmsale).HasColumnName("CMSALE");
        b.Property(x => x.Lmsale).HasColumnName("LMSALE");
        b.Property(x => x.M3sale).HasColumnName("M3SALE");
        b.Property(x => x.M6sale).HasColumnName("M6SALE");
        b.Property(x => x.M12sale).HasColumnName("M12SALE");
        b.Property(x => x.Avgm6).HasColumnName("AVGM6");
        b.Property(x => x.Active).HasColumnName("ACTIVE");


        // Added: Added additional columns
        // Added by: Vaishnavi
        // Added on: 10-12-2025
        b.Property(x => x.Id).HasColumnName("ID");
        b.Property(x => x.Fran).HasColumnName("FRAN").HasMaxLength(10).IsRequired();
        b.Property(x => x.Createdt).HasColumnName("CREATEDT");
        b.Property(x => x.Createby).HasColumnName("CREATEBY").HasMaxLength(100).IsRequired();
        b.Property(x => x.Createremarks).HasColumnName("CREATEREMARKS").HasMaxLength(1000);
        b.Property(x => x.Updatedt).HasColumnName("UPDATEDT");
        b.Property(x => x.Updateby).HasColumnName("UPDATEBY").HasMaxLength(100).IsRequired();
        b.Property(x => x.Updatemarks).HasColumnName("UPDATEMARKS").HasMaxLength(1000);
    }
}