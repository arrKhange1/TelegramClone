using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TelegramClone.Migrations
{
    public partial class add_chat_caterogiries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("860fa9c5-df14-494a-91f9-f8c930f6e8f3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("65780ee3-3075-44b0-a659-90585bee5af8"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("a4af6202-9dc9-4414-b07c-608e32dd366e"));

            migrationBuilder.AddColumn<Guid>(
                name: "ChatCategoryId",
                table: "Chats",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "GroupMembers",
                table: "Chats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ChatCategories",
                columns: table => new
                {
                    ChatCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChatCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatCategories", x => x.ChatCategoryId);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Chats_ChatCategoryId",
                table: "Chats",
                column: "ChatCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_ChatCategories_ChatCategoryId",
                table: "Chats",
                column: "ChatCategoryId",
                principalTable: "ChatCategories",
                principalColumn: "ChatCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_ChatCategories_ChatCategoryId",
                table: "Chats");

            migrationBuilder.DropTable(
                name: "ChatCategories");

            migrationBuilder.DropIndex(
                name: "IX_Chats_ChatCategoryId",
                table: "Chats");

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

            migrationBuilder.DropColumn(
                name: "ChatCategoryId",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "GroupMembers",
                table: "Chats");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { new Guid("a4af6202-9dc9-4414-b07c-608e32dd366e"), "admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { new Guid("860fa9c5-df14-494a-91f9-f8c930f6e8f3"), "user" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("65780ee3-3075-44b0-a659-90585bee5af8"), "123456", new Guid("a4af6202-9dc9-4414-b07c-608e32dd366e"), "admin" });
        }
    }
}
