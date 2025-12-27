using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Configurations
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("APPOINTMNET");

            builder.HasKey(e => new { e.Fran, e.AppointId });

            builder.Property(e => e.Fran)
                .HasColumnName("FRAN")
                .HasMaxLength(10)
                .IsRequired()
                .HasDefaultValue("");

            builder.Property(e => e.AppointId)
                .HasColumnName("APPOINTID")
                .HasColumnType("numeric(22,0)")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(e => e.AppointDt)
                .HasColumnName("APPOINTDT")
                .HasColumnType("date")
                .IsRequired()
                .HasDefaultValue(DateTime.Parse("1900-01-01"));

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

            builder.Property(e => e.AssaignedTo)
                .HasColumnName("ASSAIGNEDTO")
                .HasMaxLength(10)
                .IsRequired()
                .HasDefaultValue("");

            builder.Property(e => e.Status)
                .HasColumnName("STATUS")
                .HasMaxLength(10)
                .IsRequired()
                .HasDefaultValue("");

            builder.Property(e => e.Remarks)
                .HasColumnName("REMARKS")
                .HasMaxLength(250)
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
                .HasMaxLength(200)
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

            builder.Property(e => e.UpdateMarks)
                .HasColumnName("UPDATEMARKS")
                .HasMaxLength(200)
                .IsRequired()
                .HasDefaultValue("");
        }
    }
}

