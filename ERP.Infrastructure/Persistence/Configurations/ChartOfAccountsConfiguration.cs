using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations;

public sealed class ChartOfAccountsConfiguration : IEntityTypeConfiguration<ChartOfAccounts>
{
    public void Configure(EntityTypeBuilder<ChartOfAccounts> b)
    {
        b.ToTable("CHARTOFACCOUNTS", "dbo");
        b.HasKey(x => new { x.Fran, x.AccountType, x.AccountCode });

        b.Property(x => x.Fran).HasColumnName("FRAN").HasMaxLength(10).IsRequired();
        b.Property(x => x.AccountType).HasColumnName("ACCOUNTTYPE").HasMaxLength(250).IsRequired();
        b.Property(x => x.AccountCode).HasColumnName("ACCOUNTCODE").HasMaxLength(50).IsRequired();
        b.Property(x => x.AccountName).HasColumnName("ACCOUNTNAME").HasMaxLength(250).IsRequired();
        b.Property(x => x.AccountBalance).HasColumnName("ACCOUNTBALANCE").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.Remarks).HasColumnName("REMARKS").HasMaxLength(250).IsRequired();

        b.Property(x => x.CreateDt).HasColumnName("CREATEDT").IsRequired();
        b.Property(x => x.CreateTm).HasColumnName("CREATETM").IsRequired();
        b.Property(x => x.CreateBy).HasColumnName("CREATEBY").HasMaxLength(10).IsRequired();
        b.Property(x => x.CreateRemarks).HasColumnName("CREATEREMARKS").HasMaxLength(200).IsRequired();
        b.Property(x => x.UpdateDt).HasColumnName("UPDATEDT").IsRequired();
        b.Property(x => x.UpdateTm).HasColumnName("UPDATETM").IsRequired();
        b.Property(x => x.UpdateBy).HasColumnName("UPDATEBY").HasMaxLength(10).IsRequired();
        b.Property(x => x.UpdateMarks).HasColumnName("UPDATEMARKS").HasMaxLength(200).IsRequired();
    }
}
