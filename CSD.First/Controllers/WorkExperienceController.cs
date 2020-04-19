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
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;

namespace CSD.First.Controllers
{
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
        public IActionResult Create()
        {

            FillComboBox();
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public JsonResult Create(WorkExperienceViewModel model)
        {

            if (ModelState.IsValid)
            {

                var workExperience = _mapper.Map<WorkExperience>(model);
                var result = _unitOfWork.Repository<WorkExperience>().Add(workExperience);
                if (result.IsSuccess)
                {
                    return Json(new
                    {
                        status = 200,
                        message = CsResultConst.AddSuccess
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
            var workExperience = _unitOfWork.Repository<WorkExperience>();

            return View();
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