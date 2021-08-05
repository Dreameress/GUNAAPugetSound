using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class InitializeDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    AlbumId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 160, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.AlbumId);
                });

            migrationBuilder.CreateTable(
                name: "CommitteeMembers",
                columns: table => new
                {
                    CommitteeId = table.Column<Guid>(nullable: false),
                    Committee = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    Updated = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    MemberId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommitteeMembers", x => x.CommitteeId);
                });

            migrationBuilder.CreateTable(
                name: "Content",
                columns: table => new
                {
                    ContentId = table.Column<Guid>(nullable: false),
                    HomeMainHeader = table.Column<string>(nullable: true),
                    HomeSubHeader = table.Column<string>(nullable: true),
                    HomeLine1 = table.Column<string>(nullable: true),
                    HomeLine2 = table.Column<string>(nullable: true),
                    HomeLine3 = table.Column<string>(nullable: true),
                    HomeLine4 = table.Column<string>(nullable: true),
                    CalendarMainHeader = table.Column<string>(nullable: true),
                    CalendarSubHeader = table.Column<string>(nullable: true),
                    OfficersMainHeader = table.Column<string>(nullable: true),
                    OfficersSubHeader = table.Column<string>(nullable: true),
                    CommitteesMainHeader = table.Column<string>(nullable: true),
                    CommitteesSubHeader = table.Column<string>(nullable: true),
                    MembershipMainHeader = table.Column<string>(nullable: true),
                    MembershipSubHeader = table.Column<string>(nullable: true),
                    MemberShipName1 = table.Column<string>(nullable: true),
                    Membership1Amount1 = table.Column<string>(nullable: true),
                    Membership1Amount2 = table.Column<string>(nullable: true),
                    Membership1Amount3 = table.Column<string>(nullable: true),
                    MemberShipName2 = table.Column<string>(nullable: true),
                    Membership2Amount1 = table.Column<string>(nullable: true),
                    Membership2Amount2 = table.Column<string>(nullable: true),
                    Membership2Amount3 = table.Column<string>(nullable: true),
                    ScholarshipMainHeader = table.Column<string>(nullable: true),
                    ScholarshipSubHeader = table.Column<string>(nullable: true),
                    ScholarshipLine1 = table.Column<string>(nullable: true),
                    PhotoMainHeader = table.Column<string>(nullable: true),
                    PhotoSubHeader = table.Column<string>(nullable: true),
                    AboutUsHeader = table.Column<string>(nullable: true),
                    AboutUsSubHeader = table.Column<string>(nullable: true),
                    AboutUsQuoteLine1 = table.Column<string>(nullable: true),
                    AboutUsQuoteLine2 = table.Column<string>(nullable: true),
                    AboutUsQuoteLine3 = table.Column<string>(nullable: true),
                    AboutUsQuoteLine4 = table.Column<string>(nullable: true),
                    ContactUsHeader = table.Column<string>(nullable: true),
                    ContactUsSubHeader = table.Column<string>(nullable: true),
                    ContactUsAddressName1 = table.Column<string>(nullable: true),
                    ContactUsAddressName2 = table.Column<string>(nullable: true),
                    ContactUsStreetAddress = table.Column<string>(nullable: true),
                    ContactUsCity = table.Column<string>(nullable: true),
                    ContactUsState = table.Column<string>(nullable: true),
                    ContactUsZipCode = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: true),
                    LastUpdatedUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content", x => x.ContentId);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    NameFirst = table.Column<string>(nullable: true),
                    NameLast = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    GraduationYear = table.Column<int>(nullable: false),
                    LinkedIn = table.Column<string>(nullable: true),
                    Twitter = table.Column<string>(nullable: true),
                    Facebook = table.Column<string>(nullable: true),
                    Instagram = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    Committee = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberId);
                });

            migrationBuilder.CreateTable(
                name: "Officers",
                columns: table => new
                {
                    OfficerId = table.Column<Guid>(nullable: false),
                    Role = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    Updated = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    MemberId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Officers", x => x.OfficerId);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    PhotoId = table.Column<Guid>(nullable: false),
                    AlbumId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    ThumbPath = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    AddedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.PhotoId);
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    RefreshTokenId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(nullable: false),
                    Token = table.Column<string>(nullable: true),
                    ExpiryDate = table.Column<DateTime>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedByIp = table.Column<string>(nullable: true),
                    Revoked = table.Column<DateTime>(nullable: true),
                    RevokedByIp = table.Column<string>(nullable: true),
                    ReplacedByToken = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.RefreshTokenId);
                    table.ForeignKey(
                        name: "FK_RefreshToken_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_AccountId",
                table: "RefreshToken",
                column: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "CommitteeMembers");

            migrationBuilder.DropTable(
                name: "Content");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Officers");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
