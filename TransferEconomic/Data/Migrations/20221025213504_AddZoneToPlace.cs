using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransferEconomic.Data.Migrations
{
    public partial class AddZoneToPlace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ZoneId",
                table: "Places",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ZoneId",
                table: "Places");
        }
    }
}
