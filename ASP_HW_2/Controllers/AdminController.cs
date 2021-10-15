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

                    return RedirectToAction("Users");
                }
                else
                {
                    ModelState.AddModelError("Email", "Such email is already registered");
                }
            }
            ViewBag.Roles = roleManager.Roles.ToList();
            return View(model);
        }

        public async Task<IActionResult> Users()
        {
           
            var superAdmin = await userManager.GetUsersInRoleAsync("SuperAdmin");

            var users = userManager.Users.ToList().Where( x => !superAdmin.Contains(x));

            return View(users);
        }

        [HttpPost]
 
        public async Task<IActionResult> DeleteUser(string userId)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByIdAsync(userId);
                await userManager.DeleteAsync(user);
            }

            return RedirectToAction("Users");
        }


        [HttpGet]
        public async Task<IActionResult> EditUser(string userId)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByIdAsync(userId);
             
                var userRole = await userManager.GetRolesAsync(user);

                var userView = new EditUserInfoViewModel
                {
                    UserName = user.UserName,
                    UserId = user.Id,
                    RoleName = userRole.ToList().FirstOrDefault(),
                    Email = user.Email
                };

                ViewBag.Roles = roleManager.Roles.ToList().Where(x => x.Name != "SuperAdmin");

                return View(userView);
            }

            return View("Users");
        }

        [HttpPost]

        public async Task<IActionResult> EditUser(EditUserInfoViewModel userInfo)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByIdAsync(userInfo.UserId);
                user.UserName = userInfo.UserName;
                user.Email = userInfo.Email;
                await userManager.UpdateAsync(user);

                var role = await roleManager.FindByNameAsync(userInfo.RoleName);

                var currentRoles = await userManager.GetRolesAsync(user);
                await userManager.RemoveFromRolesAsync(user, currentRoles.ToList());
                await userManager.AddToRoleAsync(user, await roleManager.GetRoleNameAsync(role));

                if(userInfo.Password != null)
                {

                    var passwordValidator = new PasswordValidator<User>();
                    var result = await passwordValidator.ValidateAsync(userManager, user, userInfo.Password);
                    if (result.Succeeded)
                    {
                        await userManager.RemovePasswordAsync(user);
                        await userManager.AddPasswordAsync(user, userInfo.Password);
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Such password format isn`t valid");

                        ViewBag.Roles = roleManager.Roles.ToList().Where(x => x.Name != "SuperAdmin");
                        return View("EditUser", userInfo);
                    }

                }

                return RedirectToAction("Users");
            }

            ViewBag.Roles = roleManager.Roles.ToList().Where(x => x.Name != "SuperAdmin");
            return View("EditUser", userInfo);
        }
    }
}
