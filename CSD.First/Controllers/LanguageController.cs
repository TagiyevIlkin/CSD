using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CSD.ComSciDep.Services.Interfaces;
using CSD.ComSciDep.Utility;
using CSD.Entities.Computer_Engineering;
using CSD.Entities.Shared;
using CSD.First.ViewModels;
using CSD.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;

namespace CSD.First.Controllers
{
    public class LanguageController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILanguageService _languageService;
        public LanguageController(IConfiguration configuration,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            ILanguageService languageService)
        {
            _configuration = configuration;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _languageService = languageService;
        }


        #region LanguageListForTable

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

            var model = _languageService.GetLanguageList();


            if (!string.IsNullOrEmpty(searchValue))
            {
                model = model.Where(m => m.PersonFullName == searchValue
                                         || (m.PersonFullName != null && m.PersonFullName.StartsWith(searchValue))
                                         || (m.PersonFullName != null && m.PersonFullName.StartsWith(searchValue)));
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

        #region Create Language
        [HttpGet]
        public IActionResult Create(int Id)
        {
            FinalLanguageViewModel finalLanguageViewModel = new FinalLanguageViewModel()
            {
                CurrentPerson = _unitOfWork.Repository<Personel>().GetById(Id).Fullname,
                LanguagesForPerson = _unitOfWork.Repository<LevelOfLanguage>().FindAll(x => x.PersonelId == Id),
                LanguageList = _unitOfWork.Repository<Language>().GetAll().ToList(),
                LevelList = _unitOfWork.Repository<Level>().GetAll().ToList(),
                LanguageViewModel = new LanguageViewModel()
                {
                    PersonelId = Id
                }
            };
            FillComboBox();
            return View(finalLanguageViewModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public JsonResult Create(FinalLanguageViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!_unitOfWork.Repository<LevelOfLanguage>().Exist(x => x.LanguageId == model.LanguageViewModel.LanguageId))
                {
                    var language = _mapper.Map<LevelOfLanguage>(model.LanguageViewModel);
                    var result = _unitOfWork.Repository<LevelOfLanguage>().Add(language);

                    string addedlanguage = _unitOfWork.Repository<Language>().GetById(language.LanguageId).Name;
                    string level = _unitOfWork.Repository<Level>().GetById(language.LevelId).Name;

                    if (result.IsSuccess)
                    {
                        return Json(new
                        {
                            status = 200,
                            message = CsResultConst.AddSuccess,
                            Id = language.Id,
                            Language = addedlanguage,
                            Level = level
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
                    status = 201,
                    message = CsResultConst.AleadyExistedLanguage
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

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var language = _unitOfWork.Repository<LevelOfLanguage>().GetById(Id);
            if (language == null) return NotFound();
            var languageViewModel = _mapper.Map<LanguageViewModel>(language);
            languageViewModel.PreviousPersonFullName = _unitOfWork.Repository<Personel>().GetById(language.PersonelId).Fullname;
            languageViewModel.PreviousPersonId = language.PersonelId;
            languageViewModel.PreviousLanguageId = language.LanguageId;
            FillComboBox();
            return View(languageViewModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public JsonResult Edit(LanguageViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!(_unitOfWork.Repository<LevelOfLanguage>().Exist(x => x.PersonelId == model.PersonelId && x.LanguageId == model.LanguageId || x.LanguageId != model.PreviousLanguageId)))
                {
                    var language = _mapper.Map<LevelOfLanguage>(model);
                    var result = _unitOfWork.Repository<LevelOfLanguage>().Update(language);

                    if (result.IsSuccess)
                    {
                        return Json(new
                        {
                            status = 200,
                            message = CsResultConst.EditSuccess
                        });
                    }
                }
                FillComboBox();
                return Json(new
                {
                    status = 201,
                    message = CsResultConst.AleadyExistedLanguage
                });
            }
            FillComboBox();
            return Json(new
            {
                status = 400,
                message = CsResultConst.ModelNotValid
            });
        }

        #region Delete Language
        public async Task<IActionResult> Delete(int Id)
        {
            var language = await _unitOfWork.Repository<LevelOfLanguage>().GetByIdAsync(Id);
            if (language == null) return NotFound();
            var result = await _unitOfWork.Repository<LevelOfLanguage>().DeleteAsync(language);

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
            ViewBag.LanguageId = _unitOfWork.Repository<Language>().Query().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            ViewBag.LevelId = _unitOfWork.Repository<Level>().Query().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
        }
        #endregion
    }
}