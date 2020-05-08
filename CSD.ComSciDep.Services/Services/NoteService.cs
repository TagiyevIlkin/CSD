using CSD.ComSciDep.DTO;
using CSD.ComSciDep.Services.Interfaces;
using CSD.Entities.Shared;
using CSD.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSD.ComSciDep.Services.Services
{
    public class NoteService : INoteService
    {
      private readonly  IUnitOfWork _unitOfWork;
        public NoteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IQueryable<NoteListDTO> GetNoteList()
        {
            var noteList = (
                from note in _unitOfWork.Repository<Message>().Query()
                select new NoteListDTO()
                {
                    Id = note.Id,
                    Email = note.Email,
                    Name = note.Name,
                    Note = note.Note,
                    Surname = note.Surname,
                    Title = note.Title
                }

                );
            return noteList;
        }
    }
}
