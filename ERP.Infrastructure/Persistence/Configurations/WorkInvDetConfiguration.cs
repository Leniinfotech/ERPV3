using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Configurations
{
    public class WorkInvDetConfiguration : IEntityTypeConfiguration<WorkInvDet>
    {
        public void Configure(EntityTypeBuilder<WorkInvDet> builder)
        {
            builder.ToTable("WORKINVDET");

            builder.HasKey(e => new { e.Fran, e.Brch, e.Workshop, e.WorkInvType, e.WorkInvNo, e.WorkInvSrl });

            builder.Property(e => e.Fran)
                .HasColumnName("FRAN")
                .HasMaxLength(10)
                .IsRequired()
                .HasDefaultValue("");

            builder.Property(e => e.Brch)
                .HasColumnName("BRCH")
                .HasMaxLength(10)
                .IsRequired()
                .HasDefaultValue("");

            builder.Property(e => e.Workshop)
                .HasColumnName("WORKSHOP")
                .HasMaxLength(10)
                .IsRequired()
                .HasDefaultValue("");

            builder.Property(e => e.WorkInvType)
                .HasColumnName("WORKINVTYPE")
                .HasMaxLength(50)
                .IsRequired()
                .HasDefaultValue("");

            builder.Property(e => e.WorkInvNo)
                .HasColumnName("WORKINVNO")
                .HasMaxLength(10)
                .IsRequired()
                .HasDefaultValue("");

            builder.Property(e => e.WorkInvSrl)
                .HasColumnName("WORKINVSRL")
                .HasColumnType("numeric(22,0)")
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(e => e.WorkInvDt)
                .HasColumnName("WORKINVDT")
                .HasColumnType("date")
                .IsRequired()
                .HasDefaultValue(DateTime.Parse("1900-01-01"));

            builder.Property(e => e.BillType)
                .HasColumnName("BILLTYPE")
                .HasMaxLength(10)
                .IsRequired()
                .HasDefaultValue("");

            builder.Property(e => e.WorkType)
                .HasColumnName("WORKTYPE")
                .HasMaxLength(10)
                .IsRequired()
                .HasDefaultValue("");

            builder.Property(e => e.WorkId)
                .HasColumnName("WORKID")
                .HasColumnType("numeric(10,0)")
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(e => e.Make)
                .HasColumnName("MAKE")
                .HasMaxLength(10)
                .IsRequired()
                .HasDefaultValue("");

            builder.Property(e => e.Part)
                .HasColumnName("PART")
                .HasColumnType("numeric(22,0)")
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(e => e.Qty)
                .HasColumnName("QTY")
                .HasColumnType("numeric(22,0)")
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(e => e.UnitPrice)
                .HasColumnName("UNITPRICE")
                .HasColumnType("numeric(22,3)")
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(e => e.Discount)
                .HasColumnName("DISCOUNT")
                .HasColumnType("numeric(22,3)")
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(e => e.VatPercentage)
                .HasColumnName("VATPERCENTAGE")
                .HasColumnType("numeric(22,3)")
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(e => e.VatValue)
                .HasColumnName("VATVALUE")
                .HasColumnType("numeric(22,3)")
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(e => e.TotalValue)
                .HasColumnName("TOTALVALUE")
                .HasColumnType("numeric(22,3)")
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(e => e.ReapairType)
                .HasColumnName("REAPAIRTYPE")
                .HasMaxLength(10)
                .IsRequired()
                .HasDefaultValue("");

            builder.Property(e => e.ReapairNo)
                .HasColumnName("REAPAIRNO")
                .HasMaxLength(10)
                .IsRequired()
                .HasDefaultValue("");

            builder.Property(e => e.RepairSrl)
                .HasColumnName("REPAIRSRL")
                .HasColumnType("numeric(22,0)")
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(e => e.SaleType)
                .HasColumnName("SALETYPE")
                .HasMaxLength(10)
                .IsRequired()
                .HasDefaultValue("");

            builder.Property(e => e.SaleNo)
                .HasColumnName("SALENO")
                .HasMaxLength(10)
                .IsRequired()
                .HasDefaultValue("");

            builder.Property(e => e.CreateTm)
                .HasColumnName("CREATETM")
                .HasColumnType("datetime")
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.Property(e => e.CreateBy)
                .HasColumnName("CREATEBY")
                .HasMaxLength(10)
                .IsRequired()
                .HasDefaultValue("");

            builder.Property(e => e.CreateRemarks)
                .HasColumnName("CREATEREMARKS")
                .HasMaxLength(100)
                .IsRequired()
                .HasDefaultValue("");

            builder.Property(e => e.UpdateTm)
                .HasColumnName("UPDATETM")
                .HasColumnType("datetime")
                .IsRequired()
                .HasDefaultValue(DateTime.Parse("1900-01-01"));

            builder.Property(e => e.UpdateBy)
                .HasColumnName("UPDATEBY")
                .HasMaxLength(10)
                .IsRequired()
                .HasDefaultValue("");

            builder.Property(e => e.UpdateRemarks)
                .HasColumnName("UPDATEREMARKS")
                .HasMaxLength(100)
                .IsRequired()
                .HasDefaultValue("");
        }
    }
}

