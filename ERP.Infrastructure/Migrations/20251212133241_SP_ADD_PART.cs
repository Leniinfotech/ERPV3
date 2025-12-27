using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SP_ADD_PART : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
CREATE OR ALTER PROCEDURE [dbo].[SP_ADD_PART]
(
    @FRAN NVARCHAR(10) = 'A',
    @MAKE NVARCHAR(10),
    @PART NVARCHAR(10),       
    @DESC NVARCHAR(200),
    @INVCLASS NVARCHAR(50),
    @CATEGORY NVARCHAR(50),
    @GROUP NVARCHAR(50),
    @COO NVARCHAR(100)
)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @STOCKKEY NVARCHAR(50) = CONCAT(@FRAN, '-', @MAKE, '-', @PART);

    INSERT INTO [dbo].[PARTS]
    (
        FRAN, MAKE, PART, [DESC], STOCKKEY, BARCODE, SUBSPART, FINALPART,
        LC, FOB, INVCLASS, CATEGORY, [GROUP], COO, NETWEIGHT, STOCK,
        CMSALE, LMSALE, M3SALE, M6SALE, M12SALE, AVGM6, ACTIVE,
        CREATEDT, CREATEBY, CREATEREMARKS,
        UPDATEDT, UPDATEBY, UPDATEMARKS
    )
    VALUES
    (
        @FRAN, @MAKE, @PART, @DESC, @STOCKKEY,
        '0','0','0',0,0, @INVCLASS,
        @CATEGORY, @GROUP, @COO,
        0,0,0,0,0,0,0,0,1,
        CAST(GETDATE() AS DATE), 
        'System', 'Auto-created',
        CAST(GETDATE() AS DATE), 
        'System', 'Initial insert'
    );
END

");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE IF EXISTS [dbo].[SP_ADD_PART]");

        }
    }
}
