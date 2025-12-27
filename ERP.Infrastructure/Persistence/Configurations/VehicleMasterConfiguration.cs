using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Configurations
{
    public class VehicleMasterConfiguration : IEntityTypeConfiguration<VehicleMaster>
    {
        public void Configure(EntityTypeBuilder<VehicleMaster> builder)
        {
            builder.ToTable("VEHICLEMASTER");

            builder.HasKey(e => e.VechileId);

            builder.Property(e => e.VechileId)
                .HasColumnName("VECHILEID")
                .HasColumnType("numeric(10,0)")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Fran)
                .HasColumnName("FRAN")
                .HasMaxLength(10)
                .IsRequired()
                .HasDefaultValue("");

            builder.Property(e => e.Vin)
                .HasColumnName("VIN")
                .HasMaxLength(10)
                .IsRequired()
                .HasDefaultValue("");

            builder.Property(e => e.Customer)
                .HasColumnName("CUSTOMER")
                .HasMaxLength(10)
                .IsRequired()
                .HasDefaultValue("");

            builder.Property(e => e.Make)
                .HasColumnName("MAKE")
                .HasMaxLength(50)
                .IsRequired()
                .HasDefaultValue("");

            builder.Property(e => e.Model)
                .HasColumnName("MODEL")
                .HasMaxLength(50)
                .IsRequired()
                .HasDefaultValue("");

            builder.Property(e => e.ModelYear)
                .HasColumnName("MODELYEAR")
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(e => e.PlateNo)
                .HasColumnName("PLATENO")
                .HasMaxLength(20)
                .IsRequired()
                .HasDefaultValue("");

            builder.Property(e => e.Mileage)
                .HasColumnName("MILEAGE")
                .HasColumnType("numeric(22,0)")
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(e => e.CreateDt)
                .HasColumnName("CREATEDT")
                .HasColumnType("date")
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

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
                .HasMaxLength(200)
                .IsRequired()
                .HasDefaultValue("");

            builder.Property(e => e.UpdateDt)
                .HasColumnName("UPDATEDT")
                .HasColumnType("date")
                .IsRequired()
                .HasDefaultValue(DateTime.Parse("1900-01-01"));

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

            builder.Property(e => e.UpdateMarks)
                .HasColumnName("UPDATEMARKS")
                .HasMaxLength(200)
                .IsRequired()
                .HasDefaultValue("");
        }
    }
}

