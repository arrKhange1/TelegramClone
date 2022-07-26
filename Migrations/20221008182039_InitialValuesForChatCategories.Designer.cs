﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TelegramClone.Data;

namespace TelegramClone.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20221008182039_InitialValuesForChatCategories")]
    partial class InitialValuesForChatCategories
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("GroupMembers")
                        .HasColumnType("int");

                    b.HasKey("ChatId");

                    b.HasIndex("ChatCategoryId");

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
                            ChatCategoryId = new Guid("94852662-31b0-4c94-bca6-30156c242aee"),
                            ChatCategoryName = "private"
                        },
                        new
                        {
                            ChatCategoryId = new Guid("30ff35ed-33f4-4f20-a6ee-853f762b1aaa"),
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

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ChatUserId");

                    b.HasIndex("ChatId");

                    b.HasIndex("UserId");

                    b.ToTable("ChatUsers");
                });

            modelBuilder.Entity("TelegramClone.Models.Message", b =>
                {
                    b.Property<Guid>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChatUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MessageText")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MessageId");

                    b.HasIndex("ChatUserId");

                    b.ToTable("Messages");
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
                            RoleId = new Guid("776a1980-4913-45cc-a842-de4b6ca1c7cf"),
                            RoleName = "admin"
                        },
                        new
                        {
                            RoleId = new Guid("25008ce6-7fbc-4cb8-b8de-d0198f649e10"),
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
                            UserId = new Guid("7ef88fbc-f2a4-4e79-a846-8542e2905ce9"),
                            ConnectionStatus = "online",
                            Password = "123456",
                            RoleId = new Guid("776a1980-4913-45cc-a842-de4b6ca1c7cf"),
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

                    b.Navigation("ChatCategory");
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

            modelBuilder.Entity("TelegramClone.Models.Message", b =>
                {
                    b.HasOne("TelegramClone.Models.ChatUser", "ChatUser")
                        .WithMany("Messages")
                        .HasForeignKey("ChatUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChatUser");
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
                });

            modelBuilder.Entity("TelegramClone.Models.ChatUser", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("TelegramClone.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("TelegramClone.Models.User", b =>
                {
                    b.Navigation("ChatUsers");

                    b.Navigation("RefreshTokens");

                    b.Navigation("UserContactsContacts");

                    b.Navigation("UserContactsUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
