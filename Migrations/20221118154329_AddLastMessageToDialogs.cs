using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TelegramClone.Migrations
{
    public partial class AddLastMessageToDialogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChatCategories",
                keyColumn: "ChatCategoryId",
                keyValue: new Guid("2643769a-cc21-4c3c-8053-8a67f482a1b8"));

            migrationBuilder.DeleteData(
                table: "ChatCategories",
                keyColumn: "ChatCategoryId",
                keyValue: new Guid("c6fcf6a2-a14d-40c9-b874-63a0745ccf74"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("f97e2960-5769-4e2b-a38e-f30d7d1409a1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("ddef73bf-2862-44d1-9291-92db3be0d435"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("1a00e840-34d4-4cc5-b910-b094ff6e70e3"));

            migrationBuilder.AddColumn<Guid>(
                name: "LastMessageId",
                table: "Dialogs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "ChatCategories",
                columns: new[] { "ChatCategoryId", "ChatCategoryName" },
                values: new object[,]
                {
                    { new Guid("6c2f9a75-63ec-4e08-9e2a-a3245d74ddad"), "private" },
                    { new Guid("855b75ac-5f4c-4823-a482-5adac692aa69"), "group" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { new Guid("acc8f54d-36e0-4add-99d9-5e0db562f7a3"), "admin" },
                    { new Guid("9f145069-842e-4480-92ce-f1c4c3fcab35"), "user" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ConnectionStatus", "Password", "RoleId", "UserName", "UserPhoto" },
                values: new object[] { new Guid("6800829d-32f9-497d-8574-335f296c6568"), "online", "123456", new Guid("acc8f54d-36e0-4add-99d9-5e0db562f7a3"), "admin", null });

            migrationBuilder.CreateIndex(
                name: "IX_Dialogs_LastMessageId",
                table: "Dialogs",
                column: "LastMessageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Dialogs_DialogMessages_LastMessageId",
                table: "Dialogs",
                column: "LastMessageId",
                principalTable: "DialogMessages",
                principalColumn: "MessageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dialogs_DialogMessages_LastMessageId",
                table: "Dialogs");

            migrationBuilder.DropIndex(
                name: "IX_Dialogs_LastMessageId",
                table: "Dialogs");

            migrationBuilder.DeleteData(
                table: "ChatCategories",
                keyColumn: "ChatCategoryId",
                keyValue: new Guid("6c2f9a75-63ec-4e08-9e2a-a3245d74ddad"));

            migrationBuilder.DeleteData(
                table: "ChatCategories",
                keyColumn: "ChatCategoryId",
                keyValue: new Guid("855b75ac-5f4c-4823-a482-5adac692aa69"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("9f145069-842e-4480-92ce-f1c4c3fcab35"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("6800829d-32f9-497d-8574-335f296c6568"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("acc8f54d-36e0-4add-99d9-5e0db562f7a3"));

            migrationBuilder.DropColumn(
                name: "LastMessageId",
                table: "Dialogs");

            migrationBuilder.InsertData(
                table: "ChatCategories",
                columns: new[] { "ChatCategoryId", "ChatCategoryName" },
                values: new object[,]
                {
                    { new Guid("c6fcf6a2-a14d-40c9-b874-63a0745ccf74"), "private" },
                    { new Guid("2643769a-cc21-4c3c-8053-8a67f482a1b8"), "group" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { new Guid("1a00e840-34d4-4cc5-b910-b094ff6e70e3"), "admin" },
                    { new Guid("f97e2960-5769-4e2b-a38e-f30d7d1409a1"), "user" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ConnectionStatus", "Password", "RoleId", "UserName", "UserPhoto" },
                values: new object[] { new Guid("ddef73bf-2862-44d1-9291-92db3be0d435"), "online", "123456", new Guid("1a00e840-34d4-4cc5-b910-b094ff6e70e3"), "admin", null });
        }
    }
}
