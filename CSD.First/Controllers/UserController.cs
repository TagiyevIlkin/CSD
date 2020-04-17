using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CSD.ComSciDep.Utility;
using CSD.Entities.Shared;
using CSD.First.ViewModels;
using CSD.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;

namespace CSD.First.Controllers
{
    public class UserController : Controller
    {


        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<UserApp> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public UserController(IConfiguration configuration, IMapper mapper, IUnitOfWork unitOfWork,
            UserManager<UserApp> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _configuration = configuration;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _roleManager = roleManager;
        }


        #region Create User

        [HttpGet]
        public IActionResult Create(int id)
        {
            UserViewModel model = new UserViewModel();

            List<SelectListItem> list = new List<SelectListItem>();

            foreach (var role in _roleManager.Roles)
            {
                list.Add(new SelectListItem() { Value = role.Name, Text = role.Name });
            }

            ViewBag.Roles = list;
            model.PersonelId = id;

            return PartialView("_Create", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Create(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_userManager.Users.FirstOrDefault(u => u.UserName != model.Username) != null)
                {
                    var user = new UserApp()
                    {
                        UserName = model.Username,
                        Status = model.Status,
                        PersonelId = model.PersonelId
                    };
                    IdentityResult userInsertResult = await _userManager.CreateAsync(user, model.Password);

                    if (userInsertResult.Succeeded)
                    {
                        var roleNames = model.GetRoles ?? new List<string>();

                        foreach (var roleName in roleNames)
                        {
                            if (!await _userManager.IsInRoleAsync(user, roleName))
                            {
                                try
                                {
                                    await _userManager.AddToRoleAsync(user, roleName);

                                }
                                catch (Exception ex)
                                {

                                }
                            }
                        }

                        return Json(new { status = 200, message = CsResultConst.AddSuccess });
                    }

                    foreach (var error in userInsertResult.Errors.ToList())
                    {
                        return Json(new
                        {
                            status = 406,
                            message = error
                        });

                    }
                }
                return Json(new { status = 207, message = CsResultConst.AleadyTakenUsername });
            }

            return Json(new { status = 407, message = CsResultConst.ModelNotValid });
        }
        #endregion

        #region EditUser
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            UserApp user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return Json(new { status = 404, message = CsResultConst.NotFoundUser });
            }

            List<SelectListItem> list = new List<SelectListItem>();
            List<string> selectedRoles = new List<string>();

            foreach (var role in _roleManager.Roles)
            {
                list.Add(new SelectListItem() { Value = role.Name, Text = role.Name });
            }


            foreach (var role in _roleManager.Roles)
            {
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    selectedRoles.Add(role.Name);
                }
            }

            ViewBag.Roles = list;


            UserEditViewModel model = new UserEditViewModel();
            model.Id = user.Id;
            model.PersonelId = user.PersonelId;
            model.Username = user.UserName;
            model.Status = user.Status;
            model.GetRoles = selectedRoles;
            return PartialView("_Edit", model); ;
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Edit([Bind(include: "Id , PersonelId , PasswordEdit , GetRoles , Status ,Username ")]UserEditViewModel model)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var role in _roleManager.Roles)
            {
                list.Add(new SelectListItem() { Value = role.Name, Text = role.Name });
            }
            if (ModelState.IsValid)
            {
                if (!_userManager.Users.Any(u => u.UserName == model.Username && u.Id != model.Id))
                {
                    UserApp userdb = await _userManager.FindByIdAsync(model.Id);

                    if (userdb == null)
                    {
                        return Json(new
                        {
                            status = 404,
                            message = "User Null"
                        });
                    }

                    userdb.UserName = model.Username;
                    userdb.Status = model.Status;
                    if (!string.IsNullOrEmpty(model.PasswordEdit))
                    {
                        userdb.PasswordHash = _userManager.PasswordHasher.HashPassword(userdb, model.PasswordEdit);
                    }

                    IdentityResult editUserResult = await _userManager.UpdateAsync(userdb);

                    if (editUserResult.Succeeded)
                    {
                        var roleNames = model.GetRoles ?? new List<string>();

                        IEnumerable<string> selectedRoles = roleNames;
                        IEnumerable<string> unSelectedRoles = _roleManager.Roles.Select(n => n.Name).Except(roleNames);

                        //selected role
                        foreach (var roleName in selectedRoles.ToList())
                        {
                            if (!await _userManager.IsInRoleAsync(userdb, roleName))
                            {
                                await _userManager.AddToRoleAsync(userdb, roleName);
                            }
                        }

                        //unSelectedRole
                        foreach (var roleName in unSelectedRoles.ToList())
                        {
                            if (await _userManager.IsInRoleAsync(userdb, roleName))
                            {
                                await _userManager.RemoveFromRoleAsync(userdb, roleName);
                            }
                        }


                        return Json(new { status = 200, message = CsResultConst.EditSuccess });
                    }
                    return Json(new { status = 406, message = CsResultConst.Error });
                }
                return Json(new { status = 207, message = CsResultConst.AleadyTakenUsername });
            }
            return Json(new { status = 407, message = CsResultConst.ModelNotValid });
        }
        #endregion

        #region Delete User

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return Json(new
                {
                    status = 404,
                    message = "ID null"
                });
            }

            var model = await _userManager.FindByIdAsync(id);
            if (model == null)
            {
                return Json(new
                {
                    status = 404,
                    message = "User null"
                });
            }

            IdentityResult result = await _userManager.DeleteAsync(model);

            if (result.Succeeded)
            {
                return Json(new { status = 200, message = CsResultConst.DeleteSuccess });
            }

            foreach (var error in result.Errors.ToList())
            {
                return Json(new
                {
                    status = 406,
                    message = error
                });
            }

            return Json(new { status = 406, message = CsResultConst.Error });
        }

        #endregion
    }
}