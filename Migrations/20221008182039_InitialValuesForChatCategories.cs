using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TelegramClone.Migrations
{
    public partial class InitialValuesForChatCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("34d02f91-a4e7-43ba-b739-9fd058c6b278"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("86ec46b1-c661-445e-b9ef-44bdc8aef0c4"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("a8cf67ba-95ee-4c14-a331-7537f06f0f41"));

            migrationBuilder.InsertData(
                table: "ChatCategories",
                columns: new[] { "ChatCategoryId", "ChatCategoryName" },
                values: new object[,]
                {
                    { new Guid("94852662-31b0-4c94-bca6-30156c242aee"), "private" },
                    { new Guid("30ff35ed-33f4-4f20-a6ee-853f762b1aaa"), "group" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { new Guid("776a1980-4913-45cc-a842-de4b6ca1c7cf"), "admin" },
                    { new Guid("25008ce6-7fbc-4cb8-b8de-d0198f649e10"), "user" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ConnectionStatus", "Password", "RoleId", "UserName", "UserPhoto" },
                values: new object[] { new Guid("7ef88fbc-f2a4-4e79-a846-8542e2905ce9"), "online", "123456", new Guid("776a1980-4913-45cc-a842-de4b6ca1c7cf"), "admin", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChatCategories",
                keyColumn: "ChatCategoryId",
                keyValue: new Guid("30ff35ed-33f4-4f20-a6ee-853f762b1aaa"));

            migrationBuilder.DeleteData(
                table: "ChatCategories",
                keyColumn: "ChatCategoryId",
                keyValue: new Guid("94852662-31b0-4c94-bca6-30156c242aee"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("25008ce6-7fbc-4cb8-b8de-d0198f649e10"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("7ef88fbc-f2a4-4e79-a846-8542e2905ce9"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("776a1980-4913-45cc-a842-de4b6ca1c7cf"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { new Guid("a8cf67ba-95ee-4c14-a331-7537f06f0f41"), "admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { new Guid("34d02f91-a4e7-43ba-b739-9fd058c6b278"), "user" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ConnectionStatus", "Password", "RoleId", "UserName", "UserPhoto" },
                values: new object[] { new Guid("86ec46b1-c661-445e-b9ef-44bdc8aef0c4"), "online", "123456", new Guid("a8cf67ba-95ee-4c14-a331-7537f06f0f41"), "admin", null });
        }
    }
}
