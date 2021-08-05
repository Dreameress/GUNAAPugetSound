using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class Accounts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CommitteeMembers",
                keyColumn: "CommitteeId",
                keyValue: new Guid("16f552f0-e0f7-45a2-9680-ac5f41964ba8"));

            migrationBuilder.DeleteData(
                table: "CommitteeMembers",
                keyColumn: "CommitteeId",
                keyValue: new Guid("865bd307-0fe3-4db7-b88c-3627b1ada2ac"));

            migrationBuilder.DeleteData(
                table: "CommitteeMembers",
                keyColumn: "CommitteeId",
                keyValue: new Guid("b6dafd21-7cfc-4d54-ab5b-52247ce67b97"));

            migrationBuilder.DeleteData(
                table: "CommitteeMembers",
                keyColumn: "CommitteeId",
                keyValue: new Guid("ceb8924c-9a60-481f-a08d-1540ff8662c6"));

            migrationBuilder.DeleteData(
                table: "Content",
                keyColumn: "ContentId",
                keyValue: new Guid("2ef51746-56bc-4b13-8cf9-7325767e434c"));

            migrationBuilder.DeleteData(
                table: "Officers",
                keyColumn: "OfficerId",
                keyValue: new Guid("25ff8f70-af5a-45b1-80f3-4d705be80e2e"));

            migrationBuilder.DeleteData(
                table: "Officers",
                keyColumn: "OfficerId",
                keyValue: new Guid("3aaa06e9-b5bf-46f9-91e1-018fdbc0d407"));

            migrationBuilder.DeleteData(
                table: "Officers",
                keyColumn: "OfficerId",
                keyValue: new Guid("59db7597-7941-4b1e-8398-4a62f67eac46"));

            migrationBuilder.DeleteData(
                table: "Officers",
                keyColumn: "OfficerId",
                keyValue: new Guid("8b7ba2e1-ddc6-4aeb-9de6-2eb2db5922d3"));

            migrationBuilder.InsertData(
                table: "CommitteeMembers",
                columns: new[] { "CommitteeId", "Active", "Committee", "Created", "CreatedBy", "FirstName", "LastName", "MemberId", "Updated", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("867ab617-a751-47a5-a91f-2548b13f279a"), true, 2, new DateTime(2021, 7, 11, 21, 37, 16, 562, DateTimeKind.Utc).AddTicks(9204), null, "Don", "Paul", null, null, null },
                    { new Guid("13d30231-7488-4297-a5c6-5cba7a756ea7"), true, 3, new DateTime(2021, 7, 11, 21, 37, 16, 562, DateTimeKind.Utc).AddTicks(9856), null, "Tammy", "Richardson", null, null, null },
                    { new Guid("3165ab3c-7855-4380-bb1a-f42223f18e12"), true, 4, new DateTime(2021, 7, 11, 21, 37, 16, 562, DateTimeKind.Utc).AddTicks(9888), null, "Eva", "Edwards", null, null, null },
                    { new Guid("16a98d3d-dd76-4e62-9daa-9bbd31a12bd3"), true, 1, new DateTime(2021, 7, 11, 21, 37, 16, 562, DateTimeKind.Utc).AddTicks(9893), null, "Marcus", "Dabney", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Content",
                columns: new[] { "ContentId", "AboutUsHeader", "AboutUsQuoteLine1", "AboutUsQuoteLine2", "AboutUsQuoteLine3", "AboutUsQuoteLine4", "AboutUsSubHeader", "CalendarMainHeader", "CalendarSubHeader", "CommitteesMainHeader", "CommitteesSubHeader", "ContactUsAddressName1", "ContactUsAddressName2", "ContactUsCity", "ContactUsHeader", "ContactUsState", "ContactUsStreetAddress", "ContactUsSubHeader", "ContactUsZipCode", "Created", "HomeLine1", "HomeLine2", "HomeLine3", "HomeLine4", "HomeMainHeader", "HomeSubHeader", "LastUpdatedUserId", "MemberShipName1", "MemberShipName2", "Membership1Amount1", "Membership1Amount2", "Membership1Amount3", "Membership2Amount1", "Membership2Amount2", "Membership2Amount3", "MembershipMainHeader", "MembershipSubHeader", "OfficersMainHeader", "OfficersSubHeader", "PhotoMainHeader", "PhotoSubHeader", "ScholarshipLine1", "ScholarshipMainHeader", "ScholarshipSubHeader", "Updated" },
                values: new object[] { new Guid("45fb8af8-019e-4063-ad8b-fd80dff7b6de"), "About Us", "The purpose of the chapter is : (1) To maintain a working relationship with the University;", "(2) To promote interest in the University among prospective students;", "(3) To promote fellowship among the alumni; and", "(4) To promote and maintain a positive image of the University in the community.", "Mission", "Calendar", "Keeping you updated with Events, Meetings, and more from GUNAA Puget Sound", "Committees", "Committee Chairs for Grambling University National Alumni Association of Puget Sound", "Grambling University National Alumni Association", "Puget Sound Chapter", "Seattle", "Contact Us", "Washington", "Post Office Box 18321", null, "98118", new DateTime(2021, 7, 11, 21, 37, 16, 564, DateTimeKind.Utc).AddTicks(1025), "We would like to welcome all alumni and supporters living in and visiting the Seattle area. We welcome your support as we continue our mission of recruiting students to our alma mater. ", "If you are in the Puget Sound area and interested in attending Grambling State University or currently attending Grambling State University, please reach out to us for information on the scholarships we provide.", "Go Tigers!!!", "Grambling, Where Everybody is Somebody", "Welcome", "Welcome to the Home Site of the Puget Sound Chapter Of the Grambling University National Alumni Association", 0, "GUNAA", "GUNAA Puget Sound Chapter", "National Dues (Yearly) $70", "Life Membership (Single) $500", "Life Membership (Couples) $750", "Local Dues Regular Members $40", "Local Dues Associate Members (family/friends) $35", null, "Membership", "Alumni Association Dues Structure", "Officers", "Leaders of Grambling University National Alumni Association of Puget Sound", "Photos", "Captured Moments from the GUNAA Events, Meetings, Fundraisers, and more", null, "Scholarship", "Scholarship Program", null });

            migrationBuilder.InsertData(
                table: "Officers",
                columns: new[] { "OfficerId", "Active", "Created", "CreatedBy", "FirstName", "LastName", "MemberId", "Role", "Updated", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("02dea90d-1134-476d-8589-b0943e350f6d"), true, new DateTime(2021, 7, 11, 21, 37, 16, 561, DateTimeKind.Utc).AddTicks(3864), null, "Charlene", "Francisco", null, 1, null, null },
                    { new Guid("ae8c0841-0eaa-4f50-a501-9078f0a44dfc"), true, new DateTime(2021, 7, 11, 21, 37, 16, 561, DateTimeKind.Utc).AddTicks(4301), null, "Jeanie", "Nelson", null, 3, null, null },
                    { new Guid("501ec580-0870-413b-bb33-c098fcaf1433"), true, new DateTime(2021, 7, 11, 21, 37, 16, 561, DateTimeKind.Utc).AddTicks(4318), null, "Eva", "Edwards", null, 4, null, null },
                    { new Guid("131b7bb6-0bc0-4e94-a4a3-018cb8eb59fd"), true, new DateTime(2021, 7, 11, 21, 37, 16, 561, DateTimeKind.Utc).AddTicks(4321), null, "Beverly", "Hopkins", null, 2, null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CommitteeMembers",
                keyColumn: "CommitteeId",
                keyValue: new Guid("13d30231-7488-4297-a5c6-5cba7a756ea7"));

            migrationBuilder.DeleteData(
                table: "CommitteeMembers",
                keyColumn: "CommitteeId",
                keyValue: new Guid("16a98d3d-dd76-4e62-9daa-9bbd31a12bd3"));

            migrationBuilder.DeleteData(
                table: "CommitteeMembers",
                keyColumn: "CommitteeId",
                keyValue: new Guid("3165ab3c-7855-4380-bb1a-f42223f18e12"));

            migrationBuilder.DeleteData(
                table: "CommitteeMembers",
                keyColumn: "CommitteeId",
                keyValue: new Guid("867ab617-a751-47a5-a91f-2548b13f279a"));

            migrationBuilder.DeleteData(
                table: "Content",
                keyColumn: "ContentId",
                keyValue: new Guid("45fb8af8-019e-4063-ad8b-fd80dff7b6de"));

            migrationBuilder.DeleteData(
                table: "Officers",
                keyColumn: "OfficerId",
                keyValue: new Guid("02dea90d-1134-476d-8589-b0943e350f6d"));

            migrationBuilder.DeleteData(
                table: "Officers",
                keyColumn: "OfficerId",
                keyValue: new Guid("131b7bb6-0bc0-4e94-a4a3-018cb8eb59fd"));

            migrationBuilder.DeleteData(
                table: "Officers",
                keyColumn: "OfficerId",
                keyValue: new Guid("501ec580-0870-413b-bb33-c098fcaf1433"));

            migrationBuilder.DeleteData(
                table: "Officers",
                keyColumn: "OfficerId",
                keyValue: new Guid("ae8c0841-0eaa-4f50-a501-9078f0a44dfc"));

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
        }
    }
}
