using BANK_MVC_ONION_DI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BANK_MVC_ONION_DI.Identity
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
           
        }
        //public DbSet<ApplicationUser> AspNetUsers { get; set; }
        //public DbSet<IdentityRole> AspNetRoles { get; set; }

        
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
            //modelBuilder.Entity<IdentityRole>()
            //    .ToTable("AspNetRoles")
            //    .HasKey(_ => _.Id)
            //    ;

            //modelBuilder.Entity<ApplicationUser>()
            //    .ToTable("AspNetUsers")
            //    .HasKey(_ => _.Id)
            //    ;


            //var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(this));

            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(this));

            //// создаем две роли
            //var role1 = new IdentityRole { Name = "admin" };
            //var role2 = new IdentityRole { Name = "user" };

            //// добавляем роли в бд
            //roleManager.Create(role1);
            //roleManager.Create(role2);

            //// создаем пользователей
            //var admin = new ApplicationUser { Email = "vika12@tut.by", UserName = "vika12@tut.by" };
            //string password1 = "12Vfz1984$";
            //var result1 = userManager.Create(admin, password1);
            //// если создание пользователя прошло успешно
            //if (result1.Succeeded)
            //{
            //    // добавляем для пользователя роли
            //    userManager.AddToRole(admin.Id, role1.Name);
            //    userManager.AddToRole(admin.Id, role2.Name);
            //}

            //var user = new ApplicationUser { Email = "vika12345@yandex.by", UserName = "vika12345@yandex.by" };
            //string password2 = "13Fghtkz2013$";
            //var result2 = userManager.Create(user, password2);

            //// если создание пользователя прошло успешно
            //if (result2.Succeeded)
            //{
            //    // добавляем для пользователя роль
            //    userManager.AddToRole(user.Id, role2.Name);
            //}
            //base.OnModelCreating(modelBuilder);
        //}
    }
}