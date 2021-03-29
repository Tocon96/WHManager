using Microsoft.EntityFrameworkCore.Migrations;

namespace WHManager.DataAccess.Migrations
{
    public partial class updateGoodsDocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_GoodsDocuments_GoodsDocumentId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_GoodsDocumentId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "GoodsDocumentId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "GoodsDocumentId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Destination",
                table: "GoodsDocuments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Items_GoodsDocumentId",
                table: "Items",
                column: "GoodsDocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_GoodsDocuments_GoodsDocumentId",
                table: "Items",
                column: "GoodsDocumentId",
                principalTable: "GoodsDocuments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_GoodsDocuments_GoodsDocumentId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_GoodsDocumentId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "GoodsDocumentId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Destination",
                table: "GoodsDocuments");

            migrationBuilder.AddColumn<int>(
                name: "GoodsDocumentId",
                table: "Products",
                type: "int",
                nullable: true);

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
    }
}
