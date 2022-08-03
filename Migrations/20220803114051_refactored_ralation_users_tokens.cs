using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TelegramClone.Migrations
{
    public partial class refactored_ralation_users_tokens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRefreshTokens");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("887d1112-fc89-49cd-a7f9-9ec747e8bf17"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("f4590a0f-04af-4275-b3ad-2f51b38ec5fd"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("e49e1570-4c96-4471-8cc8-943680d10ef2"));

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { new Guid("6222d624-675e-4af2-8086-c65c4b539656"), "admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { new Guid("85848541-1e30-4697-9ce1-5456ddde9718"), "user" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("27f0df77-b564-4677-910f-d7b89849539c"), "123456", new Guid("6222d624-675e-4af2-8086-c65c4b539656"), "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("85848541-1e30-4697-9ce1-5456ddde9718"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("27f0df77-b564-4677-910f-d7b89849539c"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("6222d624-675e-4af2-8086-c65c4b539656"));

            migrationBuilder.CreateTable(
                name: "UserRefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { new Guid("e49e1570-4c96-4471-8cc8-943680d10ef2"), "admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { new Guid("887d1112-fc89-49cd-a7f9-9ec747e8bf17"), "user" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("f4590a0f-04af-4275-b3ad-2f51b38ec5fd"), "123456", new Guid("e49e1570-4c96-4471-8cc8-943680d10ef2"), "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_UserRefreshTokens_UserId",
                table: "UserRefreshTokens",
                column: "UserId",
                unique: true);
        }
    }
}
