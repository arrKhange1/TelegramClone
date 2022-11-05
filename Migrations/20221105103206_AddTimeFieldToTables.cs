using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TelegramClone.Migrations
{
    public partial class AddTimeFieldToTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "UserContacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "MessageTime",
                table: "Messages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "Chats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "ChatCategories",
                columns: new[] { "ChatCategoryId", "ChatCategoryName" },
                values: new object[,]
                {
                    { new Guid("1d0b7209-8071-4c92-b816-b79987c2c0d3"), "private" },
                    { new Guid("29fcd69a-dbca-4376-ab27-4ecd8599c6c8"), "group" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { new Guid("ccd0ded5-1c01-459d-90f8-9e392e0b5ca9"), "admin" },
                    { new Guid("b30a7663-938a-44d3-9d3b-75f641c15119"), "user" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ConnectionStatus", "Password", "RoleId", "UserName", "UserPhoto" },
                values: new object[] { new Guid("dc5357fb-2961-4def-8c26-0777b4f4f271"), "online", "123456", new Guid("ccd0ded5-1c01-459d-90f8-9e392e0b5ca9"), "admin", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChatCategories",
                keyColumn: "ChatCategoryId",
                keyValue: new Guid("1d0b7209-8071-4c92-b816-b79987c2c0d3"));

            migrationBuilder.DeleteData(
                table: "ChatCategories",
                keyColumn: "ChatCategoryId",
                keyValue: new Guid("29fcd69a-dbca-4376-ab27-4ecd8599c6c8"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("b30a7663-938a-44d3-9d3b-75f641c15119"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("dc5357fb-2961-4def-8c26-0777b4f4f271"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("ccd0ded5-1c01-459d-90f8-9e392e0b5ca9"));

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "UserContacts");

            migrationBuilder.DropColumn(
                name: "MessageTime",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "Chats");

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
    }
}
