using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TelegramClone.Migrations
{
    public partial class add_expireDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireDate",
                table: "RefreshTokens",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { new Guid("a4af6202-9dc9-4414-b07c-608e32dd366e"), "admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { new Guid("860fa9c5-df14-494a-91f9-f8c930f6e8f3"), "user" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("65780ee3-3075-44b0-a659-90585bee5af8"), "123456", new Guid("a4af6202-9dc9-4414-b07c-608e32dd366e"), "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("860fa9c5-df14-494a-91f9-f8c930f6e8f3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("65780ee3-3075-44b0-a659-90585bee5af8"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("a4af6202-9dc9-4414-b07c-608e32dd366e"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireDate",
                table: "RefreshTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

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
    }
}
