using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransferEconomic.Data.Migrations
{
    public partial class UpdatedTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ToIdPlace",
                table: "Tickets",
                newName: "ToIdZone");

            migrationBuilder.RenameColumn(
                name: "FromIdPlace",
                table: "Tickets",
                newName: "FromIdZone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ToIdZone",
                table: "Tickets",
                newName: "ToIdPlace");

            migrationBuilder.RenameColumn(
                name: "FromIdZone",
                table: "Tickets",
                newName: "FromIdPlace");
        }
    }
}
