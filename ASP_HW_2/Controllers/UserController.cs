using ASP_HW_2.Models;
using ASP_HW_2.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ASP_HW_2.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]

        public async Task<IActionResult> UserEdit()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            ViewBag.UserId = user.Id;
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> UserEdit(UserChangePassword model)
        {
            ViewBag.UserId = model.UserId;

            if (ModelState.IsValid)
            {
                var user = await userManager.FindByIdAsync(model.UserId);

                if (await userManager.CheckPasswordAsync(user, model.OldPassword)){

                    var passwordValidator = new PasswordValidator<User>();
                    var result = await passwordValidator.ValidateAsync(userManager, user, model.NewPassword);
                    if (result.Succeeded)
                    {
                        await userManager.RemovePasswordAsync(user);
                        await userManager.AddPasswordAsync(user, model.NewPassword);

                        ViewBag.Message = "Password was successfully changed";
                        
                        return View();
                    }
                    else
                    {
                        ModelState.AddModelError("NewPassword", result.Errors.FirstOrDefault().Description);
                    }

                }
                else
                {
                    ModelState.AddModelError("OldPassword", "Such password is uncorrect");
                }
            }

            return View(model);
        }
    }
}
