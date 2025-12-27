using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SP_SALEHDR : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
CREATE OR ALTER PROCEDURE [dbo].[SP_SALEHDR]
(
    @FRAN NVARCHAR(50) = NULL,
    @Mode NVARCHAR(50)
)
AS
BEGIN
    SET NOCOUNT ON;

    IF (@Mode = 'Receivable')
    BEGIN
        SELECT 
            S.CUSTOMER,
            S.INVOICENO,
            S.INVOICEDATE,
            S.DUEDATE,
            S.TOTALVALUE,
            ISNULL(P.PAIDAMOUNT, 0) AS PAID,
            (S.TOTALVALUE - ISNULL(P.PAIDAMOUNT, 0)) AS PENDING,
            CASE 
                WHEN ISNULL(P.PAIDAMOUNT, 0) = 0 THEN 'PENDING'
                WHEN ISNULL(P.PAIDAMOUNT, 0) < S.TOTALVALUE THEN 'PARTIALLY PAID'
                WHEN ISNULL(P.PAIDAMOUNT, 0) >= S.TOTALVALUE THEN 'PAID'
            END AS STATUS
        FROM SALEHDR S
        LEFT JOIN (
            SELECT 
                REFNO AS SaleNo,
                SUM(AMOUNT) AS PAIDAMOUNT
            FROM JOURNALENTRIES
            WHERE JOURNELTYPE IN ('PAYMENT', 'RECEIPT')
            GROUP BY REFNO
        ) P ON P.SaleNo = S.INVOICENO
        WHERE S.FRAN = @FRAN
          AND S.CUSTOMER LIKE 'CU%'
        ORDER BY S.INVOICEDATE DESC;
    END

    IF (@Mode = 'Payable')
    BEGIN
        SELECT 
            S.CUSTOMER,
            S.INVOICENO,
            S.INVOICEDATE,
            S.DUEDATE,
            S.TOTALVALUE,
            ISNULL(P.PAIDAMOUNT, 0) AS PAID,
            (S.TOTALVALUE - ISNULL(P.PAIDAMOUNT, 0)) AS PENDING,
            CASE 
                WHEN ISNULL(P.PAIDAMOUNT, 0) = 0 THEN 'PENDING'
                WHEN ISNULL(P.PAIDAMOUNT, 0) < S.TOTALVALUE THEN 'PARTIALLY PAID'
                WHEN ISNULL(P.PAIDAMOUNT, 0) >= S.TOTALVALUE THEN 'PAID'
            END AS STATUS
        FROM SALEHDR S
        LEFT JOIN (
            SELECT 
                REFNO AS SaleNo,
                SUM(AMOUNT) AS PAIDAMOUNT
            FROM JOURNALENTRIES
            WHERE JOURNELTYPE IN ('PAYMENT', 'RECEIPT')
            GROUP BY REFNO
        ) P ON P.SaleNo = S.INVOICENO
        WHERE S.FRAN = @FRAN
          AND S.CUSTOMER LIKE 'VE%'
        ORDER BY S.INVOICEDATE DESC;
    END
END
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE IF EXISTS [dbo].[SP_SALEHDR]");

        }
    }
}
