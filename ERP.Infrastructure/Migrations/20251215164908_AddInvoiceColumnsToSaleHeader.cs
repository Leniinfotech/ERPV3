using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddInvoiceColumnsToSaleHeader : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                    name: "INVOICENO",
                    schema: "dbo",
                    table: "SALEHDR",
                    type: "nvarchar(20)",
                    maxLength: 20,
                    nullable: false,
                    defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "INVOICEDATE",
                schema: "dbo",
                table: "SALEHDR",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1900, 1, 1));

            migrationBuilder.AddColumn<DateTime>(
                name: "DUEDATE",
                schema: "dbo",
                table: "SALEHDR",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GETDATE()");
        }
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
        name: "INVOICENO",
        schema: "dbo",
        table: "SALEHDR");

            migrationBuilder.DropColumn(
                name: "INVOICEDATE",
                schema: "dbo",
                table: "SALEHDR");

            migrationBuilder.DropColumn(
                name: "DUEDATE",
                schema: "dbo",
                table: "SALEHDR");
        }
    }
}
