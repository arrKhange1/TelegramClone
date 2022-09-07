using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TelegramClone.Migrations
{
    public partial class add_connection_status_to_user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("8fd9649e-799a-4c25-89ba-fbb771ded3fd"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("cd14d406-60e7-4914-aa2a-aecfd5013373"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("b8eba6b7-02b6-459b-9b41-d946430aaf98"));

            migrationBuilder.AddColumn<string>(
                name: "ConnectionStatus",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "ConnectionStatus",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { new Guid("b8eba6b7-02b6-459b-9b41-d946430aaf98"), "admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { new Guid("8fd9649e-799a-4c25-89ba-fbb771ded3fd"), "user" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("cd14d406-60e7-4914-aa2a-aecfd5013373"), "123456", new Guid("b8eba6b7-02b6-459b-9b41-d946430aaf98"), "admin" });
        }
    }
}
