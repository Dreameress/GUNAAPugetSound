using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "__MigrationHistory",
                columns: table => new
                {
                    MigrationId = table.Column<string>(maxLength: 150, nullable: false),
                    ContextKey = table.Column<string>(maxLength: 300, nullable: false),
                    Model = table.Column<byte[]>(nullable: false),
                    ProductVersion = table.Column<string>(maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK___MigrationHistory", x => new { x.MigrationId, x.ContextKey });
                });

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
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(maxLength: 160, nullable: false, defaultValueSql: "('')"),
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
                    Description = table.Column<string>(nullable: true, defaultValueSql: "('')"),
                    ImagePath = table.Column<string>(nullable: false),
                    ThumbPath = table.Column<string>(nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    AddedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.PhotoId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
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

            migrationBuilder.InsertData(
                table: "CommitteeMembers",
                columns: new[] { "CommitteeId", "Active", "Committee", "Created", "CreatedBy", "FirstName", "LastName", "MemberId", "Updated", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("b6dafd21-7cfc-4d54-ab5b-52247ce67b97"), true, 2, new DateTime(2021, 7, 7, 20, 46, 51, 778, DateTimeKind.Utc).AddTicks(7199), null, "Don", "Paul", null, null, null },
                    { new Guid("16f552f0-e0f7-45a2-9680-ac5f41964ba8"), true, 3, new DateTime(2021, 7, 7, 20, 46, 51, 778, DateTimeKind.Utc).AddTicks(7939), null, "Tammy", "Richardson", null, null, null },
                    { new Guid("ceb8924c-9a60-481f-a08d-1540ff8662c6"), true, 4, new DateTime(2021, 7, 7, 20, 46, 51, 778, DateTimeKind.Utc).AddTicks(7965), null, "Eva", "Edwards", null, null, null },
                    { new Guid("865bd307-0fe3-4db7-b88c-3627b1ada2ac"), true, 1, new DateTime(2021, 7, 7, 20, 46, 51, 778, DateTimeKind.Utc).AddTicks(7969), null, "Marcus", "Dabney", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Content",
                columns: new[] { "ContentId", "AboutUsHeader", "AboutUsQuoteLine1", "AboutUsQuoteLine2", "AboutUsQuoteLine3", "AboutUsQuoteLine4", "AboutUsSubHeader", "CalendarMainHeader", "CalendarSubHeader", "CommitteesMainHeader", "CommitteesSubHeader", "ContactUsAddressName1", "ContactUsAddressName2", "ContactUsCity", "ContactUsHeader", "ContactUsState", "ContactUsStreetAddress", "ContactUsSubHeader", "ContactUsZipCode", "Created", "HomeLine1", "HomeLine2", "HomeLine3", "HomeLine4", "HomeMainHeader", "HomeSubHeader", "LastUpdatedUserId", "MemberShipName1", "MemberShipName2", "Membership1Amount1", "Membership1Amount2", "Membership1Amount3", "Membership2Amount1", "Membership2Amount2", "Membership2Amount3", "MembershipMainHeader", "MembershipSubHeader", "OfficersMainHeader", "OfficersSubHeader", "PhotoMainHeader", "PhotoSubHeader", "ScholarshipLine1", "ScholarshipMainHeader", "ScholarshipSubHeader", "Updated" },
                values: new object[] { new Guid("2ef51746-56bc-4b13-8cf9-7325767e434c"), "About Us", "The purpose of the chapter is : (1) To maintain a working relationship with the University;", "(2) To promote interest in the University among prospective students;", "(3) To promote fellowship among the alumni; and", "(4) To promote and maintain a positive image of the University in the community.", "Mission", "Calendar", "Keeping you updated with Events, Meetings, and more from GUNAA Puget Sound", "Committees", "Committee Chairs for Grambling University National Alumni Association of Puget Sound", "Grambling University National Alumni Association", "Puget Sound Chapter", "Seattle", "Contact Us", "Washington", "Post Office Box 18321", null, "98118", new DateTime(2021, 7, 7, 20, 46, 51, 780, DateTimeKind.Utc).AddTicks(7650), "We would like to welcome all alumni and supporters living in and visiting the Seattle area. We welcome your support as we continue our mission of recruiting students to our alma mater. ", "If you are in the Puget Sound area and interested in attending Grambling State University or currently attending Grambling State University, please reach out to us for information on the scholarships we provide.", "Go Tigers!!!", "Grambling, Where Everybody is Somebody", "Welcome", "Welcome to the Home Site of the Puget Sound Chapter Of the Grambling University National Alumni Association", 0, "GUNAA", "GUNAA Puget Sound Chapter", "National Dues (Yearly) $70", "Life Membership (Single) $500", "Life Membership (Couples) $750", "Local Dues Regular Members $40", "Local Dues Associate Members (family/friends) $35", null, "Membership", "Alumni Association Dues Structure", "Officers", "Leaders of Grambling University National Alumni Association of Puget Sound", "Photos", "Captured Moments from the GUNAA Events, Meetings, Fundraisers, and more", null, "Scholarship", "Scholarship Program", null });

            migrationBuilder.InsertData(
                table: "Officers",
                columns: new[] { "OfficerId", "Active", "Created", "CreatedBy", "FirstName", "LastName", "MemberId", "Role", "Updated", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("8b7ba2e1-ddc6-4aeb-9de6-2eb2db5922d3"), true, new DateTime(2021, 7, 7, 20, 46, 51, 776, DateTimeKind.Utc).AddTicks(3311), null, "Charlene", "Francisco", null, 1, null, null },
                    { new Guid("3aaa06e9-b5bf-46f9-91e1-018fdbc0d407"), true, new DateTime(2021, 7, 7, 20, 46, 51, 776, DateTimeKind.Utc).AddTicks(3718), null, "Jeanie", "Nelson", null, 3, null, null },
                    { new Guid("59db7597-7941-4b1e-8398-4a62f67eac46"), true, new DateTime(2021, 7, 7, 20, 46, 51, 776, DateTimeKind.Utc).AddTicks(3729), null, "Eva", "Edwards", null, 4, null, null },
                    { new Guid("25ff8f70-af5a-45b1-80f3-4d705be80e2e"), true, new DateTime(2021, 7, 7, 20, 46, 51, 776, DateTimeKind.Utc).AddTicks(3732), null, "Beverly", "Hopkins", null, 2, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_AccountId",
                table: "RefreshToken",
                column: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "__MigrationHistory");

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
                name: "Users");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
