using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TelegramClone.Migrations
{
    public partial class MakeContactsUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserContacts_UserId",
                table: "UserContacts");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("671cba6a-0dc8-48dc-9b58-42e7fe089f61"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("bdf63c85-e9a1-497d-bc9c-bbee38840ab3"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("248cf7fc-ca68-4ffa-93c0-82ea0f451157"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { new Guid("a8cf67ba-95ee-4c14-a331-7537f06f0f41"), "admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { new Guid("34d02f91-a4e7-43ba-b739-9fd058c6b278"), "user" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ConnectionStatus", "Password", "RoleId", "UserName", "UserPhoto" },
                values: new object[] { new Guid("86ec46b1-c661-445e-b9ef-44bdc8aef0c4"), "online", "123456", new Guid("a8cf67ba-95ee-4c14-a331-7537f06f0f41"), "admin", null });

            migrationBuilder.CreateIndex(
                name: "IX_UserContacts_UserId_ContactId",
                table: "UserContacts",
                columns: new[] { "UserId", "ContactId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserContacts_UserId_ContactId",
                table: "UserContacts");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("34d02f91-a4e7-43ba-b739-9fd058c6b278"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("86ec46b1-c661-445e-b9ef-44bdc8aef0c4"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("a8cf67ba-95ee-4c14-a331-7537f06f0f41"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { new Guid("248cf7fc-ca68-4ffa-93c0-82ea0f451157"), "admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { new Guid("671cba6a-0dc8-48dc-9b58-42e7fe089f61"), "user" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ConnectionStatus", "Password", "RoleId", "UserName", "UserPhoto" },
                values: new object[] { new Guid("bdf63c85-e9a1-497d-bc9c-bbee38840ab3"), "online", "123456", new Guid("248cf7fc-ca68-4ffa-93c0-82ea0f451157"), "admin", null });

            migrationBuilder.CreateIndex(
                name: "IX_UserContacts_UserId",
                table: "UserContacts",
                column: "UserId");
        }
    }
}
