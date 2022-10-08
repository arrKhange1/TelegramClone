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
            var privateCategory = new ChatCategory
            {
                ChatCategoryId = Guid.NewGuid(),
                ChatCategoryName = "private"
            };

            // group chat category
            var groupCategory = new ChatCategory
            {
                ChatCategoryId = Guid.NewGuid(),
                ChatCategoryName = "group"
            };

            var priv = modelBuilder.Entity<ChatCategory>().HasData(privateCategory);
            var group = modelBuilder.Entity<ChatCategory>().HasData(groupCategory);

            // admin
            var adminRole = new Role
            {
                RoleId = Guid.NewGuid(),
                RoleName = "admin"
            };
            // user
            var userRole = new Role
            {
                RoleId = Guid.NewGuid(),
                RoleName = "user"
            };
            var admin = modelBuilder.Entity<Role>().HasData(adminRole);
            var user = modelBuilder.Entity<Role>().HasData(userRole);

            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = Guid.NewGuid(),
                UserName = "admin",
                Password = "123456",
                ConnectionStatus = "online",
                RoleId = adminRole.RoleId
            });
            //

            modelBuilder.Entity<ChatUser>()
                .HasOne(chat => chat.Chat)
                .WithMany(cu => cu.ChatUsers)
                .HasForeignKey(cu => cu.ChatId);

            modelBuilder.Entity<ChatUser>()
                .HasOne(user => user.User)
                .WithMany(cu => cu.ChatUsers)
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


        }

        public DbSet<User> Users { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<ChatUser> ChatUsers { get; set; }
        public DbSet<ChatCategory> ChatCategories { get; set; }
        public DbSet<UserContact> UserContacts { get; set; }
    }

    

    
}
