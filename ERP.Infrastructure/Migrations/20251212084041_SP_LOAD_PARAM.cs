using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SP_LOAD_PARAM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
CREATE OR ALTER PROCEDURE [dbo].[SP_LOAD_PARAM]
(
    @FRAN varchar(10) = NULL, 
    @PARAMTYPE varchar(50) = NULL
)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        PARAMVALUE,
        PARAMDESC
    FROM PARAMS
    WHERE PARAMTYPE = @PARAMTYPE 
      AND FRAN = @FRAN
    ORDER BY PARAMVALUE;
END;
");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE [dbo].[SP_LOAD_PARAM]");

        }
    }
}
