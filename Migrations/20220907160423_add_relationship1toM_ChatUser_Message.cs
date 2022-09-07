using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TelegramClone.Migrations
{
    public partial class add_relationship1toM_ChatUser_Message : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "ChatUserId",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { new Guid("6a0aba0e-a1e1-43d5-bb21-0dddc2588463"), "admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { new Guid("f44925b8-e9c9-4d51-b99d-d6ab39fe0e93"), "user" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ConnectionStatus", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("7f3b1f06-e3eb-44cf-892f-a63ef410d924"), "online", "123456", new Guid("6a0aba0e-a1e1-43d5-bb21-0dddc2588463"), "admin" });

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
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_ChatUsers_ChatUserId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ChatUserId",
                table: "Messages");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("f44925b8-e9c9-4d51-b99d-d6ab39fe0e93"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("7f3b1f06-e3eb-44cf-892f-a63ef410d924"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("6a0aba0e-a1e1-43d5-bb21-0dddc2588463"));

            migrationBuilder.DropColumn(
                name: "ChatUserId",
                table: "Messages");

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
    }
}
