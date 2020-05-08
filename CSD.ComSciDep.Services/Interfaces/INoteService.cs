using CSD.ComSciDep.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSD.ComSciDep.Services.Interfaces
{
    public interface INoteService
    {
        IQueryable<NoteListDTO> GetNoteList();
    }
}
