using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SP_GetMakeList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql(@"
        CREATE PROCEDURE [dbo].[SP_GetMakeList]
        AS
        BEGIN
            SET NOCOUNT ON;

            SELECT 
                ID,
                FRAN,
                MAKE,
                NAME,
                NAMEAR,
                CREATEBY,
                CREATEDT,
                CREATETM,
                CREATEREMARKS,
                UPDATEBY,
                UPDATEDT,
                UPDATETM,
                UPDATEREMARKS
            FROM MAKE;
        END
    ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE [dbo].[SP_GetMakeList]");
        }
    }
}
