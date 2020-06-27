using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MetatraderApi.Migrations
{
    public partial class collumndate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateInput",
                table: "TbMovingAverage",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateInput",
                table: "TbMovingAverage");
        }
    }
}
