using Microsoft.EntityFrameworkCore.Migrations;

namespace MetatraderApi.Migrations
{
    public partial class compkeyMetaTraderInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MetaTraderInfo",
                table: "MetaTraderInfo");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MetaTraderInfo");

            migrationBuilder.AlterColumn<string>(
                name: "Symbol",
                table: "MetaTraderInfo",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MetaTraderInfo",
                table: "MetaTraderInfo",
                columns: new[] { "Date", "Symbol" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MetaTraderInfo",
                table: "MetaTraderInfo");

            migrationBuilder.AlterColumn<string>(
                name: "Symbol",
                table: "MetaTraderInfo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "MetaTraderInfo",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MetaTraderInfo",
                table: "MetaTraderInfo",
                column: "Id");
        }
    }
}
