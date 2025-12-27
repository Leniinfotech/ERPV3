using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations;

public sealed class JournalEntryLineConfiguration : IEntityTypeConfiguration<JournalEntryLine>
{
    public void Configure(EntityTypeBuilder<JournalEntryLine> b)
    {
        b.ToTable("JOURNALENTRYLINE", "dbo");
        b.HasKey(x => new { x.Fran, x.JournalEntryId, x.JournalEntryLineId });

        b.Property(x => x.Fran).HasColumnName("FRAN").HasMaxLength(10).IsRequired();
        b.Property(x => x.JournalEntryLineId).HasColumnName("JOURNELENTRYLINEID").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.JournalEntryId).HasColumnName("JOURNELENTRYID").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.AccountCode).HasColumnName("ACCOUNTCODE").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.Debit).HasColumnName("DEBIT").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.Credit).HasColumnName("CREDIT").HasPrecision(22, 3).IsRequired();
        b.Property(x => x.Remarks).HasColumnName("REMARKS").HasMaxLength(250).IsRequired();

        // Audit
        b.Property(x => x.CreateDt).HasColumnName("CREATEDT").HasColumnType("date").IsRequired();
        b.Property(x => x.CreateTm).HasColumnName("CREATETM").HasColumnType("datetime").IsRequired();
        b.Property(x => x.CreateBy).HasColumnName("CREATEBY").HasMaxLength(10).IsRequired();
        b.Property(x => x.CreateRemarks).HasColumnName("CREATEREMARKS").HasMaxLength(200).IsRequired();
        b.Property(x => x.UpdateDt).HasColumnName("UPDATEDT").HasColumnType("date").IsRequired();
        b.Property(x => x.UpdateTm).HasColumnName("UPDATETM").HasColumnType("date").IsRequired();
        b.Property(x => x.UpdateBy).HasColumnName("UPDATEBY").HasMaxLength(10).IsRequired();
        b.Property(x => x.UpdateRemarks).HasColumnName("UPDATEMARKS").HasMaxLength(100).IsRequired();

        b.HasOne(x => x.Header)
            .WithMany(h => h.Lines)
            .HasForeignKey(x => new { x.Fran, x.JournalEntryId })
            .HasPrincipalKey(h => new { h.Fran, h.JournalEntryId });
    }
}
