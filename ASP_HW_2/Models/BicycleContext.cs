using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_HW_2.Models
{
    public class BicycleContext:DbContext
    {
        public DbSet<Bicycle> Bicycles { get; set; }
        public DbSet<Order> Orders { get; set; }
        //public DbSet<User> Users { get; set; }
        //public DbSet<Role> Roles { get; set; }

        public BicycleContext(DbContextOptions<BicycleContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    string superAdmin = "superAdmin";
        //    string adminRole = "admin";
        //    string userRole = "user";

        //    string superAdminLogin = "superAdmin@gmail.com";
        //    string superAdminPassword = "superAdmin";

        //    string adminLogin = "admin@gmail.com";
        //    string adminPassword = "admin";

        //    string userLogin = "user@gmail.com";
        //    string userPassword = "user";

        //    Role sAdmin = new Role { RoleId = 1, Name = superAdmin };
        //    Role admin = new Role { RoleId = 2, Name = adminRole };
        //    Role user = new Role { RoleId = 3, Name = userRole };

        //    User superAdminUser = new User
        //    {
        //        Email = superAdminLogin,
        //        Password = superAdminPassword,
        //        RoleId = sAdmin.RoleId
        //    };

        //    User adminUser = new User
        //    {
        //        UserId = 2,
        //        Email = adminLogin,
        //        Password = adminPassword,
        //        RoleId = admin.RoleId
        //    };

        //    User userUser = new User
        //    {
        //        UserId = 3,
        //        Email = userLogin,
        //        Password = userPassword,
        //        RoleId = user.RoleId
        //    };

        //    modelBuilder.Entity<Role>().HasData(new Role[] { sAdmin, admin, user });
        //    modelBuilder.Entity<User>().HasData(new User[] { superAdminUser, adminUser, userUser });
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
