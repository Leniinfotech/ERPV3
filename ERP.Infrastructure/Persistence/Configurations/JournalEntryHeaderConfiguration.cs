using ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Persistence.Configurations;

public sealed class JournalEntryHeaderConfiguration : IEntityTypeConfiguration<JournalEntryHeader>
{
    public void Configure(EntityTypeBuilder<JournalEntryHeader> b)
    {
        b.ToTable("JOURNALENTRIES", "dbo");
        b.HasKey(x => new { x.Fran, x.JournalType, x.JournalEntryId });

        b.Property(x => x.Fran).HasColumnName("FRAN").HasMaxLength(10).IsRequired();
        b.Property(x => x.JournalType).HasColumnName("JOURNELTYPE").HasMaxLength(10).IsRequired();
        b.Property(x => x.JournalEntryId).HasColumnName("JOURNELENTRYID").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.JournalEntryDate).HasColumnName("JOURNELENTRYDATE").HasColumnType("date").IsRequired();
        b.Property(x => x.Description).HasColumnName("DESCRIPTION").HasMaxLength(250).IsRequired();
        b.Property(x => x.Reference).HasColumnName("REFERENCE").HasMaxLength(50).IsRequired();


        // 🔹 New Columns
        b.Property(x => x.AccountCode).HasColumnName("ACCOUNTCODE").HasMaxLength(50).IsRequired();
        b.Property(x => x.RefCustomer).HasColumnName("REFCUSTOMER").HasMaxLength(500).IsRequired();
        b.Property(x => x.RefType).HasColumnName("REFTYPE").HasMaxLength(100).IsRequired();
        b.Property(x => x.RefNo).HasColumnName("REFNO").HasMaxLength(100).IsRequired();
        b.Property(x => x.RefDt).HasColumnName("REFDT").HasColumnType("date");
        b.Property(x => x.Amount).HasColumnName("AMOUNT").HasPrecision(22, 0).IsRequired();
        b.Property(x => x.PaymentMethod).HasColumnName("PAYMENTMETHOD").HasMaxLength(500);
        b.Property(x => x.CardNumber).HasColumnName("CARDNUMBER").HasMaxLength(500);
        b.Property(x => x.ChequeDt).HasColumnName("CHEQUEDT").HasColumnType("date");
        b.Property(x => x.Remarks).HasColumnName("REMARKS").HasMaxLength(1000);

        // Audit
        b.Property(x => x.CreateDt).HasColumnName("CREATEDT").HasColumnType("date").IsRequired();
        b.Property(x => x.CreateTm).HasColumnName("CREATETM").HasColumnType("datetime").IsRequired();
        b.Property(x => x.CreateBy).HasColumnName("CREATEBY").HasMaxLength(10).IsRequired();
        b.Property(x => x.CreateRemarks).HasColumnName("CREATEREMARKS").HasMaxLength(200).IsRequired();
        b.Property(x => x.UpdateDt).HasColumnName("UPDATEDT").HasColumnType("date").IsRequired();
        b.Property(x => x.UpdateTm).HasColumnName("UPDATETM").HasColumnType("date").IsRequired();
        b.Property(x => x.UpdateBy).HasColumnName("UPDATEBY").HasMaxLength(10).IsRequired();
        b.Property(x => x.UpdateRemarks).HasColumnName("UPDATEMARKS").HasMaxLength(200).IsRequired();

    }
}
