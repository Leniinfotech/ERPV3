using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations;

public sealed class OrderPlanMasterConfiguration : IEntityTypeConfiguration<OrderPlanMaster>
{
    public void Configure(EntityTypeBuilder<OrderPlanMaster> b)
    {
        b.ToTable("OPLNMST", "dbo");
        b.HasKey(x => new { x.Fran, x.Type, x.Name });

        b.Property(x => x.Id).HasColumnName("ID").HasPrecision(22, 0).ValueGeneratedOnAdd();
        b.Property(x => x.Fran).HasColumnName("FRAN").HasMaxLength(10).IsRequired();
        b.Property(x => x.Type).HasColumnName("TYPE").HasMaxLength(50).IsRequired();
        b.Property(x => x.Name).HasColumnName("NAME").HasMaxLength(50).IsRequired();
        b.Property(x => x.SelectSql).HasColumnName("SELECTSQL").IsRequired();
        b.Property(x => x.FilterSql).HasColumnName("FILTERSQL").HasMaxLength(500).IsRequired();
        b.Property(x => x.GroupBySql).HasColumnName("GROUPBYSQL").HasMaxLength(500).IsRequired();
        b.Property(x => x.OrderBySql).HasColumnName("ORDERBYSQL").HasMaxLength(500).IsRequired();

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
