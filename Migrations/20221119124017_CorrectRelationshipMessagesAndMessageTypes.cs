using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TelegramClone.Migrations
{
    public partial class CorrectRelationshipMessagesAndMessageTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Messages_MessageTypeId",
                table: "Messages");

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

            migrationBuilder.CreateIndex(
                name: "IX_Messages_MessageTypeId",
                table: "Messages",
                column: "MessageTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Messages_MessageTypeId",
                table: "Messages");

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

            migrationBuilder.CreateIndex(
                name: "IX_Messages_MessageTypeId",
                table: "Messages",
                column: "MessageTypeId",
                unique: true);
        }
    }
}
