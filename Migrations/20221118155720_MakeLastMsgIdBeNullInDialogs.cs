using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TelegramClone.Migrations
{
    public partial class MakeLastMsgIdBeNullInDialogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<Guid>(
                name: "LastMessageId",
                table: "Dialogs",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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

            migrationBuilder.CreateIndex(
                name: "IX_Dialogs_LastMessageId",
                table: "Dialogs",
                column: "LastMessageId",
                unique: true,
                filter: "[LastMessageId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Dialogs_LastMessageId",
                table: "Dialogs");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "LastMessageId",
                table: "Dialogs",
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
        }
    }
}
