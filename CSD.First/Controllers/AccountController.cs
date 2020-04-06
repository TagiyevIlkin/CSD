using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSD.ComSciDep.Utility;
using CSD.Entities.Shared;
using CSD.First.ViewModels;
using CSD.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CSD.First.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<UserApp> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<UserApp> _signInManager;

        public AccountController(
            SignInManager<UserApp> signInManager,
            UserManager<UserApp> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }


        #region Login

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = await _userManager.FindByNameAsync(model.Username);

            if (user == null)
            {
                ModelState.AddModelError("", CsResultConst.UserNull);
                return View(model);
            }

            if (user.Status == false)
            {
                ModelState.AddModelError("", CsResultConst.Blocked);

                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(user,
                                                                  model.Password,
                                                                  model.RememberMe,
                                                                  true);
            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", CsResultConst.LockedOut);
                return View(model);
            }
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", CsResultConst.UsernameorPassWrong);
            return View(model);
        }
        #endregion

        #region logout

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("login", "Account");
        }

        #endregion

        public IActionResult AccessDenied()
        {
            return View();
        }


        public IActionResult Register()
        {

            return View();
        }
    }
}