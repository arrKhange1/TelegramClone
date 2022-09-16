using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TelegramClone.Migrations
{
    public partial class AddUserContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "UserContacts",
                columns: table => new
                {
                    UserContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserContacts", x => x.UserContactId);
                    table.ForeignKey(
                        name: "FK_UserContacts_Users_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_UserContacts_ContactId",
                table: "UserContacts",
                column: "ContactId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserContacts");

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
                values: new object[] { new Guid("6a0aba0e-a1e1-43d5-bb21-0dddc2588463"), "admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { new Guid("f44925b8-e9c9-4d51-b99d-d6ab39fe0e93"), "user" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ConnectionStatus", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("7f3b1f06-e3eb-44cf-892f-a63ef410d924"), "online", "123456", new Guid("6a0aba0e-a1e1-43d5-bb21-0dddc2588463"), "admin" });
        }
    }
}
