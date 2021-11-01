using Microsoft.EntityFrameworkCore.Migrations;

namespace WHManager.DataAccess.Migrations
{
    public partial class addinvoicetoitem2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_InvoiceId",
                table: "Items",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Invoices_InvoiceId",
                table: "Items",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Invoices_InvoiceId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_InvoiceId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "Items");
        }
    }
}
