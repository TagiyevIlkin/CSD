using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSD.Entities.Shared;
using CSD.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CSD.First.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<UserApp> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly SignInManager<UserApp> _signInManager;

        public AccountController(IUnitOfWork unitOfWork,
            SignInManager<UserApp> signInManager,
            UserManager<UserApp> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            _unitOfWork = unitOfWork;
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