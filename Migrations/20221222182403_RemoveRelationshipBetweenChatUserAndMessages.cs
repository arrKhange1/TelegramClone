using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TelegramClone.Migrations
{
    public partial class RemoveRelationshipBetweenChatUserAndMessages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_ChatUsers_ChatUserId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ChatUserId",
                table: "Messages");

            migrationBuilder.DeleteData(
                table: "ChatCategories",
                keyColumn: "ChatCategoryId",
                keyValue: new Guid("6516b8a6-c0b6-4633-94e0-b3642dfd0d4f"));

            migrationBuilder.DeleteData(
                table: "ChatCategories",
                keyColumn: "ChatCategoryId",
                keyValue: new Guid("f73d711c-cd24-4ba4-b993-acfa92422f86"));

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: new Guid("6c6b204c-dbfc-4d1b-aa04-de65bb1cbc09"));

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: new Guid("c8e1d766-be99-41b7-8274-2db65763cecf"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("10af563b-e5f6-4fdf-b153-c2eee06e8ea6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("3fda4647-802a-4e72-b7d6-b23908195c00"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("da65d1c3-d06a-4c30-83da-b88d6686bb40"));

            migrationBuilder.DropColumn(
                name: "ChatUserId",
                table: "Messages");

            migrationBuilder.InsertData(
                table: "ChatCategories",
                columns: new[] { "ChatCategoryId", "ChatCategoryName" },
                values: new object[,]
                {
                    { new Guid("a9c68552-b9d7-41b2-b4f7-0b1cc0405878"), "private" },
                    { new Guid("8a726d61-3053-4fa5-a9a6-87714c18d775"), "group" }
                });

            migrationBuilder.InsertData(
                table: "MessageTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { new Guid("700774ce-ddbc-4b20-a71e-3359c800cb56"), "message" },
                    { new Guid("0cfbcc61-79a3-49b9-a471-2983015fb5be"), "notification" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { new Guid("27ae9391-c712-4f63-a2f6-4b9764e7e0e1"), "admin" },
                    { new Guid("19ca66c4-c6e7-446c-aac8-61ed2432eada"), "user" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ConnectionStatus", "Password", "RoleId", "UserName", "UserPhoto" },
                values: new object[] { new Guid("cc434f89-d58b-43ce-990c-601f4392d642"), "online", "123456", new Guid("27ae9391-c712-4f63-a2f6-4b9764e7e0e1"), "admin", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChatCategories",
                keyColumn: "ChatCategoryId",
                keyValue: new Guid("8a726d61-3053-4fa5-a9a6-87714c18d775"));

            migrationBuilder.DeleteData(
                table: "ChatCategories",
                keyColumn: "ChatCategoryId",
                keyValue: new Guid("a9c68552-b9d7-41b2-b4f7-0b1cc0405878"));

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: new Guid("0cfbcc61-79a3-49b9-a471-2983015fb5be"));

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: new Guid("700774ce-ddbc-4b20-a71e-3359c800cb56"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("19ca66c4-c6e7-446c-aac8-61ed2432eada"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("cc434f89-d58b-43ce-990c-601f4392d642"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("27ae9391-c712-4f63-a2f6-4b9764e7e0e1"));

            migrationBuilder.AddColumn<Guid>(
                name: "ChatUserId",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "ChatCategories",
                columns: new[] { "ChatCategoryId", "ChatCategoryName" },
                values: new object[,]
                {
                    { new Guid("f73d711c-cd24-4ba4-b993-acfa92422f86"), "private" },
                    { new Guid("6516b8a6-c0b6-4633-94e0-b3642dfd0d4f"), "group" }
                });

            migrationBuilder.InsertData(
                table: "MessageTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { new Guid("c8e1d766-be99-41b7-8274-2db65763cecf"), "message" },
                    { new Guid("6c6b204c-dbfc-4d1b-aa04-de65bb1cbc09"), "notification" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { new Guid("da65d1c3-d06a-4c30-83da-b88d6686bb40"), "admin" },
                    { new Guid("10af563b-e5f6-4fdf-b153-c2eee06e8ea6"), "user" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ConnectionStatus", "Password", "RoleId", "UserName", "UserPhoto" },
                values: new object[] { new Guid("3fda4647-802a-4e72-b7d6-b23908195c00"), "online", "123456", new Guid("da65d1c3-d06a-4c30-83da-b88d6686bb40"), "admin", null });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatUserId",
                table: "Messages",
                column: "ChatUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_ChatUsers_ChatUserId",
                table: "Messages",
                column: "ChatUserId",
                principalTable: "ChatUsers",
                principalColumn: "ChatUserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
