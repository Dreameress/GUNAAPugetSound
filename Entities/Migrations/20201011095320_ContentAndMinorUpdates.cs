using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GUNAAPugetSound.Migrations
{
    public partial class ContentAndMinorUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Photos",
                table: "Photos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Officers",
                table: "Officers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Members",
                table: "Members");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Content",
                table: "Content");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommitteeMembers",
                table: "CommitteeMembers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Albums",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Officers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "AboutUsQuote",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "ContactUsCityStateZip",
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
                name: "View",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CommitteeMembers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "CommitteeMembers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Albums");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Photos",
                nullable: true,
                defaultValueSql: "('')",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValueSql: "('')");

            migrationBuilder.AddColumn<Guid>(
                name: "PhotoId",
                table: "Photos",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "OfficerId",
                table: "Officers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MemberId",
                table: "Members",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated",
                table: "Events",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<Guid>(
                name: "EventId",
                table: "Events",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ContentId",
                table: "Content",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "AboutUsHeader",
                table: "Content",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AboutUsQuoteLine1",
                table: "Content",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AboutUsQuoteLine2",
                table: "Content",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AboutUsQuoteLine3",
                table: "Content",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AboutUsQuoteLine4",
                table: "Content",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CalendarMainHeader",
                table: "Content",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CommitteesMainHeader",
                table: "Content",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactUsCity",
                table: "Content",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactUsHeader",
                table: "Content",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactUsState",
                table: "Content",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactUsZipCode",
                table: "Content",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeLine4",
                table: "Content",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeMainHeader",
                table: "Content",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MembershipMainHeader",
                table: "Content",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OfficersMainHeader",
                table: "Content",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoMainHeader",
                table: "Content",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ScholarshipMainHeader",
                table: "Content",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "CommitteeMembers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated",
                table: "CommitteeMembers",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<Guid>(
                name: "CommitteeId",
                table: "CommitteeMembers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Committee",
                table: "CommitteeMembers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "AlbumId",
                table: "Albums",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Photos",
                table: "Photos",
                column: "PhotoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Officers",
                table: "Officers",
                column: "OfficerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Members",
                table: "Members",
                column: "MemberId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "Events",
                column: "EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Content",
                table: "Content",
                column: "ContentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommitteeMembers",
                table: "CommitteeMembers",
                column: "CommitteeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Albums",
                table: "Albums",
                column: "AlbumId");

            migrationBuilder.InsertData(
                table: "CommitteeMembers",
                columns: new[] { "CommitteeId", "Active", "Committee", "Created", "CreatedBy", "FirstName", "LastName", "MemberId", "Updated", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("f45f65f6-7772-47a7-9225-e2213542a14a"), true, 2, new DateTime(2020, 10, 11, 9, 53, 19, 232, DateTimeKind.Utc).AddTicks(7553), null, "Don", "Paul", null, null, null },
                    { new Guid("d69d2d0a-ec85-48fc-a67b-d826704a636f"), true, 3, new DateTime(2020, 10, 11, 9, 53, 19, 232, DateTimeKind.Utc).AddTicks(8572), null, "Tammy", "Richardson", null, null, null },
                    { new Guid("1e4d2409-ae06-4e8d-a521-d8b6c3a74e42"), true, 4, new DateTime(2020, 10, 11, 9, 53, 19, 232, DateTimeKind.Utc).AddTicks(8601), null, "Eva", "Edwards", null, null, null },
                    { new Guid("5b8495cc-b365-43ca-8240-cf87b34fdfea"), true, 1, new DateTime(2020, 10, 11, 9, 53, 19, 232, DateTimeKind.Utc).AddTicks(8754), null, "Marcus", "Dabney", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Content",
                columns: new[] { "ContentId", "AboutUsHeader", "AboutUsQuoteLine1", "AboutUsQuoteLine2", "AboutUsQuoteLine3", "AboutUsQuoteLine4", "AboutUsSubHeader", "CalendarMainHeader", "CalendarSubHeader", "CommitteesMainHeader", "CommitteesSubHeader", "ContactUsAddressName1", "ContactUsAddressName2", "ContactUsCity", "ContactUsHeader", "ContactUsState", "ContactUsStreetAddress", "ContactUsSubHeader", "ContactUsZipCode", "Created", "HomeLine1", "HomeLine2", "HomeLine3", "HomeLine4", "HomeMainHeader", "HomeSubHeader", "LastUpdatedUserId", "MemberShipName1", "MemberShipName2", "Membership1Amount1", "Membership1Amount2", "Membership1Amount3", "Membership2Amount1", "Membership2Amount2", "Membership2Amount3", "MembershipMainHeader", "MembershipSubHeader", "OfficersMainHeader", "OfficersSubHeader", "PhotoMainHeader", "PhotoSubHeader", "ScholarshipLine1", "ScholarshipMainHeader", "ScholarshipSubHeader", "Updated" },
                values: new object[] { new Guid("7ca883ab-39dc-4471-858a-ccfd43a77127"), "About Us", "The purpose of the chapter is : (1) To maintain a working relationship with the University;", "(2) To promote interest in the University among prospective students;", "(3) To promote fellowship among the alumni; and", "(4) To promote and maintain a positive image of the University in the community.", "Mission", "Calendar", "Keeping you updated with Events, Meetings, and more from GUNAA Puget Sound", "Committees", "Committee Chairs for Grambling University National Alumni Association of Puget Sound", "Grambling University National Alumni Association", "Puget Sound Chapter", "Seattle", "Contact Us", "Washington", "Post Office Box 18321", null, "98118", new DateTime(2020, 10, 11, 9, 53, 19, 235, DateTimeKind.Utc).AddTicks(8807), "We would like to welcome all alumni and supporters living in and visiting the Seattle area. We welcome your support as we continue our mission of recruiting students to our alma mater. ", "If you are in the Puget Sound area and interested in attending Grambling State University or currently attending Grambling State University, please reach out to us for information on the scholarships we provide.", "Go Tigers!!!", "Grambling, Where Everybody is Somebody", "Welcome", "Welcome to the Home Site of the Puget Sound Chapter Of the Grambling University National Alumni Association", 0, "GUNAA", "GUNAA Puget Sound Chapter", "National Dues (Yearly) $70", "Life Membership (Single) $500", "Life Membership (Couples) $750", "Local Dues Regular Members $40", "Local Dues Associate Members (family/friends) $35", null, "Membership", "Alumni Association Dues Structure", "Officers", "Leaders of Grambling University National Alumni Association of Puget Sound", "Photos", "Captured Moments from the GUNAA Events, Meetings, Fundraisers, and more", null, "Scholarship", "Scholarship Program", null });

            migrationBuilder.InsertData(
                table: "Officers",
                columns: new[] { "OfficerId", "Active", "Created", "CreatedBy", "FirstName", "LastName", "MemberId", "Role", "Updated", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("8e65ed99-a9d1-4022-a4f5-767562665fa3"), true, new DateTime(2020, 10, 11, 9, 53, 19, 230, DateTimeKind.Utc).AddTicks(1025), null, "Charlene", "Francisco", null, 1, null, null },
                    { new Guid("0d48e946-776a-42a2-bea6-4446e505a766"), true, new DateTime(2020, 10, 11, 9, 53, 19, 230, DateTimeKind.Utc).AddTicks(2201), null, "Jeanie", "Nelson", null, 3, null, null },
                    { new Guid("83dcbf6c-38e0-4728-b0eb-95d391222a5b"), true, new DateTime(2020, 10, 11, 9, 53, 19, 230, DateTimeKind.Utc).AddTicks(2237), null, "Eva", "Edwards", null, 4, null, null },
                    { new Guid("5bbba11e-6520-4bba-9587-19d6a0359e9a"), true, new DateTime(2020, 10, 11, 9, 53, 19, 230, DateTimeKind.Utc).AddTicks(2263), null, "Beverly", "Hopkins", null, 2, null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Photos",
                table: "Photos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Officers",
                table: "Officers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Members",
                table: "Members");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Content",
                table: "Content");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommitteeMembers",
                table: "CommitteeMembers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Albums",
                table: "Albums");

            migrationBuilder.DeleteData(
                table: "CommitteeMembers",
                keyColumn: "CommitteeId",
                keyValue: new Guid("1e4d2409-ae06-4e8d-a521-d8b6c3a74e42"));

            migrationBuilder.DeleteData(
                table: "CommitteeMembers",
                keyColumn: "CommitteeId",
                keyValue: new Guid("5b8495cc-b365-43ca-8240-cf87b34fdfea"));

            migrationBuilder.DeleteData(
                table: "CommitteeMembers",
                keyColumn: "CommitteeId",
                keyValue: new Guid("d69d2d0a-ec85-48fc-a67b-d826704a636f"));

            migrationBuilder.DeleteData(
                table: "CommitteeMembers",
                keyColumn: "CommitteeId",
                keyValue: new Guid("f45f65f6-7772-47a7-9225-e2213542a14a"));

            migrationBuilder.DeleteData(
                table: "Content",
                keyColumn: "ContentId",
                keyValue: new Guid("7ca883ab-39dc-4471-858a-ccfd43a77127"));

            migrationBuilder.DeleteData(
                table: "Officers",
                keyColumn: "OfficerId",
                keyValue: new Guid("0d48e946-776a-42a2-bea6-4446e505a766"));

            migrationBuilder.DeleteData(
                table: "Officers",
                keyColumn: "OfficerId",
                keyValue: new Guid("5bbba11e-6520-4bba-9587-19d6a0359e9a"));

            migrationBuilder.DeleteData(
                table: "Officers",
                keyColumn: "OfficerId",
                keyValue: new Guid("83dcbf6c-38e0-4728-b0eb-95d391222a5b"));

            migrationBuilder.DeleteData(
                table: "Officers",
                keyColumn: "OfficerId",
                keyValue: new Guid("8e65ed99-a9d1-4022-a4f5-767562665fa3"));

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "OfficerId",
                table: "Officers");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ContentId",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "AboutUsHeader",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "AboutUsQuoteLine1",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "AboutUsQuoteLine2",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "AboutUsQuoteLine3",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "AboutUsQuoteLine4",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "CalendarMainHeader",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "CommitteesMainHeader",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "ContactUsCity",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "ContactUsHeader",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "ContactUsState",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "ContactUsZipCode",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "HomeLine4",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "HomeMainHeader",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "MembershipMainHeader",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "OfficersMainHeader",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "PhotoMainHeader",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "ScholarshipMainHeader",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "CommitteeId",
                table: "CommitteeMembers");

            migrationBuilder.DropColumn(
                name: "Committee",
                table: "CommitteeMembers");

            migrationBuilder.DropColumn(
                name: "AlbumId",
                table: "Albums");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Photos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValueSql: "('')",
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValueSql: "('')");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Photos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Officers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Members",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated",
                table: "Events",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Events",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "EndTime",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StartTime",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Content",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "AboutUsQuote",
                table: "Content",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactUsCityStateZip",
                table: "Content",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ScholarshipDocumentName1",
                table: "Content",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ScholarshipDocumentName2",
                table: "Content",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ScholarshipDocumentName3",
                table: "Content",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "View",
                table: "Content",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "CommitteeMembers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated",
                table: "CommitteeMembers",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CommitteeMembers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Name",
                table: "CommitteeMembers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Albums",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Photos",
                table: "Photos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Officers",
                table: "Officers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Members",
                table: "Members",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "Events",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Content",
                table: "Content",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommitteeMembers",
                table: "CommitteeMembers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Albums",
                table: "Albums",
                column: "Id");
        }
    }
}
