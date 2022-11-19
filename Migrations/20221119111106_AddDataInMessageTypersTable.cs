using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TelegramClone.Migrations
{
    public partial class AddDataInMessageTypersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChatCategories",
                keyColumn: "ChatCategoryId",
                keyValue: new Guid("3073fca1-10c3-441a-9c8e-926cc8d9ee45"));

            migrationBuilder.DeleteData(
                table: "ChatCategories",
                keyColumn: "ChatCategoryId",
                keyValue: new Guid("a8d5f02c-680f-497f-ac61-7d6ed784124d"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("98790fdc-8f37-4f14-b8e3-21408cbcec8b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("1bbec9a7-a5a0-4953-8d17-c226e5e1c640"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("7da1dd1b-fa9c-4b84-ae45-c02e31777f56"));

            migrationBuilder.InsertData(
                table: "ChatCategories",
                columns: new[] { "ChatCategoryId", "ChatCategoryName" },
                values: new object[,]
                {
                    { new Guid("4e28dfe7-4020-4d93-9ea8-d3cae0cffc75"), "private" },
                    { new Guid("1c74c3cb-2120-40a2-81da-2f322085db90"), "group" }
                });

            migrationBuilder.InsertData(
                table: "MessageTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { new Guid("786e20ae-bc6b-472a-bd15-14beee7121ae"), "message" },
                    { new Guid("2c83753e-c3be-4a9b-8b6f-07db48bdc951"), "notification" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { new Guid("d5943e1f-61f7-4ed5-b0c8-55bb1f374fd5"), "admin" },
                    { new Guid("72f2fc42-c65c-43ac-86dd-8bdd3ff0e1df"), "user" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ConnectionStatus", "Password", "RoleId", "UserName", "UserPhoto" },
                values: new object[] { new Guid("d089d04a-ea2f-443f-94dc-544781e97a09"), "online", "123456", new Guid("d5943e1f-61f7-4ed5-b0c8-55bb1f374fd5"), "admin", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChatCategories",
                keyColumn: "ChatCategoryId",
                keyValue: new Guid("1c74c3cb-2120-40a2-81da-2f322085db90"));

            migrationBuilder.DeleteData(
                table: "ChatCategories",
                keyColumn: "ChatCategoryId",
                keyValue: new Guid("4e28dfe7-4020-4d93-9ea8-d3cae0cffc75"));

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: new Guid("2c83753e-c3be-4a9b-8b6f-07db48bdc951"));

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: new Guid("786e20ae-bc6b-472a-bd15-14beee7121ae"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("72f2fc42-c65c-43ac-86dd-8bdd3ff0e1df"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("d089d04a-ea2f-443f-94dc-544781e97a09"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("d5943e1f-61f7-4ed5-b0c8-55bb1f374fd5"));

            migrationBuilder.InsertData(
                table: "ChatCategories",
                columns: new[] { "ChatCategoryId", "ChatCategoryName" },
                values: new object[,]
                {
                    { new Guid("3073fca1-10c3-441a-9c8e-926cc8d9ee45"), "private" },
                    { new Guid("a8d5f02c-680f-497f-ac61-7d6ed784124d"), "group" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { new Guid("7da1dd1b-fa9c-4b84-ae45-c02e31777f56"), "admin" },
                    { new Guid("98790fdc-8f37-4f14-b8e3-21408cbcec8b"), "user" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ConnectionStatus", "Password", "RoleId", "UserName", "UserPhoto" },
                values: new object[] { new Guid("1bbec9a7-a5a0-4953-8d17-c226e5e1c640"), "online", "123456", new Guid("7da1dd1b-fa9c-4b84-ae45-c02e31777f56"), "admin", null });
        }
    }
}
