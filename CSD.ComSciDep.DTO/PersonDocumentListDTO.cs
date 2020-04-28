using System;
using System.Collections.Generic;
using System.Text;

namespace CSD.ComSciDep.DTO
{
    public class PersonDocumentListDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }
        public string DocumentTypeName { get; set; }
        public string PersonFullName { get; set; }
    }
}
