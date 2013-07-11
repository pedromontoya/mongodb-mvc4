using Sample.Core.Models;
using Sample.Core.Repositories;
using System.Collections.Generic;
using System.Web.Http;

namespace Sample.Web.Controllers.API
{
    public class NoteController : ApiController
    {
        private IGenericMongoRepository<Note> _noteRepository;

        public NoteController(IGenericMongoRepository<Note> noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public IEnumerable<Note> GET()
        {
            return _noteRepository.GetAllDocuments();
        }

        public void POST(Note note)
        {
            _noteRepository.AddDocument(note);
        }

        public void PUT(Note note)
        {
            _noteRepository.UpdateDocument(note);
        }

        public void DELETE(Note note)
        {
            _noteRepository.DeleteDocument(note);
        }
    }
}
