using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TelegramClone.Migrations
{
    public partial class add_exp_date : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { new Guid("ca96e9a8-fc22-4b03-a531-4d01815e562b"), "admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { new Guid("2a1f3701-5aea-4670-8cc9-cebe6a7d04b1"), "user" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("a73d9867-80a8-4e2e-84d8-ef49eb556b8a"), "123456", new Guid("ca96e9a8-fc22-4b03-a531-4d01815e562b"), "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("2a1f3701-5aea-4670-8cc9-cebe6a7d04b1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("a73d9867-80a8-4e2e-84d8-ef49eb556b8a"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("ca96e9a8-fc22-4b03-a531-4d01815e562b"));

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
    }
}
