using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramClone.Models;

namespace TelegramClone.Data
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            //Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // private chat category
            var privateCategory = new ChatCategory("private");

            // group chat category
            var groupCategory = new ChatCategory("group");

            var priv = modelBuilder.Entity<ChatCategory>().HasData(privateCategory);
            var group = modelBuilder.Entity<ChatCategory>().HasData(groupCategory);

            // admin
            var adminRole = new Role("admin");
            // user
            var userRole = new Role("user");
            
            var admin = modelBuilder.Entity<Role>().HasData(adminRole);
            var user = modelBuilder.Entity<Role>().HasData(userRole);

            modelBuilder.Entity<User>().HasData(new User("admin", BCrypt.Net.BCrypt.HashPassword("12345678"), adminRole.RoleId));

            modelBuilder.Entity<GroupChatMessageType>().HasData(new GroupChatMessageType("message"));

            modelBuilder.Entity<GroupChatMessageType>().HasData(new GroupChatMessageType("notification"));

            modelBuilder.Entity<GroupChatUser>()
                .HasOne(chat => chat.GroupChat)
                .WithMany(cu => cu.GroupChatUsers)
                .HasForeignKey(cu => cu.GroupChatId);

            modelBuilder.Entity<GroupChatUser>()
                .HasOne(user => user.User)
                .WithMany(cu => cu.GroupChatUsers)
                .HasForeignKey(cu => cu.UserId);

            modelBuilder.Entity<UserContact>()
                .HasOne(user => user.User)
                .WithMany(uc => uc.UserContactsUsers)
                .HasForeignKey(uc => uc.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserContact>()
                .HasOne(contact => contact.Contact)
                .WithMany(uc => uc.UserContactsContacts)
                .HasForeignKey(uc => uc.ContactId)
                .OnDelete(DeleteBehavior.NoAction);
            
            modelBuilder.Entity<PrivateChat>()
                .HasOne(member => member.FirstParticipant)
                .WithMany(uc => uc.PrivateChatsFirstParticipants)
                .HasForeignKey(uc => uc.FirstParticipantId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PrivateChat>()
                .HasOne(member => member.SecondParticipant)
                .WithMany(uc => uc.PrivateChatsSecondParticipants)
                .HasForeignKey(uc => uc.SecondParticipantId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PrivateChat>()
                .HasOne(dm => dm.LastMessage)
                .WithOne(m => m.PrivateChat)
                .HasForeignKey<PrivateChat>(d => d.LastMessageId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<GroupChat>()
                .HasOne(c => c.LastMessage)
                .WithOne(m => m.GroupChat)
                .HasForeignKey<GroupChat>(c => c.LastMessageId)
                .OnDelete(DeleteBehavior.NoAction);


        }

        public DbSet<User> Users { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<GroupChatMessage> GroupChatMessages { get; set; }
        public DbSet<GroupChatMessageType> GroupChatMessageTypes { get; set; }
        public DbSet<GroupChat> GroupChats { get; set; }
        public DbSet<GroupChatUser> GroupChatUsers { get; set; }
        public DbSet<ChatCategory> ChatCategories { get; set; }
        public DbSet<UserContact> UserContacts { get; set; }
        public DbSet<PrivateChat> PrivateChats { get; set; }
        public DbSet<PrivateChatMessage> PrivateChatMessages { get; set; }
    }

    

    
}
