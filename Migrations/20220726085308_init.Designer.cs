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
    [Migration("20220726085308_init")]
    partial class init
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

                    b.Property<string>("ChatName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ChatId");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("TelegramClone.Models.ChatUser", b =>
                {
                    b.Property<Guid>("ChatUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MessageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ChatUserId");

                    b.HasIndex("ChatId");

                    b.HasIndex("MessageId")
                        .IsUnique();

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
                            RoleId = new Guid("a2a23111-bc87-44de-8ca8-e13cface8c45"),
                            RoleName = "admin"
                        });
                });

            modelBuilder.Entity("TelegramClone.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

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
                            UserId = new Guid("e12b3dda-d688-43ee-a04b-28d064d4aab4"),
                            Password = "AQAAAAEAACcQAAAAEGH6iBe7yNyxLRDFBPupFqNTXl7aF++8zubImX84SBZc9kkWBJdfbVsNsTFUbJinjA==",
                            RoleId = new Guid("a2a23111-bc87-44de-8ca8-e13cface8c45"),
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("TelegramClone.Models.ChatUser", b =>
                {
                    b.HasOne("TelegramClone.Models.Chat", "Chat")
                        .WithMany("ChatUsers")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TelegramClone.Models.Message", "Message")
                        .WithOne("ChatUser")
                        .HasForeignKey("TelegramClone.Models.ChatUser", "MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TelegramClone.Models.User", "User")
                        .WithMany("ChatUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");

                    b.Navigation("Message");

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

            modelBuilder.Entity("TelegramClone.Models.Message", b =>
                {
                    b.Navigation("ChatUser");
                });

            modelBuilder.Entity("TelegramClone.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("TelegramClone.Models.User", b =>
                {
                    b.Navigation("ChatUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
