using CSD.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSD.First.ViewModels
{
    public class SpecialityVievModel
    {
        public string Title { get; set; }
        public List<Specialty>  SpecialityList { get; set; }
    }
}
