using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MetatraderApi.Migrations
{
    public partial class tbtimeframem10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MetaTraderInfo");

            migrationBuilder.CreateTable(
                name: "TbTimeFrameM10",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Open = table.Column<double>(nullable: false),
                    High = table.Column<double>(nullable: false),
                    Low = table.Column<double>(nullable: false),
                    Close = table.Column<double>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Symbol = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbTimeFrameM10", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbTimeFrameM5",
                columns: table => new
                {
                    Date = table.Column<DateTime>(nullable: false),
                    Symbol = table.Column<string>(nullable: false),
                    Open = table.Column<double>(nullable: false),
                    High = table.Column<double>(nullable: false),
                    Low = table.Column<double>(nullable: false),
                    Close = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbTimeFrameM5", x => new { x.Date, x.Symbol });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbTimeFrameM10");

            migrationBuilder.DropTable(
                name: "TbTimeFrameM5");

            migrationBuilder.CreateTable(
                name: "MetaTraderInfo",
                columns: table => new
                {
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Close = table.Column<double>(type: "float", nullable: false),
                    High = table.Column<double>(type: "float", nullable: false),
                    Low = table.Column<double>(type: "float", nullable: false),
                    Open = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaTraderInfo", x => new { x.Date, x.Symbol });
                });
        }
    }
}
