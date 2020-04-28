using CSD.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSD.First.ViewModels
{
    public class FinalPersonDocumentViewModel
    {
        public PersonDocumentViewModel  PersonDocumentViewModel { get; set; }
        public ICollection<PersonDocument> DocumentsForPerson { get; set; }
        public string CurrentPerson { get; set; }
        public List<DocumetType>  DocumetTypeList { get; set; }
    }
}
