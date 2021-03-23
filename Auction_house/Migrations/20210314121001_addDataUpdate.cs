using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Auction_house.Migrations
{
    public partial class addDataUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndData",
                table: "Auctions");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Auctions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Auctions");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndData",
                table: "Auctions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
