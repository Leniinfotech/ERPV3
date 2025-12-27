using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations;

public sealed class LoadingAdviceDetail2Configuration : IEntityTypeConfiguration<LoadingAdviceDetail2>
{
    public void Configure(EntityTypeBuilder<LoadingAdviceDetail2> b)
    {
        b.ToTable("LADET2", "dbo");
        b.HasKey(x => new { x.Fran, x.Branch, x.Warehouse, x.InvType, x.InvNo, x.InvSrl });

        b.Property(x => x.Fran).HasColumnName("FRAN").HasMaxLength(10).IsRequired();
        b.Property(x => x.Branch).HasColumnName("BRCH").HasMaxLength(10).IsRequired();
        b.Property(x => x.Warehouse).HasColumnName("WHSE").HasMaxLength(10).IsRequired();
        b.Property(x => x.InvType).HasColumnName("INVTYPE").HasMaxLength(50).IsRequired();
        b.Property(x => x.InvNo).HasColumnName("INVNO").HasMaxLength(100).IsRequired();
        b.Property(x => x.InvSrl).HasColumnName("INVSRL").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.InvDate).HasColumnName("INVDT").IsRequired();
        b.Property(x => x.Customer).HasColumnName("CUSTOMER").HasMaxLength(100).IsRequired();
        b.Property(x => x.Part).HasColumnName("PART").HasMaxLength(28).IsRequired();
        b.Property(x => x.Make).HasColumnName("MAKE").HasMaxLength(10).IsRequired();
        b.Property(x => x.Qty).HasColumnName("QTY").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.UnitRate).HasColumnName("UNITRATE").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.NetValue).HasColumnName("NETVALUE").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.CurrencyFactor).HasColumnName("CURRENCYFACTOR").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.UnitGrossWeight).HasColumnName("UNITGROSSWEIGHT").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.UnitNetWeight).HasColumnName("UNITNETWEIGHT").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.LaType).HasColumnName("LATYPE").HasMaxLength(25).IsRequired();
        b.Property(x => x.LaNo).HasColumnName("LANO").HasMaxLength(100).IsRequired();
        b.Property(x => x.LaSrl).HasColumnName("LASRL").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.PackNo).HasColumnName("PACKNO").HasMaxLength(100).IsRequired();
        b.Property(x => x.PickNo).HasColumnName("PICKNO").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.Crtn).HasColumnName("CRTN").HasMaxLength(25).IsRequired();
        b.Property(x => x.Coo).HasColumnName("COO").HasMaxLength(100).IsRequired();
        b.Property(x => x.HsCode).HasColumnName("HSCODE").HasMaxLength(100).IsRequired();
        b.Property(x => x.Length).HasColumnName("LENGTH").HasPrecision(22, 3);
        b.Property(x => x.Width).HasColumnName("WIDTH").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.Height).HasColumnName("HEIGHT").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.Volume).HasColumnName("VOLUME").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.NetWeight).HasColumnName("NETWEIGHT").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.GrossWeight).HasColumnName("GROSSWEIGHT").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.KeyInGrossWeight).HasColumnName("KEYINGROSSWEIGHT").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.Currency).HasColumnName("CURRENCY").HasMaxLength(10).IsRequired();
        b.Property(x => x.StoreId).HasColumnName("STOREID").HasMaxLength(10).IsRequired();
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
