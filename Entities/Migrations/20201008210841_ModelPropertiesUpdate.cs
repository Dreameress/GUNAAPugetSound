using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GUNAAPugetSound.Migrations
{
    public partial class ModelPropertiesUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Officers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "Officers",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Events",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Events",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "End",
                table: "Events",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Start",
                table: "Events",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                table: "Events",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "Events",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated",
                table: "CommitteeMembers",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "CommitteeMembers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "CommitteeMembers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Officers");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Officers");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "End",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Updated",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CommitteeMembers");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "CommitteeMembers");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "EndDate",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StartDate",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated",
                table: "CommitteeMembers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
