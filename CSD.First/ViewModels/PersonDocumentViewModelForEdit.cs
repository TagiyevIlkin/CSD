using CSD.ComSciDep.Utility;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSD.First.ViewModels
{
    public class PersonDocumentViewModelForEdit
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }
        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [DisplayName(CsDisplayName.DocumentType)]
        public int DocumentTypeId { get; set; }
        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [DisplayName(CsDisplayName.FullName)]
        public int PersonelId { get; set; }
        public int PreviousPersonId { get; set; }
        public string PreviousPersonFullName { get; set; }
        public string PreviousFilePath { get; set; }
        public int PreviousDocumentTypeId { get; set; }
        [DisplayName(CsDisplayName.File)]
        public IFormFile FileForEdit { get; set; }

    }
}
