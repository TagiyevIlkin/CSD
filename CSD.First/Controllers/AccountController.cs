using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSD.Entities.Shared;
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


        public IActionResult Login()
        {
            return View();
        }
    }
}