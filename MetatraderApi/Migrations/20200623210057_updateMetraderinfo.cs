using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MetatraderApi.Migrations
{
    public partial class updateMetraderinfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataReceived",
                table: "MetaTraderInfo");

            migrationBuilder.AddColumn<double>(
                name: "Close",
                table: "MetaTraderInfo",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "MetaTraderInfo",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "High",
                table: "MetaTraderInfo",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Low",
                table: "MetaTraderInfo",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Open",
                table: "MetaTraderInfo",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Symbol",
                table: "MetaTraderInfo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Close",
                table: "MetaTraderInfo");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "MetaTraderInfo");

            migrationBuilder.DropColumn(
                name: "High",
                table: "MetaTraderInfo");

            migrationBuilder.DropColumn(
                name: "Low",
                table: "MetaTraderInfo");

            migrationBuilder.DropColumn(
                name: "Open",
                table: "MetaTraderInfo");

            migrationBuilder.DropColumn(
                name: "Symbol",
                table: "MetaTraderInfo");

            migrationBuilder.AddColumn<string>(
                name: "DataReceived",
                table: "MetaTraderInfo",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
