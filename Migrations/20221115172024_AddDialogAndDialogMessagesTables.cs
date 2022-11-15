using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TelegramClone.Migrations
{
    public partial class AddDialogAndDialogMessagesTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChatCategories",
                keyColumn: "ChatCategoryId",
                keyValue: new Guid("1d0b7209-8071-4c92-b816-b79987c2c0d3"));

            migrationBuilder.DeleteData(
                table: "ChatCategories",
                keyColumn: "ChatCategoryId",
                keyValue: new Guid("29fcd69a-dbca-4376-ab27-4ecd8599c6c8"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("b30a7663-938a-44d3-9d3b-75f641c15119"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("dc5357fb-2961-4def-8c26-0777b4f4f271"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("ccd0ded5-1c01-459d-90f8-9e392e0b5ca9"));

            migrationBuilder.CreateTable(
                name: "Dialog",
                columns: table => new
                {
                    DialogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstParticipantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SecondParticipantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dialog", x => x.DialogId);
                    table.ForeignKey(
                        name: "FK_Dialog_Users_FirstParticipantId",
                        column: x => x.FirstParticipantId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Dialog_Users_SecondParticipantId",
                        column: x => x.SecondParticipantId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "DialogMessage",
                columns: table => new
                {
                    MessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DialogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MessageText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DialogMessage", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_DialogMessage_Dialog_DialogId",
                        column: x => x.DialogId,
                        principalTable: "Dialog",
                        principalColumn: "DialogId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DialogMessage_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ChatCategories",
                columns: new[] { "ChatCategoryId", "ChatCategoryName" },
                values: new object[,]
                {
                    { new Guid("e3a5ecde-5efb-4f9a-844b-51774a896548"), "private" },
                    { new Guid("ac100696-77a3-4404-8a76-e565309cbb05"), "group" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { new Guid("62088a5c-45a3-4cbd-961e-fb171c87327f"), "admin" },
                    { new Guid("4b591661-5e61-4337-b38a-e0af5cbf996e"), "user" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ConnectionStatus", "Password", "RoleId", "UserName", "UserPhoto" },
                values: new object[] { new Guid("93d7efab-74c3-444f-bf88-1e4a5237fea1"), "online", "123456", new Guid("62088a5c-45a3-4cbd-961e-fb171c87327f"), "admin", null });

            migrationBuilder.CreateIndex(
                name: "IX_Dialog_FirstParticipantId",
                table: "Dialog",
                column: "FirstParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_Dialog_SecondParticipantId",
                table: "Dialog",
                column: "SecondParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_DialogMessage_DialogId",
                table: "DialogMessage",
                column: "DialogId");

            migrationBuilder.CreateIndex(
                name: "IX_DialogMessage_SenderId",
                table: "DialogMessage",
                column: "SenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DialogMessage");

            migrationBuilder.DropTable(
                name: "Dialog");

            migrationBuilder.DeleteData(
                table: "ChatCategories",
                keyColumn: "ChatCategoryId",
                keyValue: new Guid("ac100696-77a3-4404-8a76-e565309cbb05"));

            migrationBuilder.DeleteData(
                table: "ChatCategories",
                keyColumn: "ChatCategoryId",
                keyValue: new Guid("e3a5ecde-5efb-4f9a-844b-51774a896548"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("4b591661-5e61-4337-b38a-e0af5cbf996e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("93d7efab-74c3-444f-bf88-1e4a5237fea1"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("62088a5c-45a3-4cbd-961e-fb171c87327f"));

            migrationBuilder.InsertData(
                table: "ChatCategories",
                columns: new[] { "ChatCategoryId", "ChatCategoryName" },
                values: new object[,]
                {
                    { new Guid("1d0b7209-8071-4c92-b816-b79987c2c0d3"), "private" },
                    { new Guid("29fcd69a-dbca-4376-ab27-4ecd8599c6c8"), "group" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { new Guid("ccd0ded5-1c01-459d-90f8-9e392e0b5ca9"), "admin" },
                    { new Guid("b30a7663-938a-44d3-9d3b-75f641c15119"), "user" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ConnectionStatus", "Password", "RoleId", "UserName", "UserPhoto" },
                values: new object[] { new Guid("dc5357fb-2961-4def-8c26-0777b4f4f271"), "online", "123456", new Guid("ccd0ded5-1c01-459d-90f8-9e392e0b5ca9"), "admin", null });
        }
    }
}
