using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TelegramClone.Migrations
{
    public partial class DenormalizeMessagesChatUserIdIntoChatIdUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_ChatUsers_ChatUserId",
                table: "Messages");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "ChatUserId",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "ChatId",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
                name: "IX_Messages_ChatId",
                table: "Messages",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Chats_ChatId",
                table: "Messages",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "ChatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_ChatUsers_ChatUserId",
                table: "Messages",
                column: "ChatUserId",
                principalTable: "ChatUsers",
                principalColumn: "ChatUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_UserId",
                table: "Messages",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Chats_ChatId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_ChatUsers_ChatUserId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_UserId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ChatId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_UserId",
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
                name: "ChatId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Messages");

            migrationBuilder.AlterColumn<Guid>(
                name: "ChatUserId",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_ChatUsers_ChatUserId",
                table: "Messages",
                column: "ChatUserId",
                principalTable: "ChatUsers",
                principalColumn: "ChatUserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
