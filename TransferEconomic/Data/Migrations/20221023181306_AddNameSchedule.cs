using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransferEconomic.Data.Migrations
{
    public partial class AddNameSchedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Schedules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Schedules");
        }
    }
}
