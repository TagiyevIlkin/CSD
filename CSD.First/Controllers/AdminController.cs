using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSD.ComSciDep.Utility;
using CSD.Entities.Shared;
using CSD.First.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CSD.First.Controllers
{
    public class AdminController : Controller
    {

        private readonly UserManager<UserApp> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<UserApp> _signInManager;

        public AdminController(
            SignInManager<UserApp> signInManager,
            UserManager<UserApp> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
         
            return View();
        }
        #region Login

        public IActionResult LoginAdminPanel()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginAdminPanel(LoginViewModel model)
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
                return RedirectToAction("Index", "Admin");
            }

            ModelState.AddModelError("", CsResultConst.UsernameorPassWrong);
            return View(model);
        }
        #endregion


        #region logout

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdminLogout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("LoginAdminPanel", "Admin");
        }

        #endregion

        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}