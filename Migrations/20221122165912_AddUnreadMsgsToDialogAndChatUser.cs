using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TelegramClone.Migrations
{
    public partial class AddUnreadMsgsToDialogAndChatUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChatCategories",
                keyColumn: "ChatCategoryId",
                keyValue: new Guid("057388a3-583e-4b3b-8034-2ad20a9ee515"));

            migrationBuilder.DeleteData(
                table: "ChatCategories",
                keyColumn: "ChatCategoryId",
                keyValue: new Guid("7496bf81-3af8-44da-9fae-0dd0a5fa3621"));

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: new Guid("07508962-aa9e-4403-b739-9650f5fffe84"));

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: new Guid("a3477a01-8bbb-4b84-9853-0569e18da5b9"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("6e0fa874-8ee2-4af3-992e-15035b8a9d38"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("442700ff-662b-4501-bd06-4db3a98691c4"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("674ca53e-1b04-4c85-8730-0816fa7ba594"));

            migrationBuilder.AddColumn<int>(
                name: "UnreadMsgsByFirst",
                table: "Dialogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnreadMsgsBySecond",
                table: "Dialogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnreadMessages",
                table: "ChatUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "ChatCategories",
                columns: new[] { "ChatCategoryId", "ChatCategoryName" },
                values: new object[,]
                {
                    { new Guid("eea228fe-05fa-4400-88bf-1b285a1eb53b"), "private" },
                    { new Guid("5ff5ca11-fccc-4e23-8f78-844110c0974d"), "group" }
                });

            migrationBuilder.InsertData(
                table: "MessageTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { new Guid("cb95efe9-852a-4e0c-a284-814ee11287a4"), "message" },
                    { new Guid("279e1f9f-3c63-4b9f-acea-bcf24159d3b7"), "notification" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { new Guid("d426c5d9-ab61-432e-a60f-fdbc5ddf14c3"), "admin" },
                    { new Guid("33a56dbc-6000-4dd7-b5b6-45d6ea513c6b"), "user" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ConnectionStatus", "Password", "RoleId", "UserName", "UserPhoto" },
                values: new object[] { new Guid("ee58a4e8-09e2-483c-8412-d7ad0da76fb4"), "online", "123456", new Guid("d426c5d9-ab61-432e-a60f-fdbc5ddf14c3"), "admin", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChatCategories",
                keyColumn: "ChatCategoryId",
                keyValue: new Guid("5ff5ca11-fccc-4e23-8f78-844110c0974d"));

            migrationBuilder.DeleteData(
                table: "ChatCategories",
                keyColumn: "ChatCategoryId",
                keyValue: new Guid("eea228fe-05fa-4400-88bf-1b285a1eb53b"));

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: new Guid("279e1f9f-3c63-4b9f-acea-bcf24159d3b7"));

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: new Guid("cb95efe9-852a-4e0c-a284-814ee11287a4"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("33a56dbc-6000-4dd7-b5b6-45d6ea513c6b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("ee58a4e8-09e2-483c-8412-d7ad0da76fb4"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("d426c5d9-ab61-432e-a60f-fdbc5ddf14c3"));

            migrationBuilder.DropColumn(
                name: "UnreadMsgsByFirst",
                table: "Dialogs");

            migrationBuilder.DropColumn(
                name: "UnreadMsgsBySecond",
                table: "Dialogs");

            migrationBuilder.DropColumn(
                name: "UnreadMessages",
                table: "ChatUsers");

            migrationBuilder.InsertData(
                table: "ChatCategories",
                columns: new[] { "ChatCategoryId", "ChatCategoryName" },
                values: new object[,]
                {
                    { new Guid("057388a3-583e-4b3b-8034-2ad20a9ee515"), "private" },
                    { new Guid("7496bf81-3af8-44da-9fae-0dd0a5fa3621"), "group" }
                });

            migrationBuilder.InsertData(
                table: "MessageTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { new Guid("07508962-aa9e-4403-b739-9650f5fffe84"), "message" },
                    { new Guid("a3477a01-8bbb-4b84-9853-0569e18da5b9"), "notification" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { new Guid("674ca53e-1b04-4c85-8730-0816fa7ba594"), "admin" },
                    { new Guid("6e0fa874-8ee2-4af3-992e-15035b8a9d38"), "user" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ConnectionStatus", "Password", "RoleId", "UserName", "UserPhoto" },
                values: new object[] { new Guid("442700ff-662b-4501-bd06-4db3a98691c4"), "online", "123456", new Guid("674ca53e-1b04-4c85-8730-0816fa7ba594"), "admin", null });
        }
    }
}
