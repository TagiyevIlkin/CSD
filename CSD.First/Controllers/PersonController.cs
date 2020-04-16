using AutoMapper;
using CSD.First.ViewModels;
using CSD.Repositories.Interfaces;
using CSD.Entities.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CSD.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using CSD.First.Helper;
using CSD.ComSciDep.Services.Interfaces;
using CSD.ComSciDep.Utility;
using static CSD.Utility.Enum;

namespace CSD.First.Controllers
{
    public class PersonController : Controller
    {

        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPersonService _personService;
        public PersonController(IConfiguration configuration,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IPersonService personService, IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _personService = personService;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }


        #region PersonListForTable

        public IActionResult LoadDataForTable()
        {
            var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
            // Skiping number of Rows count
            var start = Request.Form["start"].FirstOrDefault();
            // Paging Length 10,20
            var length = Request.Form["length"].FirstOrDefault();
            // Sort Column Name
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"]
                .FirstOrDefault();
            // Sort Column Direction ( asc ,desc)
            var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
            // Search Value from (Search box)
            var searchValue = Request.Form["search[value]"].FirstOrDefault();

            //Paging Size (10,20,50,100)
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;

            var model = _personService.GetUserPersonList();


            if (!string.IsNullOrEmpty(searchValue))
            {
                model = model.Where(m => m.Fullname == searchValue
                                         || (m.Fullname != null && m.Fullname.StartsWith(searchValue))
                                         || (m.UserName != null && m.UserName.StartsWith(searchValue)));
            }


            //total number of rows count 
            recordsTotal = model.Count();
            //Paging 
            var data = model.Skip(skip).Take(pageSize).ToList();
            //Returning Json Data
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
        }

        #endregion


        #region Create Person
        [HttpGet]
        public IActionResult Create()
        {

            FillComboBox();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Create(PersonViewModel model)
        {

            if (ModelState.IsValid)
            {

                if (!_unitOfWork.Repository<Personel>().Exist(p =>
                    p.FinCode == model.FinCode))
                {
                    if (!_unitOfWork.Repository<Personel>().Exist(p =>
                        p.SerialNumber == model.SerialNumber))
                    {

                        var personel = _mapper.Map<Personel>(model);

                        _unitOfWork.Repository<Personel>().AddUnCommitted(personel);


                        #region Personel Phones

                        List<PersonPhone> personPhones = new List<PersonPhone>();

                        if (model.Home != null)
                        {
                            personPhones.Add(new PersonPhone()
                            {
                                PersonelId = personel.Id,
                                PhoneTypeId = (int)EPhoneType.Home,
                                CountryId = (int)ECountry.Aze,
                                Number = model.Home,
                            });
                        }

                        if (model.Work != null)
                        {
                            personPhones.Add(new PersonPhone()
                            {
                                PersonelId = personel.Id,
                                PhoneTypeId = (int)EPhoneType.Work,
                                CountryId = (int)ECountry.Aze,
                                Number = model.Work
                            });
                        }

                        if (model.Mobile != null)
                        {
                            personPhones.Add(new PersonPhone()
                            {
                                PersonelId = personel.Id,
                                PhoneTypeId = (int)EPhoneType.Mobile,
                                CountryId = (int)ECountry.Aze,
                                Number = model.Mobile
                            });
                        }

                        _unitOfWork.Repository<PersonPhone>().AddRangeUnCommitted(personPhones);

                        var result =await _unitOfWork.Commit();
                        if (result.IsSuccess)
                        {
                            return Json(new
                            {
                                personelId = personel.Id,
                                status = 200,
                                message = CsResultConst.OperationSuccessed
                            });
                        }
                        _unitOfWork.Rollback();
                        FillComboBox();

                        return Json(new
                        {
                            status = 404,
                            message = CsResultConst.Error
                        });

                        #endregion

                    }
                    FillComboBox();

                    return Json(new
                    {
                        status = 201,
                        message = CsResultConst.AleadyHaveSerialNumber
                    });
                }

                FillComboBox();

                return Json(new
                {
                    status = 201,
                    message = CsResultConst.AleadyHaveFinNumber
                });
            }
            FillComboBox();

            return Json(new
            {
                status = 400,
                message = CsResultConst.ModelNotValid
            });
        }
        #endregion

        #region DeletePerson
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedPerson = await _unitOfWork.Repository<Personel>().GetByIdAsync(id);
            if (deletedPerson == null)
            {
                return NotFound();
            }

            var result = await _unitOfWork.Repository<Personel>().DeleteAsync(deletedPerson);

            if (result.IsSuccess)
            {
                return Json(new
                {
                    status = 200,
                    message = CsResultConst.DeleteSuccess
                });
            }
            return Json(new
            {
                status = 406,
                message = CsResultConst.Error
            });

        }

        #endregion


        #region FillComboBox
        private void FillComboBox()
        {
            ViewBag.CityId = _unitOfWork.Repository<City>().Query().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            });

            ViewBag.GenderId = _unitOfWork.Repository<Gender>().Query().Select(x => new SelectListItem
            {
                Text = x.Type,
                Value = x.Id.ToString()
            });

            ViewBag.FamilyStatusId = _unitOfWork.Repository<FamilyStatus>().Query().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
        }
        #endregion

    }
}