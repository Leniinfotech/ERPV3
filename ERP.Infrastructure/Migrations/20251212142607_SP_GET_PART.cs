using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SP_GET_PART : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
CREATE PROCEDURE [dbo].[SP_GET_PART]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        ID, FRAN, MAKE, PART, [DESC], STOCKKEY, BARCODE, SUBSPART, FINALPART, LC, FOB, INVCLASS, CATEGORY, [GROUP], COO, NETWEIGHT, STOCK, CMSALE, LMSALE,
        M3SALE, M6SALE, M12SALE, AVGM6, ACTIVE, CREATEDT, CREATEBY, CREATEREMARKS, UPDATEDT, UPDATEBY, UPDATEMARKS
    FROM dbo.PARTS
    ORDER BY ID DESC; 
END
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE IF EXISTS [dbo].[SP_GET_PART]");
        }
    }
}
