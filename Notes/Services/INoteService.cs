using System.Collections.Generic;
using System.Threading.Tasks;
using Notes.Models;

namespace Notes.Services
{
    public interface INoteService
    {
        Task<Note> AddNoteAsync(NoteRequest request);
        Task<List<Note>> GetNotesAsync();
        Task<Note> GetNoteAsync(int id);
        Task<List<Note>> GetNotesAsync(string query);
        Task UpdateNoteAsync(int id, NoteRequest request);
        Task DeleteNoteAsync(int id);
    }
}