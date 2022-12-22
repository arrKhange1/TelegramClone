﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TelegramClone.Data;

namespace TelegramClone.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("TelegramClone.Models.Chat", b =>
                {
                    b.Property<Guid>("ChatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChatCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ChatName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("GroupMembers")
                        .HasColumnType("int");

                    b.Property<Guid?>("LastMessageId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ChatId");

                    b.HasIndex("ChatCategoryId");

                    b.HasIndex("LastMessageId")
                        .IsUnique()
                        .HasFilter("[LastMessageId] IS NOT NULL");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("TelegramClone.Models.ChatCategory", b =>
                {
                    b.Property<Guid>("ChatCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ChatCategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ChatCategoryId");

                    b.ToTable("ChatCategories");

                    b.HasData(
                        new
                        {
                            ChatCategoryId = new Guid("a9c68552-b9d7-41b2-b4f7-0b1cc0405878"),
                            ChatCategoryName = "private"
                        },
                        new
                        {
                            ChatCategoryId = new Guid("8a726d61-3053-4fa5-a9a6-87714c18d775"),
                            ChatCategoryName = "group"
                        });
                });

            modelBuilder.Entity("TelegramClone.Models.ChatUser", b =>
                {
                    b.Property<Guid>("ChatUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("UnreadMessages")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ChatUserId");

                    b.HasIndex("ChatId");

                    b.HasIndex("UserId");

                    b.ToTable("ChatUsers");
                });

            modelBuilder.Entity("TelegramClone.Models.Dialog", b =>
                {
                    b.Property<Guid>("DialogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FirstParticipantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("LastMessageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SecondParticipantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("UnreadMsgsByFirst")
                        .HasColumnType("int");

                    b.Property<int>("UnreadMsgsBySecond")
                        .HasColumnType("int");

                    b.HasKey("DialogId");

                    b.HasIndex("FirstParticipantId");

                    b.HasIndex("LastMessageId")
                        .IsUnique()
                        .HasFilter("[LastMessageId] IS NOT NULL");

                    b.HasIndex("SecondParticipantId");

                    b.ToTable("Dialogs");
                });

            modelBuilder.Entity("TelegramClone.Models.DialogMessage", b =>
                {
                    b.Property<Guid>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DialogId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MessageText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MessageTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MessageId");

                    b.HasIndex("DialogId");

                    b.HasIndex("SenderId");

                    b.ToTable("DialogMessages");
                });

            modelBuilder.Entity("TelegramClone.Models.Message", b =>
                {
                    b.Property<Guid>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MessageText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MessageTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MessageTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MessageId");

                    b.HasIndex("ChatId");

                    b.HasIndex("MessageTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("TelegramClone.Models.MessageType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MessageTypes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("700774ce-ddbc-4b20-a71e-3359c800cb56"),
                            Type = "message"
                        },
                        new
                        {
                            Id = new Guid("0cfbcc61-79a3-49b9-a471-2983015fb5be"),
                            Type = "notification"
                        });
                });

            modelBuilder.Entity("TelegramClone.Models.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ExpireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("TelegramClone.Models.Role", b =>
                {
                    b.Property<Guid>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = new Guid("27ae9391-c712-4f63-a2f6-4b9764e7e0e1"),
                            RoleName = "admin"
                        },
                        new
                        {
                            RoleId = new Guid("19ca66c4-c6e7-446c-aac8-61ed2432eada"),
                            RoleName = "user"
                        });
                });

            modelBuilder.Entity("TelegramClone.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConnectionStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPhoto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("cc434f89-d58b-43ce-990c-601f4392d642"),
                            ConnectionStatus = "online",
                            Password = "123456",
                            RoleId = new Guid("27ae9391-c712-4f63-a2f6-4b9764e7e0e1"),
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("TelegramClone.Models.UserContact", b =>
                {
                    b.Property<Guid>("UserContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ContactId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserContactId");

                    b.HasIndex("ContactId");

                    b.HasIndex("UserId", "ContactId")
                        .IsUnique();

                    b.ToTable("UserContacts");
                });

            modelBuilder.Entity("TelegramClone.Models.Chat", b =>
                {
                    b.HasOne("TelegramClone.Models.ChatCategory", "ChatCategory")
                        .WithMany()
                        .HasForeignKey("ChatCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TelegramClone.Models.Message", "LastMessage")
                        .WithOne("Chat")
                        .HasForeignKey("TelegramClone.Models.Chat", "LastMessageId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("ChatCategory");

                    b.Navigation("LastMessage");
                });

            modelBuilder.Entity("TelegramClone.Models.ChatUser", b =>
                {
                    b.HasOne("TelegramClone.Models.Chat", "Chat")
                        .WithMany("ChatUsers")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TelegramClone.Models.User", "User")
                        .WithMany("ChatUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TelegramClone.Models.Dialog", b =>
                {
                    b.HasOne("TelegramClone.Models.User", "FirstParticipant")
                        .WithMany("DialogsFirstParticipants")
                        .HasForeignKey("FirstParticipantId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TelegramClone.Models.DialogMessage", "LastMessage")
                        .WithOne("Dialog")
                        .HasForeignKey("TelegramClone.Models.Dialog", "LastMessageId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("TelegramClone.Models.User", "SecondParticipant")
                        .WithMany("DialogsSecondParticipants")
                        .HasForeignKey("SecondParticipantId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("FirstParticipant");

                    b.Navigation("LastMessage");

                    b.Navigation("SecondParticipant");
                });

            modelBuilder.Entity("TelegramClone.Models.DialogMessage", b =>
                {
                    b.HasOne("TelegramClone.Models.Dialog", null)
                        .WithMany("DialogMessages")
                        .HasForeignKey("DialogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TelegramClone.Models.User", "Sender")
                        .WithMany("DialogMessages")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("TelegramClone.Models.Message", b =>
                {
                    b.HasOne("TelegramClone.Models.Chat", null)
                        .WithMany("Messages")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TelegramClone.Models.MessageType", "MessageType")
                        .WithMany("Message")
                        .HasForeignKey("MessageTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TelegramClone.Models.User", "User")
                        .WithMany("Messages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MessageType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TelegramClone.Models.RefreshToken", b =>
                {
                    b.HasOne("TelegramClone.Models.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TelegramClone.Models.User", b =>
                {
                    b.HasOne("TelegramClone.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("TelegramClone.Models.UserContact", b =>
                {
                    b.HasOne("TelegramClone.Models.User", "Contact")
                        .WithMany("UserContactsContacts")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TelegramClone.Models.User", "User")
                        .WithMany("UserContactsUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Contact");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TelegramClone.Models.Chat", b =>
                {
                    b.Navigation("ChatUsers");

                    b.Navigation("Messages");
                });

            modelBuilder.Entity("TelegramClone.Models.Dialog", b =>
                {
                    b.Navigation("DialogMessages");
                });

            modelBuilder.Entity("TelegramClone.Models.DialogMessage", b =>
                {
                    b.Navigation("Dialog");
                });

            modelBuilder.Entity("TelegramClone.Models.Message", b =>
                {
                    b.Navigation("Chat");
                });

            modelBuilder.Entity("TelegramClone.Models.MessageType", b =>
                {
                    b.Navigation("Message");
                });

            modelBuilder.Entity("TelegramClone.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("TelegramClone.Models.User", b =>
                {
                    b.Navigation("ChatUsers");

                    b.Navigation("DialogMessages");

                    b.Navigation("DialogsFirstParticipants");

                    b.Navigation("DialogsSecondParticipants");

                    b.Navigation("Messages");

                    b.Navigation("RefreshTokens");

                    b.Navigation("UserContactsContacts");

                    b.Navigation("UserContactsUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
