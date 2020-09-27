using Microsoft.EntityFrameworkCore.Migrations;

namespace WHManager.DataAccess.Migrations
{
    public partial class itemmodelupdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateOfSale",
                table: "Items",
                newName: "DateOfEmission");

            migrationBuilder.RenameColumn(
                name: "DateOfPurchase",
                table: "Items",
                newName: "DateOfAdmission");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateOfEmission",
                table: "Items",
                newName: "DateOfSale");

            migrationBuilder.RenameColumn(
                name: "DateOfAdmission",
                table: "Items",
                newName: "DateOfPurchase");
        }
    }
}
