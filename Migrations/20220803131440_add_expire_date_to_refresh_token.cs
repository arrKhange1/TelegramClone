using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TelegramClone.Migrations
{
    public partial class add_expire_date_to_refresh_token : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpireDate",
                table: "RefreshTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { new Guid("9da3d63c-c390-4aa3-a150-308c83099d90"), "admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { new Guid("2736d079-8ed0-467f-ba4c-33be8c1829cd"), "user" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("69633a13-ed0f-4dec-a6bc-6f01077816f6"), "123456", new Guid("9da3d63c-c390-4aa3-a150-308c83099d90"), "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("2736d079-8ed0-467f-ba4c-33be8c1829cd"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("69633a13-ed0f-4dec-a6bc-6f01077816f6"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("9da3d63c-c390-4aa3-a150-308c83099d90"));

            migrationBuilder.DropColumn(
                name: "ExpireDate",
                table: "RefreshTokens");

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
        }
    }
}
