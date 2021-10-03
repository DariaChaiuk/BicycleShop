using ASP_HW_2.Models;
using ASP_HW_2.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_HW_2.Controllers
{
    [Authorize (Roles = "Admin, SuperAdmin")]
    public class AdminController : Controller
    {
        BicycleContext context;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        int itemsOnPage = 10;

        public AdminController(BicycleContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public IActionResult Index(int? page)
        {
            if (page == null || page < 0)
            {
                page = 0;
            }
            var bicycles = context.Bicycles.ToList();
            ViewBag.page = page;
            ViewBag.IsFinished = false;
            if ((int)page * itemsOnPage < bicycles.Count && (page * itemsOnPage + itemsOnPage) < bicycles.Count)
            {
                var futureDiff = bicycles.Count - ((page + 1) * itemsOnPage);
                if (futureDiff <= 0)
                {
                    ViewBag.IsFinished = true;
                }
                return View(bicycles.GetRange((int)(page * 10), itemsOnPage));
            }
            var diff = bicycles.Count - (page * itemsOnPage);
            if (diff > 0)
            {
                ViewBag.IsFinished = true;
                return View(bicycles.GetRange((int)(page * 10), (int)diff));
            }

            return View(bicycles.GetRange((int)(page * 10), itemsOnPage));
        }

        public IActionResult Delete(int bicycleId)
        {
            var bicycle = context.Bicycles.Find(bicycleId);
            context.Bicycles.Remove(bicycle);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create(int? bicycleId)
        {
            if (bicycleId == null)
            {
                return View();
            }
            else
            {
                var bicycle = context.Bicycles.FirstOrDefault(x => x.BicycleId == bicycleId);
                return View(bicycle);
            }
        }

        [HttpPost]
        public IActionResult Create(Bicycle bicycle)
        {

            if (ModelState.IsValid)
            {
                if (bicycle.BicycleId == 0)
                {
                    context.Add(bicycle);
                }
                else
                {
                    context.Update(bicycle);
                }
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(bicycle);
            }
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            var roles = roleManager.Roles.ToList();
            ViewBag.Roles = roles;
            return View();
        }

        [HttpPost]
        async public Task<IActionResult> AddUser(AddUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!userManager.Users.ToList().Exists(x => x.Email == model.Email))
                {
                    var newUser = new User
                    {
                        UserName = model.UserName,
                        Email = model.Email
                    };
                    var result = await userManager.CreateAsync(newUser, model.Password);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(await userManager.FindByEmailAsync(model.Email), model.RoleName);
                    }

                    return RedirectToAction("EditUserRole");
                }
                else
                {
                    ModelState.AddModelError("Email", "Such email is already registered");
                }
            }
            ViewBag.Roles = roleManager.Roles.ToList();
            return View(model);
        }

        public async Task<IActionResult> EditUserRole()
        {
            var users = userManager.Users.ToList();
            var result = new List<UserRole>();
            foreach (var user in users)
            {
                var userRoles = await userManager.GetRolesAsync(user);
                if (!userRoles.ToList().Exists(x => x == "SuperAdmin"))
                {
                    result.Add(new UserRole
                    {
                        UserId = user.Id,
                        UserName = user.UserName,
                        Email = user.Email,
                        RoleName = userRoles.ToList()[0]
                    });
                }
            }
            var roles = roleManager.Roles.Where(x => x.Name != "SuperAdmin");

            var model = new EditUsersViewModel {
    
                Users = result,
                Roles = roles
            };

            return View(model);
        }

        [HttpPost]
 
        public async Task<IActionResult> DeleteUser(string userId)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByIdAsync(userId);
                await userManager.DeleteAsync(user);
            }

            return RedirectToAction("EditUserRole");
        }

        [HttpPost]
        public async Task<IActionResult> EditUserRole(string userId, string roleId)
        {
            if (ModelState.IsValid)
            {
               var user = await userManager.FindByIdAsync(userId);
               var role = await roleManager.FindByIdAsync(roleId);

               var currentRoles = await userManager.GetRolesAsync(user);
               await userManager.RemoveFromRolesAsync(user, currentRoles.ToList());
               await userManager.AddToRoleAsync(user,await roleManager.GetRoleNameAsync(role));
            }

            return RedirectToAction("EditUserRole");
        }
    }
}
