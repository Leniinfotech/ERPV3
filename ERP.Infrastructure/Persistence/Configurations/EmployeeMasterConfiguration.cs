using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Configurations
{
    public class EmployeeMasterConfiguration : IEntityTypeConfiguration<EmployeeMaster>
    {
        public void Configure(EntityTypeBuilder<EmployeeMaster> builder)
        {
            builder.ToTable("EMPLOYEEMASTER");

            builder.HasKey(e => new { e.Fran, e.Employee });

            builder.Property(e => e.Fran)
                .HasColumnName("FRAN")
                .HasMaxLength(10)
                .IsRequired()
                .HasDefaultValue("");

            builder.Property(e => e.Employee)
                .HasColumnName("EMPLOYEE")
                .HasMaxLength(10)
                .IsRequired()
                .HasDefaultValue("");

            builder.Property(e => e.Name)
                .HasColumnName("NAME")
                .HasMaxLength(100)
                .IsRequired()
                .HasDefaultValue("");

            builder.Property(e => e.NameAr)
                .HasColumnName("NAMEAR")
                .HasMaxLength(100)
                .IsRequired()
                .HasDefaultValue("");

            builder.Property(e => e.Phone)
                .HasColumnName("PHONE")
                .HasMaxLength(50)
                .IsRequired()
                .HasDefaultValue("");

            builder.Property(e => e.Email)
                .HasColumnName("EMAIL")
                .HasMaxLength(100)
                .IsRequired()
                .HasDefaultValue("");

            builder.Property(e => e.Address)
                .HasColumnName("ADDRESS")
                .HasMaxLength(100)
                .IsRequired()
                .HasDefaultValue("");

            builder.Property(e => e.NationalId)
                .HasColumnName("NATIONALID")
                .HasMaxLength(100)
                .IsRequired()
                .HasDefaultValue("");

            builder.Property(e => e.HireDate)
                .HasColumnName("HIREDATE")
                .HasColumnType("date")
                .IsRequired()
                .HasDefaultValue(DateTime.Parse("1900-01-01"));

            builder.Property(e => e.IsActive)
                .HasColumnName("ISACTIVE")
                .HasMaxLength(1)
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

