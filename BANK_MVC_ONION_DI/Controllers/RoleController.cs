using BANK_MVC_ONION_DI.Identity;
using BANK_MVC_ONION_DI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BANK_MVC_ONION_DI.Services
{
    public class RoleController : Controller
    {
        private ApplicationUserManager userManager;
        private IAuthenticationManager authenticationManager;
        private RoleManager<IdentityRole> roleManager;

        public RoleController(ApplicationUserManager userManager,
                            IAuthenticationManager authenticationManager,
                            RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.authenticationManager = authenticationManager;
            this.roleManager = roleManager;
        }

        //"Role management" стартовая страница
        [Authorize(Roles = "admin")]
        public ActionResult AllRoles()
        {
            Dictionary<string, List<string>> rolesANDusers = new Dictionary<string, List<string>>();
            var allUsers = userManager.Users.ToList();
            foreach (var user in allUsers)
            {
                List<string> allRoles = userManager.GetRoles(user.Id).ToList();
                List<string> allRolesOfUser = new List<string>();
                
                foreach (string role in allRoles)
                {
                    if (!rolesANDusers.ContainsKey(user.UserName))
                    {
                        allRolesOfUser.Add(role);
                        rolesANDusers.Add(user.UserName, allRolesOfUser);
                    }
                    else
                    {
                        rolesANDusers[user.UserName].Add(", ");
                        rolesANDusers[user.UserName].Add(role);
                    }
                    ViewBag.UserId = user.Id;
                }
            }
            ViewBag.Header = "СПИСОК ВСЕХ ЗАРЕГИСТРИРОВАННЫХ ПОЛЬЗОВАТЕЛЕЙ И ИХ РОЛЕЙ:";
            return View(rolesANDusers);
        }

        //Добавление для пользователя новой роли - по логину пользователя
        // GET: /Manage/AddNewRole
        public ActionResult AddNewRole_Get()
        {
            ViewBag.TODO = "ДОБАВЛЕНИЕ НОВОЙ РОЛИ ДЛЯ ЗАРЕГИСТРИРОВАННОГО ПОЛЬЗОВАТЕЛЯ";
            return View("AddNewRole_Get");
        }

        // POST: /Manage/AddNewRole
        [HttpPost]
        //[ValidateAntiForgeryToken]
        //[Authorize(Roles = "admin")]
        public ActionResult AddNewRole_Post(string login, string role)
        {
            ViewBag.TODO = "ДОБАВЛЕНИЕ НОВОЙ РОЛИ ДЛЯ ЗАРЕГИСТРИРОВАННОГО ПОЛЬЗОВАТЕЛЯ";
            var foundUser = userManager.FindByName(login);
            if (foundUser == null)
            {
                ViewBag.Result = "Пользователь с таким логином не зарегистрирован!!";
                return View("AddNewRole_Post");
            }
            // проверить - возможно у запрашиваемого пользователя уже есть эта роль
            //if (userManager.Users.i.IsInRole(role))
            //{
            //    ViewBag.Result = "Пользователь уже наделен правами запрашиваемой роли!!";
            //    return View("AddNewRole_Post", ViewBag.Result);
            //}
            var foundRole = roleManager.FindByName(role);
            if (foundRole == null)
            {
                ViewBag.Result = "Роль с таким наименованием не зарегистрирована!!";
                return View("AddNewRole_Post");
            }
            else
            {
                const int num = 0;
                ViewBag.Num = num;
                userManager.AddToRole(foundUser.Id, role);
                IList<IdentityUserRole> listOfRolesOfUser = foundUser.Roles.ToList();
                ViewBag.listofrolesofuser = listOfRolesOfUser;
                ViewBag.Result = $"Пользователь с логином: {foundUser.UserName}\0\0 обладает следующими ролями:";
                return View("AddNewRole_Success");
            }
        }
    }
}