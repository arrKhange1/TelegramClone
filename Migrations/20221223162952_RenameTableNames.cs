using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TelegramClone.Migrations
{
    public partial class RenameTableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Messages_LastMessageId",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_DialogMessages_Dialogs_DialogId",
                table: "DialogMessages");

            migrationBuilder.DropTable(
                name: "ChatUsers");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "MessageTypes");

            migrationBuilder.DropTable(
                name: "Dialogs");

            migrationBuilder.DropTable(
                name: "DialogMessages");

            migrationBuilder.DeleteData(
                table: "ChatCategories",
                keyColumn: "ChatCategoryId",
                keyValue: new Guid("8a726d61-3053-4fa5-a9a6-87714c18d775"));

            migrationBuilder.DeleteData(
                table: "ChatCategories",
                keyColumn: "ChatCategoryId",
                keyValue: new Guid("a9c68552-b9d7-41b2-b4f7-0b1cc0405878"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("19ca66c4-c6e7-446c-aac8-61ed2432eada"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("cc434f89-d58b-43ce-990c-601f4392d642"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("27ae9391-c712-4f63-a2f6-4b9764e7e0e1"));

            migrationBuilder.CreateTable(
                name: "GroupChatMessageTypes",
                columns: table => new
                {
                    GroupChatMessageTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupChatMessageTypes", x => x.GroupChatMessageTypeId);
                });

            migrationBuilder.CreateTable(
                name: "GroupChats",
                columns: table => new
                {
                    GroupChatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChatName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupMembers = table.Column<int>(type: "int", nullable: false),
                    ChatCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastMessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupChats", x => x.GroupChatId);
                    table.ForeignKey(
                        name: "FK_GroupChats_ChatCategories_ChatCategoryId",
                        column: x => x.ChatCategoryId,
                        principalTable: "ChatCategories",
                        principalColumn: "ChatCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupChatMessages",
                columns: table => new
                {
                    GroupChatMessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MessageText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GroupChatMessageTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupChatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupChatMessages", x => x.GroupChatMessageId);
                    table.ForeignKey(
                        name: "FK_GroupChatMessages_GroupChatMessageTypes_GroupChatMessageTypeId",
                        column: x => x.GroupChatMessageTypeId,
                        principalTable: "GroupChatMessageTypes",
                        principalColumn: "GroupChatMessageTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupChatMessages_GroupChats_GroupChatId",
                        column: x => x.GroupChatId,
                        principalTable: "GroupChats",
                        principalColumn: "GroupChatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupChatMessages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupChatUsers",
                columns: table => new
                {
                    GroupChatUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupChatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnreadMessages = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupChatUsers", x => x.GroupChatUserId);
                    table.ForeignKey(
                        name: "FK_GroupChatUsers_GroupChats_GroupChatId",
                        column: x => x.GroupChatId,
                        principalTable: "GroupChats",
                        principalColumn: "GroupChatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupChatUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrivateChats",
                columns: table => new
                {
                    PrivateChatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstParticipantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SecondParticipantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnreadMsgsByFirst = table.Column<int>(type: "int", nullable: false),
                    UnreadMsgsBySecond = table.Column<int>(type: "int", nullable: false),
                    LastMessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateChats", x => x.PrivateChatId);
                    table.ForeignKey(
                        name: "FK_PrivateChats_Users_FirstParticipantId",
                        column: x => x.FirstParticipantId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_PrivateChats_Users_SecondParticipantId",
                        column: x => x.SecondParticipantId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "PrivateChatMessages",
                columns: table => new
                {
                    PrivateChatMessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrivateChatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MessageText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateChatMessages", x => x.PrivateChatMessageId);
                    table.ForeignKey(
                        name: "FK_PrivateChatMessages_PrivateChats_PrivateChatId",
                        column: x => x.PrivateChatId,
                        principalTable: "PrivateChats",
                        principalColumn: "PrivateChatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrivateChatMessages_Users_SenderId",
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
                    { new Guid("5dee7a70-d366-4ee2-92ec-3779f47f0b52"), "private" },
                    { new Guid("c4084d91-3e88-49f6-a5d8-bbe6adafb284"), "group" }
                });

            migrationBuilder.InsertData(
                table: "GroupChatMessageTypes",
                columns: new[] { "GroupChatMessageTypeId", "Type" },
                values: new object[,]
                {
                    { new Guid("a89afbe2-9e3b-46d7-8131-be4d07553313"), "message" },
                    { new Guid("bd5733bd-ce03-4281-acdb-fe5c3e95cc40"), "notification" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { new Guid("11e9ff6f-e5f3-4d0d-82e0-393017290c50"), "admin" },
                    { new Guid("118d10a2-09ad-490e-974b-43ddf1a10b0e"), "user" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ConnectionStatus", "Password", "RoleId", "UserName", "UserPhoto" },
                values: new object[] { new Guid("c4c534d5-4d37-47c4-916e-fa198d632f6a"), "online", "123456", new Guid("11e9ff6f-e5f3-4d0d-82e0-393017290c50"), "admin", null });

            migrationBuilder.CreateIndex(
                name: "IX_GroupChatMessages_GroupChatId",
                table: "GroupChatMessages",
                column: "GroupChatId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupChatMessages_GroupChatMessageTypeId",
                table: "GroupChatMessages",
                column: "GroupChatMessageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupChatMessages_UserId",
                table: "GroupChatMessages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupChats_ChatCategoryId",
                table: "GroupChats",
                column: "ChatCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupChats_LastMessageId",
                table: "GroupChats",
                column: "LastMessageId",
                unique: true,
                filter: "[LastMessageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GroupChatUsers_GroupChatId",
                table: "GroupChatUsers",
                column: "GroupChatId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupChatUsers_UserId",
                table: "GroupChatUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateChatMessages_PrivateChatId",
                table: "PrivateChatMessages",
                column: "PrivateChatId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateChatMessages_SenderId",
                table: "PrivateChatMessages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateChats_FirstParticipantId",
                table: "PrivateChats",
                column: "FirstParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateChats_LastMessageId",
                table: "PrivateChats",
                column: "LastMessageId",
                unique: true,
                filter: "[LastMessageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateChats_SecondParticipantId",
                table: "PrivateChats",
                column: "SecondParticipantId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupChats_GroupChatMessages_LastMessageId",
                table: "GroupChats",
                column: "LastMessageId",
                principalTable: "GroupChatMessages",
                principalColumn: "GroupChatMessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_PrivateChats_PrivateChatMessages_LastMessageId",
                table: "PrivateChats",
                column: "LastMessageId",
                principalTable: "PrivateChatMessages",
                principalColumn: "PrivateChatMessageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupChatMessages_GroupChatMessageTypes_GroupChatMessageTypeId",
                table: "GroupChatMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupChatMessages_GroupChats_GroupChatId",
                table: "GroupChatMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_PrivateChatMessages_PrivateChats_PrivateChatId",
                table: "PrivateChatMessages");

            migrationBuilder.DropTable(
                name: "GroupChatUsers");

            migrationBuilder.DropTable(
                name: "GroupChatMessageTypes");

            migrationBuilder.DropTable(
                name: "GroupChats");

            migrationBuilder.DropTable(
                name: "GroupChatMessages");

            migrationBuilder.DropTable(
                name: "PrivateChats");

            migrationBuilder.DropTable(
                name: "PrivateChatMessages");

            migrationBuilder.DeleteData(
                table: "ChatCategories",
                keyColumn: "ChatCategoryId",
                keyValue: new Guid("5dee7a70-d366-4ee2-92ec-3779f47f0b52"));

            migrationBuilder.DeleteData(
                table: "ChatCategories",
                keyColumn: "ChatCategoryId",
                keyValue: new Guid("c4084d91-3e88-49f6-a5d8-bbe6adafb284"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("118d10a2-09ad-490e-974b-43ddf1a10b0e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("c4c534d5-4d37-47c4-916e-fa198d632f6a"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: new Guid("11e9ff6f-e5f3-4d0d-82e0-393017290c50"));

            migrationBuilder.CreateTable(
                name: "MessageTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChatUsers",
                columns: table => new
                {
                    ChatUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnreadMessages = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatUsers", x => x.ChatUserId);
                    table.ForeignKey(
                        name: "FK_ChatUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MessageText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MessageTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Messages_MessageTypes_MessageTypeId",
                        column: x => x.MessageTypeId,
                        principalTable: "MessageTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    ChatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChatCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChatName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GroupMembers = table.Column<int>(type: "int", nullable: false),
                    LastMessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.ChatId);
                    table.ForeignKey(
                        name: "FK_Chats_ChatCategories_ChatCategoryId",
                        column: x => x.ChatCategoryId,
                        principalTable: "ChatCategories",
                        principalColumn: "ChatCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chats_Messages_LastMessageId",
                        column: x => x.LastMessageId,
                        principalTable: "Messages",
                        principalColumn: "MessageId");
                });

            migrationBuilder.CreateTable(
                name: "Dialogs",
                columns: table => new
                {
                    DialogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstParticipantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastMessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SecondParticipantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnreadMsgsByFirst = table.Column<int>(type: "int", nullable: false),
                    UnreadMsgsBySecond = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dialogs", x => x.DialogId);
                    table.ForeignKey(
                        name: "FK_Dialogs_Users_FirstParticipantId",
                        column: x => x.FirstParticipantId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Dialogs_Users_SecondParticipantId",
                        column: x => x.SecondParticipantId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "DialogMessages",
                columns: table => new
                {
                    MessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DialogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MessageText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DialogMessages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_DialogMessages_Dialogs_DialogId",
                        column: x => x.DialogId,
                        principalTable: "Dialogs",
                        principalColumn: "DialogId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DialogMessages_Users_SenderId",
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
                    { new Guid("a9c68552-b9d7-41b2-b4f7-0b1cc0405878"), "private" },
                    { new Guid("8a726d61-3053-4fa5-a9a6-87714c18d775"), "group" }
                });

            migrationBuilder.InsertData(
                table: "MessageTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { new Guid("700774ce-ddbc-4b20-a71e-3359c800cb56"), "message" },
                    { new Guid("0cfbcc61-79a3-49b9-a471-2983015fb5be"), "notification" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { new Guid("27ae9391-c712-4f63-a2f6-4b9764e7e0e1"), "admin" },
                    { new Guid("19ca66c4-c6e7-446c-aac8-61ed2432eada"), "user" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ConnectionStatus", "Password", "RoleId", "UserName", "UserPhoto" },
                values: new object[] { new Guid("cc434f89-d58b-43ce-990c-601f4392d642"), "online", "123456", new Guid("27ae9391-c712-4f63-a2f6-4b9764e7e0e1"), "admin", null });

            migrationBuilder.CreateIndex(
                name: "IX_Chats_ChatCategoryId",
                table: "Chats",
                column: "ChatCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_LastMessageId",
                table: "Chats",
                column: "LastMessageId",
                unique: true,
                filter: "[LastMessageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ChatUsers_ChatId",
                table: "ChatUsers",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatUsers_UserId",
                table: "ChatUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DialogMessages_DialogId",
                table: "DialogMessages",
                column: "DialogId");

            migrationBuilder.CreateIndex(
                name: "IX_DialogMessages_SenderId",
                table: "DialogMessages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Dialogs_FirstParticipantId",
                table: "Dialogs",
                column: "FirstParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_Dialogs_LastMessageId",
                table: "Dialogs",
                column: "LastMessageId",
                unique: true,
                filter: "[LastMessageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Dialogs_SecondParticipantId",
                table: "Dialogs",
                column: "SecondParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatId",
                table: "Messages",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_MessageTypeId",
                table: "Messages",
                column: "MessageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatUsers_Chats_ChatId",
                table: "ChatUsers",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "ChatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Chats_ChatId",
                table: "Messages",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "ChatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dialogs_DialogMessages_LastMessageId",
                table: "Dialogs",
                column: "LastMessageId",
                principalTable: "DialogMessages",
                principalColumn: "MessageId");
        }
    }
}
