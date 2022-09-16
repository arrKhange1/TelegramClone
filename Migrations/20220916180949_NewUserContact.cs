using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TelegramClone.Migrations
{
    public partial class NewUserContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserContacts_Users_ContactId",
                table: "UserContacts");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("43761fbe-1c5a-4d6f-a7c4-fc7511b715f6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("ab5fabad-ed41-4854-8e34-69fddbc9e605"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("af064f86-6e93-40d9-a70b-e81e92a21805"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { new Guid("744c027c-422c-4e67-9479-8ff705a06b60"), "admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { new Guid("e141395b-ad79-494e-997b-035377980c9f"), "user" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ConnectionStatus", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("ebfabcc4-6685-48ab-8ce9-1337137f4f91"), "online", "123456", new Guid("744c027c-422c-4e67-9479-8ff705a06b60"), "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_UserContacts_UserId",
                table: "UserContacts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserContacts_Users_ContactId",
                table: "UserContacts",
                column: "ContactId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserContacts_Users_UserId",
                table: "UserContacts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserContacts_Users_ContactId",
                table: "UserContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserContacts_Users_UserId",
                table: "UserContacts");

            migrationBuilder.DropIndex(
                name: "IX_UserContacts_UserId",
                table: "UserContacts");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("e141395b-ad79-494e-997b-035377980c9f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("ebfabcc4-6685-48ab-8ce9-1337137f4f91"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("744c027c-422c-4e67-9479-8ff705a06b60"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { new Guid("af064f86-6e93-40d9-a70b-e81e92a21805"), "admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { new Guid("43761fbe-1c5a-4d6f-a7c4-fc7511b715f6"), "user" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ConnectionStatus", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("ab5fabad-ed41-4854-8e34-69fddbc9e605"), "online", "123456", new Guid("af064f86-6e93-40d9-a70b-e81e92a21805"), "admin" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserContacts_Users_ContactId",
                table: "UserContacts",
                column: "ContactId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
