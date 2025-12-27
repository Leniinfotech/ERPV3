using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Configurations
{
    public class WorkshopMasterConfiguration : IEntityTypeConfiguration<WorkshopMaster>
    {
        public void Configure(EntityTypeBuilder<WorkshopMaster> builder)
        {
            builder.ToTable("WORKSHOPMASTER");

            builder.HasKey(e => new { e.Fran, e.Workshop });

            builder.Property(e => e.Fran)
                .HasMaxLength(10)
                .IsRequired()
                .HasDefaultValue("");

            builder.Property(e => e.Brch)
                .HasMaxLength(10)
                .IsRequired()
                .HasDefaultValue("");

            builder.Property(e => e.Workshop)
                .HasColumnType("numeric(10,0)")
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(e => e.Name)
                .HasMaxLength(150)
                .IsRequired()
                .HasDefaultValue("");

            builder.Property(e => e.CreateTm)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(e => e.CreateBy)
                .HasMaxLength(10)
                .HasDefaultValue("");

            builder.Property(e => e.CreateRemarks)
                .HasMaxLength(100)
                .HasDefaultValue("");

            builder.Property(e => e.UpdateTm)
                .HasDefaultValue(DateTime.Parse("1900-01-01"));

            builder.Property(e => e.UpdateBy)
                .HasMaxLength(10)
                .HasDefaultValue("1900-01-01");

            builder.Property(e => e.UpdateRemarks)
                .HasMaxLength(100);
        }
    }
}
