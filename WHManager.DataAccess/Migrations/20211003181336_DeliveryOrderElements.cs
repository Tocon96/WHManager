using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WHManager.DataAccess.Migrations
{
    public partial class DeliveryOrderElements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateOfArrival",
                table: "Deliveries",
                newName: "DateCreated");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRealized",
                table: "Deliveries",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Realized",
                table: "Deliveries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "DeliveryElements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductCount = table.Column<int>(type: "int", nullable: false),
                    DeliveryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryElements", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryElements");

            migrationBuilder.DropColumn(
                name: "DateRealized",
                table: "Deliveries");

            migrationBuilder.DropColumn(
                name: "Realized",
                table: "Deliveries");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Deliveries",
                newName: "DateOfArrival");
        }
    }
}
