using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TelegramClone.Migrations
{
    public partial class add_refresh_tokens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("17b2cf85-18aa-4d70-be42-c0c562387e6d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("808f4cba-0242-424e-9159-fdc1f5fcc304"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("d5756869-56b0-4e6f-8082-8094de67dd2f"));

            migrationBuilder.CreateTable(
                name: "UserRefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { new Guid("d5756869-56b0-4e6f-8082-8094de67dd2f"), "admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { new Guid("17b2cf85-18aa-4d70-be42-c0c562387e6d"), "user" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("808f4cba-0242-424e-9159-fdc1f5fcc304"), "123456", new Guid("d5756869-56b0-4e6f-8082-8094de67dd2f"), "admin" });
        }
    }
}
