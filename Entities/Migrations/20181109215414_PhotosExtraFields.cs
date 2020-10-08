using Microsoft.EntityFrameworkCore.Migrations;

namespace GUNAAPugetSound.Migrations
{
    public partial class PhotosExtraFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddedBy",
                table: "Photos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "Photos");
        }
    }
}
