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

            // admin
            var adminRole = new Role
            {
                RoleId = Guid.NewGuid(),
                RoleName = "admin"
            };
            var admin = modelBuilder.Entity<Role>().HasData(adminRole);

            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = Guid.NewGuid(),
                UserName = "admin",
                Password = "123456",
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



        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<ChatUser> ChatUsers { get; set; }
    }

    

    
}
