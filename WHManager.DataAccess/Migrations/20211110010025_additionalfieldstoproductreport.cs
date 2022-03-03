using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WHManager.DataAccess.Migrations
{
    public partial class additionalfieldstoproductreport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTo",
                table: "ProductReports",
                newName: "DateOrderedTo");

            migrationBuilder.RenameColumn(
                name: "DateFrom",
                table: "ProductReports",
                newName: "DateOrderedFrom");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeliveredFrom",
                table: "ProductReports",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeliveredTo",
                table: "ProductReports",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateDeliveredFrom",
                table: "ProductReports");

            migrationBuilder.DropColumn(
                name: "DateDeliveredTo",
                table: "ProductReports");

            migrationBuilder.RenameColumn(
                name: "DateOrderedTo",
                table: "ProductReports",
                newName: "DateTo");

            migrationBuilder.RenameColumn(
                name: "DateOrderedFrom",
                table: "ProductReports",
                newName: "DateFrom");
        }
    }
}
