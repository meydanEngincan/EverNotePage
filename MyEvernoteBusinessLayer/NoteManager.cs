using MyEvernoteDataAccessLayer.EntityFramework;
using MyEvernoteEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvernoteBusinessLayer
{
    public class NoteManager
    {
        private Repository<Note> repo_note = new Repository<Note>();
        public List<Note> GetAllNote()
        {
            return repo_note.List();
        }

        public IQueryable<Note> GettAllNoteQueryable()
        {
            return repo_note.ListIQueryable();
        }
    }
}
