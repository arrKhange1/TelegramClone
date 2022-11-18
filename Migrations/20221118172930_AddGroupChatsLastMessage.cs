using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TelegramClone.Migrations
{
    public partial class AddGroupChatsLastMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChatCategories",
                keyColumn: "ChatCategoryId",
                keyValue: new Guid("0e5534d7-db4f-4f65-87ec-70b17395fdd2"));

            migrationBuilder.DeleteData(
                table: "ChatCategories",
                keyColumn: "ChatCategoryId",
                keyValue: new Guid("c966fb9b-88c2-46c9-aec5-b82e3c29eafd"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("03c80aae-7bab-4de8-a6b6-5326ec7e6499"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("408113db-9f86-4690-ba36-c2f27e20de0f"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("862b5a2f-fe57-4174-b040-d296efb53f5b"));

            migrationBuilder.AddColumn<Guid>(
                name: "LastMessageId",
                table: "Chats",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "ChatCategories",
                columns: new[] { "ChatCategoryId", "ChatCategoryName" },
                values: new object[,]
                {
                    { new Guid("748562c3-f2ef-4a23-8822-f9c71659baea"), "private" },
                    { new Guid("d79677ed-69da-4e81-a33f-b483e8c5ba29"), "group" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { new Guid("58828030-5f21-4792-a0ce-bb28a34eab28"), "admin" },
                    { new Guid("8af8968e-b44b-4f13-a554-6bcd927f90c8"), "user" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ConnectionStatus", "Password", "RoleId", "UserName", "UserPhoto" },
                values: new object[] { new Guid("3f4df199-dc20-4b13-bb47-d82b6997ff42"), "online", "123456", new Guid("58828030-5f21-4792-a0ce-bb28a34eab28"), "admin", null });

            migrationBuilder.CreateIndex(
                name: "IX_Chats_LastMessageId",
                table: "Chats",
                column: "LastMessageId",
                unique: true,
                filter: "[LastMessageId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Messages_LastMessageId",
                table: "Chats",
                column: "LastMessageId",
                principalTable: "Messages",
                principalColumn: "MessageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Messages_LastMessageId",
                table: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_Chats_LastMessageId",
                table: "Chats");

            migrationBuilder.DeleteData(
                table: "ChatCategories",
                keyColumn: "ChatCategoryId",
                keyValue: new Guid("748562c3-f2ef-4a23-8822-f9c71659baea"));

            migrationBuilder.DeleteData(
                table: "ChatCategories",
                keyColumn: "ChatCategoryId",
                keyValue: new Guid("d79677ed-69da-4e81-a33f-b483e8c5ba29"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("8af8968e-b44b-4f13-a554-6bcd927f90c8"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("3f4df199-dc20-4b13-bb47-d82b6997ff42"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("58828030-5f21-4792-a0ce-bb28a34eab28"));

            migrationBuilder.DropColumn(
                name: "LastMessageId",
                table: "Chats");

            migrationBuilder.InsertData(
                table: "ChatCategories",
                columns: new[] { "ChatCategoryId", "ChatCategoryName" },
                values: new object[,]
                {
                    { new Guid("0e5534d7-db4f-4f65-87ec-70b17395fdd2"), "private" },
                    { new Guid("c966fb9b-88c2-46c9-aec5-b82e3c29eafd"), "group" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { new Guid("862b5a2f-fe57-4174-b040-d296efb53f5b"), "admin" },
                    { new Guid("03c80aae-7bab-4de8-a6b6-5326ec7e6499"), "user" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ConnectionStatus", "Password", "RoleId", "UserName", "UserPhoto" },
                values: new object[] { new Guid("408113db-9f86-4690-ba36-c2f27e20de0f"), "online", "123456", new Guid("862b5a2f-fe57-4174-b040-d296efb53f5b"), "admin", null });
        }
    }
}
