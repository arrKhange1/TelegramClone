using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TelegramClone.Migrations
{
    public partial class AddUserPhotoToUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "UserPhoto",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "UserPhoto",
                table: "Users");

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
        }
    }
}
