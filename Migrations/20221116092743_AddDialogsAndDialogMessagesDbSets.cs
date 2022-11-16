using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TelegramClone.Migrations
{
    public partial class AddDialogsAndDialogMessagesDbSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dialog_Users_FirstParticipantId",
                table: "Dialog");

            migrationBuilder.DropForeignKey(
                name: "FK_Dialog_Users_SecondParticipantId",
                table: "Dialog");

            migrationBuilder.DropForeignKey(
                name: "FK_DialogMessage_Dialog_DialogId",
                table: "DialogMessage");

            migrationBuilder.DropForeignKey(
                name: "FK_DialogMessage_Users_SenderId",
                table: "DialogMessage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DialogMessage",
                table: "DialogMessage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dialog",
                table: "Dialog");

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

            migrationBuilder.RenameTable(
                name: "DialogMessage",
                newName: "DialogMessages");

            migrationBuilder.RenameTable(
                name: "Dialog",
                newName: "Dialogs");

            migrationBuilder.RenameIndex(
                name: "IX_DialogMessage_SenderId",
                table: "DialogMessages",
                newName: "IX_DialogMessages_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_DialogMessage_DialogId",
                table: "DialogMessages",
                newName: "IX_DialogMessages_DialogId");

            migrationBuilder.RenameIndex(
                name: "IX_Dialog_SecondParticipantId",
                table: "Dialogs",
                newName: "IX_Dialogs_SecondParticipantId");

            migrationBuilder.RenameIndex(
                name: "IX_Dialog_FirstParticipantId",
                table: "Dialogs",
                newName: "IX_Dialogs_FirstParticipantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DialogMessages",
                table: "DialogMessages",
                column: "MessageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dialogs",
                table: "Dialogs",
                column: "DialogId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_DialogMessages_Dialogs_DialogId",
                table: "DialogMessages",
                column: "DialogId",
                principalTable: "Dialogs",
                principalColumn: "DialogId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DialogMessages_Users_SenderId",
                table: "DialogMessages",
                column: "SenderId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dialogs_Users_FirstParticipantId",
                table: "Dialogs",
                column: "FirstParticipantId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dialogs_Users_SecondParticipantId",
                table: "Dialogs",
                column: "SecondParticipantId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DialogMessages_Dialogs_DialogId",
                table: "DialogMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_DialogMessages_Users_SenderId",
                table: "DialogMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_Dialogs_Users_FirstParticipantId",
                table: "Dialogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Dialogs_Users_SecondParticipantId",
                table: "Dialogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dialogs",
                table: "Dialogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DialogMessages",
                table: "DialogMessages");

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

            migrationBuilder.RenameTable(
                name: "Dialogs",
                newName: "Dialog");

            migrationBuilder.RenameTable(
                name: "DialogMessages",
                newName: "DialogMessage");

            migrationBuilder.RenameIndex(
                name: "IX_Dialogs_SecondParticipantId",
                table: "Dialog",
                newName: "IX_Dialog_SecondParticipantId");

            migrationBuilder.RenameIndex(
                name: "IX_Dialogs_FirstParticipantId",
                table: "Dialog",
                newName: "IX_Dialog_FirstParticipantId");

            migrationBuilder.RenameIndex(
                name: "IX_DialogMessages_SenderId",
                table: "DialogMessage",
                newName: "IX_DialogMessage_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_DialogMessages_DialogId",
                table: "DialogMessage",
                newName: "IX_DialogMessage_DialogId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dialog",
                table: "Dialog",
                column: "DialogId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DialogMessage",
                table: "DialogMessage",
                column: "MessageId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Dialog_Users_FirstParticipantId",
                table: "Dialog",
                column: "FirstParticipantId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dialog_Users_SecondParticipantId",
                table: "Dialog",
                column: "SecondParticipantId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DialogMessage_Dialog_DialogId",
                table: "DialogMessage",
                column: "DialogId",
                principalTable: "Dialog",
                principalColumn: "DialogId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DialogMessage_Users_SenderId",
                table: "DialogMessage",
                column: "SenderId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
