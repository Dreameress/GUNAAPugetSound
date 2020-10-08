using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GUNAAPugetSound.Migrations
{
    public partial class ContentAndRestructuring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Header",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "Line1",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "Line2",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "Line3",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "SubHeader",
                table: "Content");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Photos",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Photos",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AboutUsQuote",
                table: "Content",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AboutUsSubHeader",
                table: "Content",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CalendarSubHeader",
                table: "Content",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CommitteesSubHeader",
                table: "Content",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactUsAddressName1",
                table: "Content",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactUsAddressName2",
                table: "Content",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactUsCityStateZip",
                table: "Content",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactUsStreetAddress",
                table: "Content",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactUsSubHeader",
                table: "Content",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Content",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "HomeLine1",
                table: "Content",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeLine2",
                table: "Content",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeLine3",
                table: "Content",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeSubHeader",
                table: "Content",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LastUpdatedUserId",
                table: "Content",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MemberShipName1",
                table: "Content",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MemberShipName2",
                table: "Content",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Membership1Amount1",
                table: "Content",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Membership1Amount2",
                table: "Content",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Membership1Amount3",
                table: "Content",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Membership2Amount1",
                table: "Content",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Membership2Amount2",
                table: "Content",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Membership2Amount3",
                table: "Content",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MembershipSubHeader",
                table: "Content",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OfficersSubHeader",
                table: "Content",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoSubHeader",
                table: "Content",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ScholarshipDocumentName1",
                table: "Content",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ScholarshipDocumentName2",
                table: "Content",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ScholarshipDocumentName3",
                table: "Content",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ScholarshipLine1",
                table: "Content",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ScholarshipSubHeader",
                table: "Content",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                table: "Content",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CommitteeMembers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: true),
                    MemberId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommitteeMembers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Officers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: true),
                    MemberId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Officers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommitteeMembers");

            migrationBuilder.DropTable(
                name: "Officers");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "AboutUsQuote",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "AboutUsSubHeader",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "CalendarSubHeader",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "CommitteesSubHeader",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "ContactUsAddressName1",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "ContactUsAddressName2",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "ContactUsCityStateZip",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "ContactUsStreetAddress",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "ContactUsSubHeader",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "HomeLine1",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "HomeLine2",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "HomeLine3",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "HomeSubHeader",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "LastUpdatedUserId",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "MemberShipName1",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "MemberShipName2",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "Membership1Amount1",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "Membership1Amount2",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "Membership1Amount3",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "Membership2Amount1",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "Membership2Amount2",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "Membership2Amount3",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "MembershipSubHeader",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "OfficersSubHeader",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "PhotoSubHeader",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "ScholarshipDocumentName1",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "ScholarshipDocumentName2",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "ScholarshipDocumentName3",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "ScholarshipLine1",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "ScholarshipSubHeader",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "Updated",
                table: "Content");

            migrationBuilder.AddColumn<string>(
                name: "Header",
                table: "Content",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Line1",
                table: "Content",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Line2",
                table: "Content",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Line3",
                table: "Content",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubHeader",
                table: "Content",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
