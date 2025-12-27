using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Configurations
{
    public class RepairHdrConfiguration : IEntityTypeConfiguration<RepairHdr>
    {
        public void Configure(EntityTypeBuilder<RepairHdr> builder)
        {
            builder.ToTable("REPAIRHDR");

            builder.HasKey(e => new { e.Fran, e.Brch, e.Workshop, e.RepairType, e.RepairNo });

            builder.Property(e => e.Fran)
                .HasColumnName("FRAN")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(e => e.Brch)
                .HasColumnName("BRCH")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(e => e.Workshop)
                .HasColumnName("WORKSHOP")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(e => e.RepairType)
                .HasColumnName("REPAIRTYPE")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.RepairNo)
                .HasColumnName("REPAIRNO")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(e => e.RepairDt)
                .HasColumnName("REPAIRDT")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(e => e.Customer)
                .HasColumnName("CUSTOMER")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(e => e.VehicleId)
                .HasColumnName("VEHICLEID")
                .HasColumnType("numeric(10,0)")
                .IsRequired();

            builder.Property(e => e.Currency)
                .HasColumnName("CURRENCY")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(e => e.NoOfParts)
                .HasColumnName("NOOFPARTS")
                .HasColumnType("numeric(22,0)")
                .IsRequired();

            builder.Property(e => e.NoOfJobs)
                .HasColumnName("NOOFJOBS")
                .HasColumnType("numeric(22,0)")
                .IsRequired();

            builder.Property(e => e.Discount)
                .HasColumnName("DISCOUNT")
                .HasColumnType("numeric(22,3)")
                .IsRequired();

            builder.Property(e => e.TotalValue)
                .HasColumnName("TOTALVALUE")
                .HasColumnType("numeric(22,3)")
                .IsRequired();

            builder.Property(e => e.SeqNo)
                .HasColumnName("SEQNO")
                .HasColumnType("numeric(22,0)")
                .IsRequired();

            builder.Property(e => e.SeqPrefix)
                .HasColumnName("SEQPREFIX")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(e => e.CreateTm)
                .HasColumnName("CREATETM")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(e => e.CreateBy)
                .HasColumnName("CREATEBY")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(e => e.CreateRemarks)
                .HasColumnName("CREATEREMARKS")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.UpdateTm)
                .HasColumnName("UPDATETM")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(e => e.UpdateBy)
                .HasColumnName("UPDATEBY")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(e => e.UpdateRemarks)
                .HasColumnName("UPDATEREMARKS")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}

