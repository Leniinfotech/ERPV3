using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnsToJournalEntries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ACCOUNTCODE",
                schema: "dbo",
                table: "JOURNALENTRIES",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "AMOUNT",
                schema: "dbo",
                table: "JOURNALENTRIES",
                type: "decimal(22,0)",
                precision: 22,
                scale: 0,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "CARDNUMBER",
                schema: "dbo",
                table: "JOURNALENTRIES",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CHEQUEDT",
                schema: "dbo",
                table: "JOURNALENTRIES",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PAYMENTMETHOD",
                schema: "dbo",
                table: "JOURNALENTRIES",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "REFCUSTOMER",
                schema: "dbo",
                table: "JOURNALENTRIES",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "REFDT",
                schema: "dbo",
                table: "JOURNALENTRIES",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "REFNO",
                schema: "dbo",
                table: "JOURNALENTRIES",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "REFTYPE",
                schema: "dbo",
                table: "JOURNALENTRIES",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "REMARKS",
                schema: "dbo",
                table: "JOURNALENTRIES",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ACCOUNTCODE",
                schema: "dbo",
                table: "JOURNALENTRIES");

            migrationBuilder.DropColumn(
                name: "AMOUNT",
                schema: "dbo",
                table: "JOURNALENTRIES");

            migrationBuilder.DropColumn(
                name: "CARDNUMBER",
                schema: "dbo",
                table: "JOURNALENTRIES");

            migrationBuilder.DropColumn(
                name: "CHEQUEDT",
                schema: "dbo",
                table: "JOURNALENTRIES");

            migrationBuilder.DropColumn(
                name: "PAYMENTMETHOD",
                schema: "dbo",
                table: "JOURNALENTRIES");

            migrationBuilder.DropColumn(
                name: "REFCUSTOMER",
                schema: "dbo",
                table: "JOURNALENTRIES");

            migrationBuilder.DropColumn(
                name: "REFDT",
                schema: "dbo",
                table: "JOURNALENTRIES");

            migrationBuilder.DropColumn(
                name: "REFNO",
                schema: "dbo",
                table: "JOURNALENTRIES");

            migrationBuilder.DropColumn(
                name: "REFTYPE",
                schema: "dbo",
                table: "JOURNALENTRIES");

            migrationBuilder.DropColumn(
                name: "REMARKS",
                schema: "dbo",
                table: "JOURNALENTRIES");
        }
    }
}
