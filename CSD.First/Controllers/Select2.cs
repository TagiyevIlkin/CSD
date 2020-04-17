using CSD.Entities.Shared;
using CSD.First.ViewModels;
using CSD.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSD.First.Controllers
{
    public class Select2 : Controller
    {

        private IUnitOfWork _unitOfWork;
        public Select2(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        #region Personnel LookUp
        public JsonResult Personel(string search)
        {
            var list = new List<Select2ViewModel>();
            var personel = _unitOfWork.Repository<Personel>().GetAll();

            foreach (var item in personel)
            {
                list.Add(new Select2ViewModel()
                {
                    text = item.Fullname,
                    id = item.Id
                });
            }


            if (!(string.IsNullOrEmpty(search) || string.IsNullOrWhiteSpace(search)))
            {
                list = list.Where(x => x.text.ToLower().StartsWith(search.ToLower())).ToList();
            }
            return Json(new { items = list });

        }
        #endregion

    }
}
