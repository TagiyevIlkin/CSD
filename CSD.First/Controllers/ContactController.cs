using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CSD.ComSciDep.Utility;
using CSD.Entities.Shared;
using CSD.First.ViewModels;
using CSD.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CSD.First.Controllers
{
    public class ContactController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ContactController(
            IMapper mapper,
            IUnitOfWork unitOfWork
            )
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetMessage(MessageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var message = _mapper.Map<Message>(model);
                var result = _unitOfWork.Repository<Message>().Add(message);
                if (result.IsSuccess)
                {
                    return Json(new
                    {
                        status = 200,
                        message = CsResultConst.MessageAddSuccess
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
    }
}