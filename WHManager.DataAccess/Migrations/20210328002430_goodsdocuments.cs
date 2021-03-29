using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WHManager.DataAccess.Migrations
{
    public partial class goodsdocuments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GoodsDocumentId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GoodsDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateIssued = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Source = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsDocuments", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_GoodsDocumentId",
                table: "Products",
                column: "GoodsDocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_GoodsDocuments_GoodsDocumentId",
                table: "Products",
                column: "GoodsDocumentId",
                principalTable: "GoodsDocuments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_GoodsDocuments_GoodsDocumentId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "GoodsDocuments");

            migrationBuilder.DropIndex(
                name: "IX_Products_GoodsDocumentId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "GoodsDocumentId",
                table: "Products");
        }
    }
}
