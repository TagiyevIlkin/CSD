using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSD.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CSD.First.Controllers
{
    public class EventController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public EventController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}