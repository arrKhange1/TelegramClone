using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TelegramClone.Migrations
{
    public partial class AddGroupChatMessageTypesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<Guid>(
                name: "MessageTypeId",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "MessageTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageTypes", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Messages_MessageTypeId",
                table: "Messages",
                column: "MessageTypeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_MessageTypes_MessageTypeId",
                table: "Messages",
                column: "MessageTypeId",
                principalTable: "MessageTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_MessageTypes_MessageTypeId",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "MessageTypes");

            migrationBuilder.DropIndex(
                name: "IX_Messages_MessageTypeId",
                table: "Messages");

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

            migrationBuilder.DropColumn(
                name: "MessageTypeId",
                table: "Messages");

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
        }
    }
}
