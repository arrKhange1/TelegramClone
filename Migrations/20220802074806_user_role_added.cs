using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TelegramClone.Migrations
{
    public partial class user_role_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("e12b3dda-d688-43ee-a04b-28d064d4aab4"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("a2a23111-bc87-44de-8ca8-e13cface8c45"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { new Guid("a2a23111-bc87-44de-8ca8-e13cface8c45"), "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("e12b3dda-d688-43ee-a04b-28d064d4aab4"), "AQAAAAEAACcQAAAAEGH6iBe7yNyxLRDFBPupFqNTXl7aF++8zubImX84SBZc9kkWBJdfbVsNsTFUbJinjA==", new Guid("a2a23111-bc87-44de-8ca8-e13cface8c45"), "admin" });
        }
    }
}
