using System;
using System.Collections.Generic;
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
using Microsoft.Extensions.Configuration;

namespace CSD.First.Controllers
{
    [Authorize]
    public class LabController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILabService _labService;
        public LabController(
            IMapper mapper,
            IUnitOfWork unitOfWork,
            ILabService labService,
            IConfiguration configuration,
            IHostingEnvironment hostingEnvironment)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _labService = labService;
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }


        #region LabListForTable

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

            var model = _labService.GetLabList();

            if (!string.IsNullOrEmpty(searchValue))
            {
                model = model.Where(m => m.AdditionalInfo == searchValue
                                         || (m.AdditionalInfo != null && m.AdditionalInfo.StartsWith(searchValue))
                                         || (m.RoomNumber != null && m.RoomNumber.StartsWith(searchValue)));
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


        #region Create Lab
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Create(LaboratoryViewModel model)
        {

            if (ModelState.IsValid)
            {
                if (!_unitOfWork.Repository<Laboratory>().Exist(x => x.RoomNumber.Trim() == model.RoomNumber.Trim()))
                {
                    if (model.Picture != null)
                    {
                        #region About File Create
                        //Get FileName
                        var fileName = model.Picture.FileName;
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Upload", "Laboratory", DateTime.Now.Year.ToString());
                        FileMethod.CreatePath(path);
                        var uniqueFileName = FileMethod.GetUniqueFileNameMethod(fileName);
                        var uploads = Path.Combine(_hostingEnvironment.WebRootPath, path);
                        var filePath = Path.Combine(uploads, uniqueFileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            model.Picture.CopyTo(stream);
                        }

                        #endregion

                        if (!string.IsNullOrWhiteSpace(uniqueFileName))
                        {
                            model.PicturePath = $"wwwroot/Upload/Laboratory/{DateTime.Now.Year.ToString()}/{uniqueFileName}";
                            model.PictureName = fileName;
                        }
                        else
                        {
                            model.PicturePath = null;
                        }

                        var lab = _mapper.Map<Laboratory>(model);
                        var result = _unitOfWork.Repository<Laboratory>().Add(lab);
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
                        status = 202,
                        message = CsResultConst.NoFile
                    });
                }
                return Json(new
                {
                    status = 202,
                    message = CsResultConst.AleadyExistedLaboratory
                });
            }
            return Json(new
            {
                status = 400,
                message = CsResultConst.ModelNotValid
            });
        }
        #endregion

        #region Edit Lab
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var lab = _unitOfWork.Repository<Laboratory>().GetById(Id);
            if (lab == null) return NotFound();
            var editLabViewModel = _mapper.Map<EditLaboratoryViewModel>(lab);
            editLabViewModel.PreviousPicturePath = lab.PicturePath;
            return View(editLabViewModel);
        }

        [HttpPost]
        public JsonResult Edit(EditLaboratoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!_unitOfWork.Repository<Laboratory>().Exist(x => x.RoomNumber.Trim() == model.RoomNumber.Trim() && x.Id != model.Id))
                {

                    if (model.PictureForEdit != null)
                    {
                        #region About File Create
                        //Get FileName
                        var fileName = model.PictureForEdit.FileName;
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Upload", "Laboratory", DateTime.Now.Year.ToString());
                        FileMethod.CreatePath(path);
                        var uniqueFileName = FileMethod.GetUniqueFileNameMethod(fileName);
                        var uploads = Path.Combine(_hostingEnvironment.WebRootPath, path);
                        var filePath = Path.Combine(uploads, uniqueFileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            model.PictureForEdit.CopyTo(stream);
                        }

                        #endregion

                        if (!string.IsNullOrWhiteSpace(uniqueFileName))
                        {
                            model.PicturePath = $"wwwroot/Upload/Laboratory/{DateTime.Now.Year.ToString()}/{uniqueFileName}";
                            model.PictureName = fileName;
                        }
                        else
                        {
                            model.PicturePath = null;
                        }

                        var lab1 = _mapper.Map<Laboratory>(model);
                        var result1 = _unitOfWork.Repository<Laboratory>().Update(lab1);
                        if (result1.IsSuccess)
                        {
                            FileMethod.DeleteFile(model.PreviousPicturePath);
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

                    var lab2 = _mapper.Map<Laboratory>(model);
                    var result2 = _unitOfWork.Repository<Laboratory>().Update(lab2);
                    if (result2.IsSuccess)
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
                    status = 202,
                    message = CsResultConst.AleadyExistedLaboratory
                });
            }

            return Json(new
            {
                status = 400,
                message = CsResultConst.ModelNotValid
            });
        }
        #endregion

        #region Delete Lab

        public async Task<IActionResult> Delete(int Id)
        {
            var lab = await _unitOfWork.Repository<Laboratory>().GetByIdAsync(Id);
            if (lab == null) return NotFound();

            FileMethod.DeleteFile(lab.PicturePath);

            var result = await _unitOfWork.Repository<Laboratory>().DeleteAsync(lab);

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


        //#region Download File
        //public async Task<IActionResult> DownloadFile(int Id)
        //{
        //    var model = await _unitOfWork.Repository<PersonDocument>().GetByIdAsync(Id);
        //    var filepath = model.Path;

        //    if (!System.IO.File.Exists(filepath))
        //    {
        //        return Json(new
        //        {
        //            status = 202,
        //            message = CsResultConst.NotFoundFile
        //        });
        //    }

        //    var fileName = model.Name;
        //    byte[] fileBytes = System.IO.File.ReadAllBytes(filepath);
        //    return File(fileBytes, "APPLICATION/octet-stream", fileName);
        //}
        //#endregion

        #region Delete File

        public IActionResult DeleteFile(int Id)
        {
            var lab = _unitOfWork.Repository<Laboratory>().GetById(Id);
            if (lab == null) return NotFound();

            if (lab.PicturePath != null)
            {
                FileMethod.DeleteFile(lab.PicturePath);
                lab.PicturePath = null;
                lab.PictureName = "Fayl silinib!";
                var result = _unitOfWork.Repository<Laboratory>().Update(lab);
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
            return Json(new
            {
                status = 406,
                message = CsResultConst.NotFoundDeleteFile
            });
        }
        #endregion

        #region Download File
        public async Task<IActionResult> DownloadFile(int id)
        {
            var lab = await _unitOfWork.Repository<Laboratory>().GetByIdAsync(id);
            var filepath = lab.PicturePath;
            if (!System.IO.File.Exists(filepath))
            {
                return NotFound();
            }
            var fileName = lab.PictureName;
            byte[] fileBytes = System.IO.File.ReadAllBytes(filepath);
            return File(fileBytes, "APPLICATION/octet-stream", fileName);
        }
        #endregion
    }
}