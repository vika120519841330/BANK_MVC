using BANK_MVC_ONION_DI.Identity;
using BANK_MVC_ONION_DI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace BANK_MVC_ONION_DI.Initializer
{
    public class UserRoleDbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // создаем две роли
            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "user" };

            // добавляем роли в бд
            roleManager.Create(role1);
            roleManager.Create(role2);

            // создаем пользователей
            var admin = new ApplicationUser { Email = "vika1205@tut.by", UserName = "vika1205@tut.by" };
            string password1 = "12Vfz1984$";
            var result1 = userManager.Create(admin, password1);
            // если создание пользователя прошло успешно
            if (result1.Succeeded)
            {
                // добавляем для пользователя роли
                userManager.AddToRole(admin.Id, role1.Name);
                userManager.AddToRole(admin.Id, role2.Name);
            }

            var user = new ApplicationUser { Email = "vika120519841330@yandex.by", UserName = "vika120519841330@yandex.by" };
            string password2 = "13Fghtkz2013$";
            var result2 = userManager.Create(user, password2);

            // если создание пользователя прошло успешно
            if (result2.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(user.Id, role2.Name);
            }
            base.Seed(context);
        }
    }
}