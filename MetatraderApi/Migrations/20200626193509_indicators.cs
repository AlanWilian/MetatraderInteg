using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MetatraderApi.Migrations
{
    public partial class indicators : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbMovingAverage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<double>(nullable: false),
                    Symbol = table.Column<string>(nullable: true),
                    Period = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbMovingAverage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbPriceIndicator",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<double>(nullable: false),
                    Symbol = table.Column<string>(nullable: true),
                    Period = table.Column<int>(nullable: false),
                    HighOrLow = table.Column<string>(nullable: true),
                    DateInput = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbPriceIndicator", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbMovingAverage");

            migrationBuilder.DropTable(
                name: "TbPriceIndicator");
        }
    }
}
