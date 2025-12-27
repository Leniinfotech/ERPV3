using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations;

public sealed class PatternCartonHeaderConfiguration : IEntityTypeConfiguration<PatternCartonHeader>
{
    public void Configure(EntityTypeBuilder<PatternCartonHeader> b)
    {
        b.ToTable("PATCRTNHDR", "dbo");
        b.HasKey(x => new { x.Fran, x.Branch, x.Warehouse, x.CrtnType, x.Crtn });

        b.Property(x => x.Fran).HasColumnName("CHFRAN").HasMaxLength(10).IsRequired();
        b.Property(x => x.Branch).HasColumnName("CHBRCH").HasMaxLength(10).IsRequired();
        b.Property(x => x.Warehouse).HasColumnName("CHWHSE").HasMaxLength(10).IsRequired();
        b.Property(x => x.CrtnType).HasColumnName("CHCRTNTYPE").HasMaxLength(10).IsRequired();
        b.Property(x => x.Crtn).HasColumnName("CHCRTN").HasMaxLength(50).IsRequired();
        b.Property(x => x.Length).HasColumnName("CHLENGTH").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.Width).HasColumnName("CHWIDTH").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.Height).HasColumnName("CHHEIGHT").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.Volume).HasColumnName("CHVOLUME").HasPrecision(22, 9).IsRequired();
        b.Property(x => x.NetWeight).HasColumnName("CHNETWEIGHT").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.LocnId).HasColumnName("CHLOCNID").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.NoItems).HasColumnName("CHNOITEMS").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.TotQty).HasColumnName("CHTOTQTY").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.Customer).HasColumnName("CHCUST").HasMaxLength(50).IsRequired();
        b.Property(x => x.PakGrp).HasColumnName("CHPAKGRP").HasMaxLength(25).IsRequired();
        b.Property(x => x.PackType).HasColumnName("CHPACKTYPE").HasMaxLength(10).IsRequired();
        b.Property(x => x.PackNo).HasColumnName("CHPACKNO").HasMaxLength(50).IsRequired();
        b.Property(x => x.CntrId).HasColumnName("CHCNTRID").HasMaxLength(50).IsRequired();
        b.Property(x => x.SourType).HasColumnName("CHSOURTYPE").HasMaxLength(10).IsRequired();
        b.Property(x => x.SourNo).HasColumnName("CHSOURNO").HasMaxLength(25).IsRequired();
        b.Property(x => x.GrossWeight).HasColumnName("CHGROSSWEIGHT").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.CaseMark).HasColumnName("CHCASEMARK").HasMaxLength(200).IsRequired();
        b.Property(x => x.PackIns).HasColumnName("CHPACKINS").HasMaxLength(200).IsRequired();
        b.Property(x => x.Status).HasColumnName("CHSTATUS").HasMaxLength(10).IsRequired();
        b.Property(x => x.CrtnCatg).HasColumnName("CHCRTNCATG").HasMaxLength(100).IsRequired();
        b.Property(x => x.CrtnPrefix).HasColumnName("CHCRTNPREFIX").HasMaxLength(10).IsRequired();
        b.Property(x => x.CrtnSeqNo).HasColumnName("CHCRTNSEQNO").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.ShipCaseMark).HasColumnName("CHSHIPCASEMARK").HasMaxLength(10).IsRequired();
        b.Property(x => x.KeyInGrossWeight).HasColumnName("CHKEYINGROSSWEIGHT").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.LaType).HasColumnName("CHLATYPE").HasMaxLength(100).IsRequired();
        b.Property(x => x.LaNo).HasColumnName("CHLANO").HasMaxLength(100).IsRequired();
        b.Property(x => x.LotNo).HasColumnName("CHLOTNO").HasMaxLength(100);
        b.Property(x => x.SinvNo).HasColumnName("CHSINVNO").HasMaxLength(100).IsRequired();
        b.Property(x => x.StoreId).HasColumnName("CHSTOREID").HasMaxLength(10).IsRequired();
        b.Property(x => x.InvType).HasColumnName("CHINVTYPE").HasMaxLength(50).IsRequired();
        b.Property(x => x.InvNo).HasColumnName("CHINVNO").HasMaxLength(100).IsRequired();
        b.Property(x => x.DespStatus).HasColumnName("CHDESPSTATUS").HasMaxLength(10).IsRequired();

        b.Property(x => x.CreateDt).HasColumnName("CHCREATEDT").IsRequired();
        b.Property(x => x.CreateTm).HasColumnName("CHCREATETM").IsRequired();
        b.Property(x => x.CreateBy).HasColumnName("CHCREATEBY").HasMaxLength(10).IsRequired();
        b.Property(x => x.CreateRemarks).HasColumnName("CHCREATEREMARKS").HasMaxLength(200).IsRequired();
        b.Property(x => x.UpdateDt).HasColumnName("CHUPDATEDT").IsRequired();
        b.Property(x => x.UpdateTm).HasColumnName("CHUPDATETM").IsRequired();
        b.Property(x => x.UpdateBy).HasColumnName("CHUPDATEBY").HasMaxLength(10).IsRequired();
        b.Property(x => x.UpdateRemarks).HasColumnName("CHUPDATEREMARKS").HasMaxLength(200).IsRequired();
    }
}
