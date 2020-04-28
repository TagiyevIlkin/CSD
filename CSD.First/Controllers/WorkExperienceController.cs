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
using Newtonsoft.Json;

namespace CSD.First.Controllers
{
    [Authorize]
    public class WorkExperienceController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWorkExperienceService _workExperienceService;
        public WorkExperienceController(IConfiguration configuration,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IWorkExperienceService workExperienceService)
        {
            _configuration = configuration;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _workExperienceService = workExperienceService;
        }




        #region WorkExperienceListForTable

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

            var model = _workExperienceService.GetWorkExperienceList();


            if (!string.IsNullOrEmpty(searchValue))
            {
                model = model.Where(m => m.PersonFullName == searchValue
                                         || (m.PersonFullName != null && m.PersonFullName.StartsWith(searchValue))
                                         || (m.Position != null && m.Position.StartsWith(searchValue)));
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

        #region Create  WorkExperience

        [HttpGet]
        public IActionResult Create(int Id)
        {
            FInalWorkExperienceViewModel fInalWorkExperienceViewModel = new FInalWorkExperienceViewModel()
            {
                WorkExperiencesForPerson = _unitOfWork.Repository<WorkExperience>().FindAll(x => x.PersonelId == Id),
                WorkExperienceViewModel = new WorkExperienceViewModel()
                {
                    PersonelId = Id
                },
                CityLIst = _unitOfWork.Repository<City>().GetAll().ToList(),
                CurrentPerson = _unitOfWork.Repository<Personel>().GetById(Id).Fullname

            };

            FillComboBox();
            return View(fInalWorkExperienceViewModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public JsonResult Create(FInalWorkExperienceViewModel model)
        {

            if (ModelState.IsValid)
            {

                var workExperience = _mapper.Map<WorkExperience>(model.WorkExperienceViewModel);
                var result = _unitOfWork.Repository<WorkExperience>().Add(workExperience);
                var cityname = _unitOfWork.Repository<City>().GetById(workExperience.CityId).Name;

                if (result.IsSuccess)
                {
                    return Json(new
                    {
                        status = 200,
                        message = CsResultConst.AddSuccess,
                        CityName = cityname,
                        Id = workExperience.Id,
                        CompanyName = workExperience.CompanyName,
                        Position = workExperience.Position,
                        JobResponsibilities = workExperience.JobResponsibilities,
                        BeginDate = workExperience.BeginDate.ToString("dd/MM/yyyy"),
                        EndTme = workExperience.EndTme.ToString("dd/MM/yyyy"),
                        AdditionalInfo = workExperience.AdditionalInfo
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

        #region Edit WorkExperience

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var workExperience = _unitOfWork.Repository<WorkExperience>().GetById(Id);
            if (workExperience == null) return NotFound();

            var workExperienceViewModel = _mapper.Map<WorkExperienceViewModel>(workExperience);

            workExperienceViewModel.PreviousPersonId = workExperience.PersonelId;
            workExperienceViewModel.PreviousPersonName = _unitOfWork.Repository<Personel>().GetById(workExperience.PersonelId).Fullname;
            FillComboBox();
            return View(workExperienceViewModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public JsonResult Edit(WorkExperienceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var workExperience = _mapper.Map<WorkExperience>(model);
                var result = _unitOfWork.Repository<WorkExperience>().Update(workExperience);
                if (result.IsSuccess)
                {
                    return Json(new
                    {
                        status = 200,
                        message = CsResultConst.EditSuccess
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

        #region Delete WorkExperience

        public async Task<IActionResult> Delete(int Id)
        {
            var workExperience = await _unitOfWork.Repository<WorkExperience>().GetByIdAsync(Id);
            if (workExperience == null) return NotFound();

            var reult = await _unitOfWork.Repository<WorkExperience>().DeleteAsync(workExperience);
            if (reult.IsSuccess)
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
                Value = x.Id.ToString()
            });
        }
        #endregion
    }
}