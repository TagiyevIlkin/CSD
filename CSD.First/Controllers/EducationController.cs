using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CSD.ComSciDep.Services.Interfaces;
using CSD.ComSciDep.Utility;
using CSD.Entities.Shared;
using CSD.First.ViewModels;
using CSD.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;

namespace CSD.First.Controllers
{
    [Authorize]

    public class EducationController : Controller
    {

        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEducationService _educationService;
        public EducationController(IConfiguration configuration,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IEducationService educationService)
        {
            _configuration = configuration;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _educationService = educationService;
        }


        #region EducationListForTable

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

            var model = _educationService.GetEducationLists();


            if (!string.IsNullOrEmpty(searchValue))
            {
                model = model.Where(m => m.PersonelFullName == searchValue
                                         || (m.PersonelFullName != null && m.PersonelFullName.StartsWith(searchValue))
                                         || (m.CityName != null && m.CityName.StartsWith(searchValue)));
            }
            //total number of rows count 
            recordsTotal = model.Count();
            //Paging 
            var data = model.Skip(skip).Take(pageSize).ToList();
            //Returning Json Data
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
        }

        #endregion


        public IActionResult Index()
        {
            return View();
        }

        #region Create Education

        [HttpGet]
        public IActionResult Create(int Id)
        {
            FinalEducationViewModel finalEducationViewModel = new FinalEducationViewModel()
            {
                CurrentPerson = _unitOfWork.Repository<Personel>().GetById(Id).Fullname,
                EducationsForPerson = _unitOfWork.Repository<Education>().FindAll(x => x.PersonelId == Id),
                CityLIst = _unitOfWork.Repository<City>().GetAll().ToList(),
                DocumentLIst = _unitOfWork.Repository<Document>().GetAll().ToList(),
                EducationDegreeLIst = _unitOfWork.Repository<EducationDegree>().GetAll().ToList(),
                EducationViewModel = new EducationViewModel()
                {
                    PersonelId = Id
                }


            };

            FillComboBox();

            return View(finalEducationViewModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public JsonResult Create(FinalEducationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var education = _mapper.Map<Education>(model.EducationViewModel);
                string cityName = _unitOfWork.Repository<City>().GetById(education.CityId).Name;
                string documentName = _unitOfWork.Repository<Document>().GetById(education.DocumentId).Name;
                string educationDegree = _unitOfWork.Repository<EducationDegree>().GetById(education.EducationDegreeId).Name;
                var result = _unitOfWork.Repository<Education>().Add(education);
                if (result.IsSuccess)
                {
                    return Json(new
                    {
                        status = 200,
                        message = CsResultConst.AddSuccess,
                        Id = education.Id,
                        EducationalInstitution = education.EducationalInstitution,
                        EducationDegree = educationDegree,
                        Faculty =education.Faculty,
                        Specialty=education.Specialty,
                        BeginTime=education.BeginTime.ToString("dd/MM/yyyy"),
                        EndTime = education.EndTime.ToString("dd/MM/yyyy"),
                        CityName = cityName,
                        DocumentName = documentName,


                    });
                }
                FillComboBox();

                return Json(new
                {
                    status = 406,
                    message = CsResultConst.Error
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


        #region Edit Education
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var education = _unitOfWork.Repository<Education>().GetById(Id);
            if (education == null) return NotFound();

            var educationViewModel = _mapper.Map<EducationViewModel>(education);

            educationViewModel.PreviousPersonId = education.PersonelId;
            educationViewModel.PreviousPersonFullName = _unitOfWork.Repository<Personel>().GetById(education.PersonelId).Fullname;
            FillComboBox();

            return View(educationViewModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public JsonResult Edit(EducationViewModel model)
        {

            if (ModelState.IsValid)
            {
                var education = _mapper.Map<Education>(model);
                var result = _unitOfWork.Repository<Education>().Update(education);
                if (result.IsSuccess)
                {
                    return Json(new
                    {
                        status = 200,
                        message = CsResultConst.EditSuccess
                    });
                }
                return Json(new
                {
                    status = 406,
                    message = CsResultConst.Error
                });
            }
            return Json(new
            {
                status = 400,
                message = CsResultConst.ModelNotValid
            });
        }

        #endregion

        #region FillComboBox
        private void FillComboBox()
        {
            ViewBag.DocumentId = _unitOfWork.Repository<Document>().Query().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            ViewBag.CityId = _unitOfWork.Repository<City>().Query().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            ViewBag.EducationDegreeId = _unitOfWork.Repository<EducationDegree>().Query().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
        }
        #endregion

        #region Delete Education
        public async Task<IActionResult> Delete(int Id)
        {
            var education = await _unitOfWork.Repository<Education>().GetByIdAsync(Id);
            if (education == null) return NotFound();

            var resul = await _unitOfWork.Repository<Education>().DeleteAsync(education);
            if (resul.IsSuccess)
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

    }
}