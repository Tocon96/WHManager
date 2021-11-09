using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WHManager.DataAccess.Migrations
{
    public partial class reports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Clients_ClientId",
                table: "Invoices");

            migrationBuilder.AddColumn<bool>(
                name: "Report",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ContrahentReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportOrigin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContrahentId = table.Column<int>(type: "int", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContrahentReports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    ManufacturerId = table.Column<int>(type: "int", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReports", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Clients_ClientId",
                table: "Invoices",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Clients_ClientId",
                table: "Invoices");

            migrationBuilder.DropTable(
                name: "ContrahentReports");

            migrationBuilder.DropTable(
                name: "ProductReports");

            migrationBuilder.DropColumn(
                name: "Report",
                table: "Roles");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Clients_ClientId",
                table: "Invoices",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
