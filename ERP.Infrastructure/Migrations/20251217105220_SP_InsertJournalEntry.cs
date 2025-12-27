using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SP_InsertJournalEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
CREATE OR ALTER PROCEDURE [dbo].[SP_InsertJournalEntry]
(
    @Customer           NVARCHAR(100),
    @SaleNo             VARCHAR(100),
    @BillAmount         NUMERIC(22,0),
    @PaymentMethod      VARCHAR(500),
    @CardNumber         VARCHAR(500),
    @Remarks            VARCHAR(1000)
)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Fran NVARCHAR(10) = 'A';      
    DECLARE @JournalType NVARCHAR(20);

    -- Set JOURNALTYPE based on SaleNo prefix
    IF LEFT(@SaleNo, 1) = 'R'
        SET @JournalType = 'RECEIPT';
    ELSE IF LEFT(@SaleNo, 1) = 'P'
        SET @JournalType = 'PAYMENT';
    ELSE
        SET @JournalType = 'PAY';

    DECLARE @JournalEntryId NUMERIC(22,0);

    SELECT @JournalEntryId = ISNULL(MAX(JOURNELENTRYID), 0) + 1 
    FROM JOURNALENTRIES;

    DECLARE @REFTYPE NVARCHAR(100);

    SET @REFTYPE = (
        SELECT SALETYPE 
        FROM SALEHDR 
        WHERE SALENO = @SaleNo
    );

    INSERT INTO JOURNALENTRIES
    (
        FRAN,
        ACCOUNTCODE,
        JOURNELTYPE,
        JOURNELENTRYID,
        JOURNELENTRYDATE,
        DESCRIPTION,
        REFCUSTOMER,
        REFERENCE,
        REFTYPE,
        REFNO,
        REFDT,
        AMOUNT,
        PAYMENTMETHOD,
        CARDNUMBER,
        CHEQUEDT,
        REMARKS,
        CREATEDT,
        CREATETM,
        CREATEBY,
        CREATEREMARKS,
        UPDATEDT,
        UPDATETM,
        UPDATEBY,
        UPDATEMARKS
    )
    VALUES
    (
        @Fran,
        '',
        @JournalType,
        @JournalEntryId,
        GETDATE(),
        'Journal Entry',
        @Customer,
        '',
        @REFTYPE,
        @SaleNo,
        GETDATE(),
        @BillAmount,
        @PaymentMethod,
        @CardNumber,
        GETDATE(),
        @Remarks,
        GETDATE(),
        GETDATE(),
        'SYSTEM',
        '',
        GETDATE(),
        GETDATE(),
        '',
        ''
    );
END
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE IF EXISTS [dbo].[SP_InsertJournalEntry]");
        }
    }
}
