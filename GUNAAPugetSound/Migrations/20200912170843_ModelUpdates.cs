using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GUNAAPugetSound.Migrations
{
    public partial class ModelUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlbumDesc",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "AlbumName",
                table: "Albums");

            migrationBuilder.RenameColumn(
                name: "CreateTime",
                table: "Albums",
                newName: "CreatedTime");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "UsersRefreshToken",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "UsersRefreshToken",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedByIp",
                table: "UsersRefreshToken",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReplacedByToken",
                table: "UsersRefreshToken",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Revoked",
                table: "UsersRefreshToken",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RevokedByIp",
                table: "UsersRefreshToken",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Albums",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Albums",
                maxLength: 160,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    AcceptTerms = table.Column<bool>(nullable: false),
                    Role = table.Column<int>(nullable: false),
                    VerificationToken = table.Column<string>(nullable: true),
                    Verified = table.Column<DateTime>(nullable: true),
                    ResetToken = table.Column<string>(nullable: true),
                    ResetTokenExpires = table.Column<DateTime>(nullable: true),
                    PasswordReset = table.Column<DateTime>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersRefreshToken_AccountId",
                table: "UsersRefreshToken",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersRefreshToken_Accounts_AccountId",
                table: "UsersRefreshToken",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersRefreshToken_Accounts_AccountId",
                table: "UsersRefreshToken");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_UsersRefreshToken_AccountId",
                table: "UsersRefreshToken");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "UsersRefreshToken");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "UsersRefreshToken");

            migrationBuilder.DropColumn(
                name: "CreatedByIp",
                table: "UsersRefreshToken");

            migrationBuilder.DropColumn(
                name: "ReplacedByToken",
                table: "UsersRefreshToken");

            migrationBuilder.DropColumn(
                name: "Revoked",
                table: "UsersRefreshToken");

            migrationBuilder.DropColumn(
                name: "RevokedByIp",
                table: "UsersRefreshToken");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Albums");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "Albums",
                newName: "CreateTime");

            migrationBuilder.AddColumn<string>(
                name: "AlbumDesc",
                table: "Albums",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AlbumName",
                table: "Albums",
                type: "nvarchar(160)",
                maxLength: 160,
                nullable: false,
                defaultValue: "");
        }
    }
}
