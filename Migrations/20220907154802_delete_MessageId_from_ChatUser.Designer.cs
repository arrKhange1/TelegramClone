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
    [Migration("20220907154802_delete_MessageId_from_ChatUser")]
    partial class delete_MessageId_from_ChatUser
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

                    b.Property<string>("MessageText")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MessageId");

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
                            RoleId = new Guid("f5b5fc8d-98ca-45c6-ad8e-2d1d1e7c08ce"),
                            RoleName = "admin"
                        },
                        new
                        {
                            RoleId = new Guid("f527b1ab-0772-41a1-9d0c-f930b39ae29e"),
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

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("e0b7f70d-4891-46f8-be1e-6607440f7282"),
                            ConnectionStatus = "online",
                            Password = "123456",
                            RoleId = new Guid("f5b5fc8d-98ca-45c6-ad8e-2d1d1e7c08ce"),
                            UserName = "admin"
                        });
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

            modelBuilder.Entity("TelegramClone.Models.Chat", b =>
                {
                    b.Navigation("ChatUsers");
                });

            modelBuilder.Entity("TelegramClone.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("TelegramClone.Models.User", b =>
                {
                    b.Navigation("ChatUsers");

                    b.Navigation("RefreshTokens");
                });
#pragma warning restore 612, 618
        }
    }
}