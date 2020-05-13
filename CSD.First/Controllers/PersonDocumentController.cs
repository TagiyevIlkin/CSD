using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CSD.ComSciDep.Services.Interfaces;
using CSD.ComSciDep.Utility;
using CSD.Entities.Shared;
using CSD.First.ViewModels;
using CSD.Repositories.Interfaces;
using CSD.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using static System.Net.WebRequestMethods;

namespace CSD.First.Controllers
{
    [Authorize]
    public class PersonDocumentController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPersonDocumentService _personDocumentService;
        public PersonDocumentController(IConfiguration configuration,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IPersonDocumentService personDocumentService,
            IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _personDocumentService = personDocumentService;
            _hostingEnvironment = hostingEnvironment;
        }

        #region PersonDocumentListForTable

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

            var model = _personDocumentService.GetPersonDocumentList();


            if (!string.IsNullOrEmpty(searchValue))
            {
                model = model.Where(m => m.PersonFullName == searchValue
                                         || (m.PersonFullName != null && m.PersonFullName.StartsWith(searchValue))
                                         || (m.DocumentTypeName != null && m.DocumentTypeName.StartsWith(searchValue)));
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


        #region Create PersonDocument
        [HttpGet]
        public IActionResult Create(int Id)
        {
            FinalPersonDocumentViewModel finalPersonDocumentViewModel = new FinalPersonDocumentViewModel()
            {
                DocumentsForPerson = _unitOfWork.Repository<PersonDocument>().FindAll(x => x.PersonelId == Id),
                DocumetTypeList = _unitOfWork.Repository<DocumetType>().GetAll().ToList(),
                CurrentPerson = _unitOfWork.Repository<Personel>().GetById(Id).Fullname,
                PersonDocumentViewModel = new PersonDocumentViewModel()
                {
                    PersonelId = Id
                }
            };
            FillComboBox();
            return View(finalPersonDocumentViewModel);
        }



        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public JsonResult Create(FinalPersonDocumentViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!_unitOfWork.Repository<PersonDocument>().Exist(x => x.DocumentTypeId == model.PersonDocumentViewModel.DocumentTypeId && x.PersonelId == model.PersonDocumentViewModel.PersonelId))
                {
                    if (model.PersonDocumentViewModel.File != null)
                    {
                        #region About File Create
                        //Get FileName
                        var fileName = model.PersonDocumentViewModel.File.FileName;
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Upload", "PersonDocument", DateTime.Now.Year.ToString());
                        FileMethod.CreatePath(path);
                        var uniqueFileName = FileMethod.GetUniqueFileNameMethod(fileName);
                        var uploads = Path.Combine(_hostingEnvironment.WebRootPath, path);
                        var filePath = Path.Combine(uploads, uniqueFileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            model.PersonDocumentViewModel.File.CopyTo(stream);
                        }

                        #endregion

                        if (!string.IsNullOrWhiteSpace(uniqueFileName))
                        {
                            model.PersonDocumentViewModel.Path = $"wwwroot/Upload/PersonDocument/{DateTime.Now.Year.ToString()}/{uniqueFileName}";
                            model.PersonDocumentViewModel.Name = fileName;
                        }
                        else
                        {
                            model.PersonDocumentViewModel.Path = null;
                        }

                        var personDocument = _mapper.Map<PersonDocument>(model.PersonDocumentViewModel);
                        var documentTypeName = _unitOfWork.Repository<DocumetType>().GetById(personDocument.DocumentTypeId).Name;
                        var result = _unitOfWork.Repository<PersonDocument>().Add(personDocument);
                        if (result.IsSuccess)
                        {
                            return Json(new
                            {
                                status = 200,
                                message = CsResultConst.AddSuccess,
                                Id = personDocument.Id,
                                FileName = personDocument.Name,
                                DocumentTypeName = documentTypeName
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
                        status = 202,
                        message = CsResultConst.NoFile
                    });
                }

                FillComboBox();
                return Json(new
                {
                    status = 201,
                    message = CsResultConst.AleadyExistedDocument
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

        #region Edit PersonDocument
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var personDocument = _unitOfWork.Repository<PersonDocument>().GetById(Id);
            if (personDocument == null) return NotFound();

            var personDocumentViewModelForEdit = _mapper.Map<PersonDocumentViewModelForEdit>(personDocument);
            personDocumentViewModelForEdit.PreviousPersonId = personDocument.PersonelId;
            personDocumentViewModelForEdit.PreviousPersonFullName = _unitOfWork.Repository<Personel>().GetById(personDocument.PersonelId).Fullname;
            personDocumentViewModelForEdit.PreviousFilePath = personDocument.Path;
            personDocumentViewModelForEdit.PreviousDocumentTypeId = personDocument.DocumentTypeId;
            FillComboBox();
            return View(personDocumentViewModelForEdit);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public JsonResult Edit(PersonDocumentViewModelForEdit model)
        {
            if (ModelState.IsValid)
            {
                //#region Already Existed Document
                //var count = _unitOfWork.Repository<PersonDocument>().FindAll(x => x.DocumentTypeId == model.DocumentTypeId && x.PersonelId == model.PersonelId).Count;
                //if ((count + 1) > 1)
                //{
                //    FillComboBox();
                //    return Json(new
                //    {
                //        status = 201,
                //        message = CsResultConst.AleadyExistedDocument
                //    });
                //}
                //#endregion

                #region If there is no any change

                if (model.FileForEdit == null && model.PreviousDocumentTypeId == model.DocumentTypeId && model.PreviousPersonId == model.PersonelId)
                {
                    return Json(new
                    {
                        status = 202,
                        message = CsResultConst.NoChanges
                    });
                }

                #endregion

                #region If there is change with Person Or DocumentType 
                if (!_unitOfWork.Repository<PersonDocument>().Exist(x => x.DocumentTypeId == model.DocumentTypeId && x.PersonelId == model.PersonelId && x.PersonelId != model.PreviousPersonId))
                {
                    var personDocument = _mapper.Map<PersonDocument>(model);
                    var result = _unitOfWork.Repository<PersonDocument>().Update(personDocument);
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
                #endregion

                #region If there is a new File

                if (model.FileForEdit != null)
                {
                    FileMethod.DeleteFile(model.PreviousFilePath);

                    #region About File Create

                    var fileName = model.FileForEdit.FileName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Upload", "PersonDocument", DateTime.Now.Year.ToString());
                    FileMethod.CreatePath(path);
                    var uniqueFileName = FileMethod.GetUniqueFileNameMethod(fileName);
                    var uploads = Path.Combine(_hostingEnvironment.WebRootPath, path);
                    var filePath = Path.Combine(uploads, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        model.FileForEdit.CopyTo(stream);
                    }

                    #endregion


                    if (!string.IsNullOrWhiteSpace(uniqueFileName))
                    {
                        model.Path = $"wwwroot/Upload/PersonDocument/{DateTime.Now.Year.ToString()}/{uniqueFileName}";
                        model.Name = fileName;
                    }
                    else
                    {
                        model.Path = null;
                    }

                    var personDocument = _mapper.Map<PersonDocument>(model);
                    var result = _unitOfWork.Repository<PersonDocument>().Update(personDocument);
                    if (result.IsSuccess)
                    {
                        return Json(new
                        {
                            status = 200,
                            message = CsResultConst.AddSuccess
                        });
                    }
                    FillComboBox();
                    return Json(new
                    {
                        status = 406,
                        message = CsResultConst.Error
                    });

                }
                #endregion
            }
            FillComboBox();
            return Json(new
            {
                status = 400,
                message = CsResultConst.ModelNotValid
            });
        }
        #endregion

        #region Delete PersonDocument

        public async Task<IActionResult> Delete(int Id)
        {
            var personDocument = await _unitOfWork.Repository<PersonDocument>().GetByIdAsync(Id);
            if (personDocument == null) return NotFound();

            if (personDocument.Path != null)
            {
                if (System.IO.File.Exists(personDocument.Path))
                {
                    System.IO.File.Delete(personDocument.Path);
                }
            }

            var result = await _unitOfWork.Repository<PersonDocument>().DeleteAsync(personDocument);

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

        #region Download File
        public async Task<IActionResult> DownloadFile(int Id)
        {
            var model = await _unitOfWork.Repository<PersonDocument>().GetByIdAsync(Id);
            var filepath = model.Path;

            if (!System.IO.File.Exists(filepath))
            {
                return Json(new
                {
                    status = 202,
                    message = CsResultConst.NotFoundFile
                });
            }

            var fileName = model.Name;
            byte[] fileBytes = System.IO.File.ReadAllBytes(filepath);
            return File(fileBytes, "APPLICATION/octet-stream", fileName);
        }
        #endregion

        #region Delete File

        public IActionResult DeleteFile(int Id)
        {
            var personDocument = _unitOfWork.Repository<PersonDocument>().GetById(Id);
            if (personDocument == null) return NotFound();

            if (personDocument.Path != null)
            {
                FileMethod.DeleteFile(personDocument.Path);
                personDocument.Path = null;
                personDocument.Name = "Silinib";
                var result = _unitOfWork.Repository<PersonDocument>().Update(personDocument);
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
            FillComboBox();
            return Json(new
            {
                status = 406,
                message = CsResultConst.NotFoundDeleteFile
            });
        }
        #endregion

        #region FillComboBox
        private void FillComboBox()
        {
            ViewBag.DocumentTypeId = _unitOfWork.Repository<DocumetType>().Query().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

        }
        #endregion
    }
}