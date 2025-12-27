using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Configurations
{
    public class WorkMasterConfiguration : IEntityTypeConfiguration<WorkMaster>
    {
        public void Configure(EntityTypeBuilder<WorkMaster> builder)
        {
            builder.ToTable("WORKMASTER");

            builder.HasKey(e => new { e.Fran, e.WorkType, e.WorkId });

            builder.Property(e => e.Fran)
                .HasColumnName("FRAN")
                .HasMaxLength(10)
                .IsRequired()
                .HasDefaultValue("");

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

            builder.Property(e => e.Name)
                .HasColumnName("NAME")
                .HasMaxLength(100)
                .IsRequired()
                .HasDefaultValue("");

            builder.Property(e => e.Remarks)
                .HasColumnName("REMARKS")
                .HasMaxLength(100)
                .IsRequired()
                .HasDefaultValue("");

            builder.Property(e => e.UnitPrice)
                .HasColumnName("UNITPRICE")
                .HasColumnType("numeric(22,3)")
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(e => e.Estimated)
                .HasColumnName("ESTIMATED")
                .HasColumnType("numeric(22,0)")
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

