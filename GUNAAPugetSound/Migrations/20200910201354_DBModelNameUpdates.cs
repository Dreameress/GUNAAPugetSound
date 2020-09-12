//using Microsoft.EntityFrameworkCore.Migrations;

//namespace GUNAAPugetSound.Migrations
//{
//    public partial class DBModelNameUpdates : Migration
//    {
//        protected override void Up(MigrationBuilder migrationBuilder)
//        {
//            //migrationBuilder.DropForeignKey(
//            //    name: "FK_UserRoles_RoleMasters_RoleId",
//            //    table: "UserRoles");

//            //migrationBuilder.DropForeignKey(
//            //    name: "FK_UserRoles_UserMasters_UserId",
//            //    table: "UserRoles");

//            //migrationBuilder.DropPrimaryKey(
//            //    name: "PK_UserMasters",
//            //    table: "UserMasters");

//            //migrationBuilder.DropPrimaryKey(
//            //    name: "PK_RoleMasters",
//            //    table: "RoleMasters");

//            //migrationBuilder.DropPrimaryKey(
//            //    name: "PK_RefreshTokens",
//            //    table: "RefreshTokens");

//            migrationBuilder.RenameTable(
//                name: "UserMasters",
//                newName: "UsersMaster");

//            migrationBuilder.RenameTable(
//                name: "RoleMasters",
//                newName: "RolesMaster");

//            migrationBuilder.RenameTable(
//                name: "RefreshTokens",
//                newName: "RefreshToken");

//            migrationBuilder.RenameIndex(
//                name: "IX_RefreshTokens_UserId",
//                table: "RefreshToken",
//                newName: "IX_RefreshToken_UserId");

//            migrationBuilder.AddPrimaryKey(
//                name: "PK_UsersMaster",
//                table: "UsersMaster",
//                column: "UserId");

//            //migrationBuilder.AddPrimaryKey(
//            //    name: "PK_RolesMaster",
//            //    table: "RolesMaster",
//            //    column: "RoleId");

//            //migrationBuilder.AddPrimaryKey(
//            //    name: "PK_RefreshToken",
//            //    table: "RefreshToken",
//            //    column: "RefreshTokenId");

//            //migrationBuilder.AddForeignKey(
//            //    name: "FK_UserRoles_RolesMaster_RoleId",
//            //    table: "UserRoles",
//            //    column: "RoleId",
//            //    principalTable: "RolesMaster",
//            //    principalColumn: "RoleId",
//            //    onDelete: ReferentialAction.Cascade);

//            //migrationBuilder.AddForeignKey(
//            //    name: "FK_UserRoles_UsersMaster_UserId",
//            //    table: "UserRoles",
//            //    column: "UserId",
//            //    principalTable: "UsersMaster",
//            //    principalColumn: "UserId",
//            //    onDelete: ReferentialAction.Cascade);
//        }

//        protected override void Down(MigrationBuilder migrationBuilder)
//        {
//            //migrationBuilder.DropForeignKey(
//            //    name: "FK_UserRoles_RolesMaster_RoleId",
//            //    table: "UserRoles");

//            //migrationBuilder.DropForeignKey(
//            //    name: "FK_UserRoles_UsersMaster_UserId",
//            //    table: "UserRoles");

//            //migrationBuilder.DropPrimaryKey(
//            //    name: "PK_UsersMaster",
//            //    table: "UsersMaster");

//            //migrationBuilder.DropPrimaryKey(
//            //    name: "PK_RolesMaster",
//            //    table: "RolesMaster");

//            //migrationBuilder.DropPrimaryKey(
//            //    name: "PK_RefreshToken",
//            //    table: "RefreshToken");

//            migrationBuilder.RenameTable(
//                name: "UsersMaster",
//                newName: "UserMasters");

//            migrationBuilder.RenameTable(
//                name: "RolesMaster",
//                newName: "RoleMasters");

//            migrationBuilder.RenameTable(
//                name: "RefreshToken",
//                newName: "RefreshTokens");

//            //migrationBuilder.RenameIndex(
//            //    name: "IX_RefreshToken_UserId",
//            //    table: "RefreshTokens",
//            //    newName: "IX_RefreshTokens_UserId");

//            //migrationBuilder.AddPrimaryKey(
//            //    name: "PK_UsersMaster",
//            //    table: "UserMasters",
//            //    column: "UserId");

//            //migrationBuilder.AddPrimaryKey(
//            //    name: "PK_RolesMaster",
//            //    table: "RoleMasters",
//            //    column: "RoleId");

//            //migrationBuilder.AddPrimaryKey(
//            //    name: "PK_RefreshTokens",
//            //    table: "RefreshToken",
//            //    column: "RefreshTokenId");

//            //migrationBuilder.AddForeignKey(
//            //    name: "FK_UserRoles_RoleMasters_RoleId",
//            //    table: "UserRoles",
//            //    column: "RoleId",
//            //    principalTable: "RoleMasters",
//            //    principalColumn: "RoleId",
//            //    onDelete: ReferentialAction.Cascade);

//            //migrationBuilder.AddForeignKey(
//            //    name: "FK_UserRoles_UserMasters_UserId",
//            //    table: "UserRoles",
//            //    column: "UserId",
//            //    principalTable: "UserMasters",
//            //    principalColumn: "UserId",
//            //    onDelete: ReferentialAction.Cascade);
//        }
//    }
//}
