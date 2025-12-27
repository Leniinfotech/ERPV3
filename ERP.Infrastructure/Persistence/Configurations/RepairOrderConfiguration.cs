using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Configurations
{
    public class RepairOrderConfiguration : IEntityTypeConfiguration<RepairOrder>
    {
        public void Configure(EntityTypeBuilder<RepairOrder> builder)
        {
            builder.ToTable("REPAIRORDER");

            builder.HasKey(e => new { e.Fran, e.Brch, e.Workshop, e.RepairType, e.RepairNo, e.RepairSrl });

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

            builder.Property(e => e.RepairType)
                .HasColumnName("REPAIRTYPE")
                .HasMaxLength(50)
                .IsRequired()
                .HasDefaultValue("");

            builder.Property(e => e.RepairNo)
                .HasColumnName("REPAIRNO")
                .HasMaxLength(10)
                .IsRequired()
                .HasDefaultValue("");

            builder.Property(e => e.RepairSrl)
                .HasColumnName("REPAIRSRL")
                .HasMaxLength(10)
                .IsRequired()
                .HasDefaultValue("");

            builder.Property(e => e.Customer)
                .HasColumnName("CUSTOMER")
                .HasMaxLength(10)
                .IsRequired()
                .HasDefaultValue("");

            builder.Property(e => e.VehicleId)
                .HasColumnName("VEHICLEID")
                .HasColumnType("numeric(22,0)")
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(e => e.WorkId)
                .HasColumnName("WORKID")
                .HasColumnType("numeric(10,0)")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(e => e.WorkType)
                .HasColumnName("WORKTYPE")
                .HasMaxLength(50)
                .IsRequired()
                .HasDefaultValue("");

            builder.Property(e => e.WorkDt)
                .HasColumnName("WORKDT")
                .HasColumnType("date")
                .IsRequired()
                .HasDefaultValue(DateTime.Parse("1900-01-01"));

            builder.Property(e => e.NoOfWorks)
                .HasColumnName("NOOFWORKS")
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

            builder.Property(e => e.TotalValue)
                .HasColumnName("TOTALVALUE")
                .HasColumnType("numeric(22,3)")
                .IsRequired()
                .HasDefaultValue(0);

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

