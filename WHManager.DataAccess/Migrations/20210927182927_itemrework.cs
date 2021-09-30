using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WHManager.DataAccess.Migrations
{
    public partial class itemrework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateReceived",
                table: "OutgoingDocuments");

            migrationBuilder.DropColumn(
                name: "Source",
                table: "OutgoingDocuments");

            migrationBuilder.DropColumn(
                name: "DateSent",
                table: "IncomingDocuments");

            migrationBuilder.DropColumn(
                name: "Source",
                table: "IncomingDocuments");

            migrationBuilder.AddColumn<int>(
                name: "DeliveryIt",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryIt",
                table: "Items");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateReceived",
                table: "OutgoingDocuments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Source",
                table: "OutgoingDocuments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateSent",
                table: "IncomingDocuments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Source",
                table: "IncomingDocuments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
