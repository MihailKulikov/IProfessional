using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Notes.Models;
using Notes.Services;

namespace Notes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly INoteService service;

        public NotesController(INoteService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("/notes")]
        public async Task<Note> AddNewNote([FromBody] NoteRequest noteRequest) =>
            await service.AddNoteAsync(noteRequest);

        [HttpGet]
        [Route("/notes")]
        public async Task<List<Note>> GetNotes() => await service.GetNotesAsync();

        [HttpGet]
        [Route("/notes/{id}")]
        public async Task<Note> GetNote(int id) => await service.GetNoteAsync(id);

        [HttpGet]
        [Route("/notes/{query}")]
        public async Task<List<Note>> GetNotes([FromQuery] string query) => await service.GetNotesAsync(query);

        [HttpPut]
        [Route("/notes/{id}")]
        public async Task UpdateNote([FromQuery] int id, [FromBody] NoteRequest request)
        {
            await service.UpdateNoteAsync(id, request);
        }

        [HttpDelete]
        [Route("/notes/{id}")]
        public async Task DeleteNote(int id)
        {
            await service.DeleteNoteAsync(id);
        }
    }
}
