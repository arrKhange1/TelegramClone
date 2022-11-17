using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TelegramClone.Migrations
{
    public partial class AddMessageTimeToDialogMessages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChatCategories",
                keyColumn: "ChatCategoryId",
                keyValue: new Guid("56ecc321-c945-4934-bdf9-0f18aa17e18d"));

            migrationBuilder.DeleteData(
                table: "ChatCategories",
                keyColumn: "ChatCategoryId",
                keyValue: new Guid("8228174e-f5ec-4268-9846-a6b78950648f"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("52a530de-9114-4ee1-9a5c-d21b46c87482"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("59eba10d-6dd5-4f4e-9261-169583323345"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("daab1f9b-ae60-454e-b205-270c5765adab"));

            migrationBuilder.AddColumn<DateTime>(
                name: "MessageTime",
                table: "DialogMessages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "ChatCategories",
                columns: new[] { "ChatCategoryId", "ChatCategoryName" },
                values: new object[,]
                {
                    { new Guid("c6fcf6a2-a14d-40c9-b874-63a0745ccf74"), "private" },
                    { new Guid("2643769a-cc21-4c3c-8053-8a67f482a1b8"), "group" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { new Guid("1a00e840-34d4-4cc5-b910-b094ff6e70e3"), "admin" },
                    { new Guid("f97e2960-5769-4e2b-a38e-f30d7d1409a1"), "user" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ConnectionStatus", "Password", "RoleId", "UserName", "UserPhoto" },
                values: new object[] { new Guid("ddef73bf-2862-44d1-9291-92db3be0d435"), "online", "123456", new Guid("1a00e840-34d4-4cc5-b910-b094ff6e70e3"), "admin", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChatCategories",
                keyColumn: "ChatCategoryId",
                keyValue: new Guid("2643769a-cc21-4c3c-8053-8a67f482a1b8"));

            migrationBuilder.DeleteData(
                table: "ChatCategories",
                keyColumn: "ChatCategoryId",
                keyValue: new Guid("c6fcf6a2-a14d-40c9-b874-63a0745ccf74"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("f97e2960-5769-4e2b-a38e-f30d7d1409a1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("ddef73bf-2862-44d1-9291-92db3be0d435"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("1a00e840-34d4-4cc5-b910-b094ff6e70e3"));

            migrationBuilder.DropColumn(
                name: "MessageTime",
                table: "DialogMessages");

            migrationBuilder.InsertData(
                table: "ChatCategories",
                columns: new[] { "ChatCategoryId", "ChatCategoryName" },
                values: new object[,]
                {
                    { new Guid("8228174e-f5ec-4268-9846-a6b78950648f"), "private" },
                    { new Guid("56ecc321-c945-4934-bdf9-0f18aa17e18d"), "group" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { new Guid("daab1f9b-ae60-454e-b205-270c5765adab"), "admin" },
                    { new Guid("52a530de-9114-4ee1-9a5c-d21b46c87482"), "user" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ConnectionStatus", "Password", "RoleId", "UserName", "UserPhoto" },
                values: new object[] { new Guid("59eba10d-6dd5-4f4e-9261-169583323345"), "online", "123456", new Guid("daab1f9b-ae60-454e-b205-270c5765adab"), "admin", null });
        }
    }
}
