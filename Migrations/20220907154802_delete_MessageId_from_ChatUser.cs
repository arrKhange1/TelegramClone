using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TelegramClone.Migrations
{
    public partial class delete_MessageId_from_ChatUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatUsers_Messages_MessageId",
                table: "ChatUsers");

            migrationBuilder.DropIndex(
                name: "IX_ChatUsers_MessageId",
                table: "ChatUsers");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("b6894f6d-d6f0-4716-96e4-895cdc340d24"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("f7cab27a-57ce-4c7b-9a45-33e55893f60d"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("f9cd7e3e-be2e-4821-912a-9e483753a397"));

            migrationBuilder.DropColumn(
                name: "MessageId",
                table: "ChatUsers");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { new Guid("f5b5fc8d-98ca-45c6-ad8e-2d1d1e7c08ce"), "admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { new Guid("f527b1ab-0772-41a1-9d0c-f930b39ae29e"), "user" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ConnectionStatus", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("e0b7f70d-4891-46f8-be1e-6607440f7282"), "online", "123456", new Guid("f5b5fc8d-98ca-45c6-ad8e-2d1d1e7c08ce"), "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("f527b1ab-0772-41a1-9d0c-f930b39ae29e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("e0b7f70d-4891-46f8-be1e-6607440f7282"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("f5b5fc8d-98ca-45c6-ad8e-2d1d1e7c08ce"));

            migrationBuilder.AddColumn<Guid>(
                name: "MessageId",
                table: "ChatUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { new Guid("f9cd7e3e-be2e-4821-912a-9e483753a397"), "admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { new Guid("b6894f6d-d6f0-4716-96e4-895cdc340d24"), "user" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ConnectionStatus", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("f7cab27a-57ce-4c7b-9a45-33e55893f60d"), "online", "123456", new Guid("f9cd7e3e-be2e-4821-912a-9e483753a397"), "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_ChatUsers_MessageId",
                table: "ChatUsers",
                column: "MessageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatUsers_Messages_MessageId",
                table: "ChatUsers",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "MessageId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
