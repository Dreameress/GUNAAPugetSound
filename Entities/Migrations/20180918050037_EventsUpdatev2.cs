using Microsoft.EntityFrameworkCore.Migrations;

namespace GUNAAPugetSound.Migrations
{
    public partial class EventsUpdatev2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EndTime",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StartTime",
                table: "Events",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Events");
        }
    }
}
