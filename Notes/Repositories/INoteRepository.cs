using System.Collections.Generic;
using System.Threading.Tasks;
using Notes.Models;

namespace Notes.Repositories
{
    public interface INoteRepository
    {
        Task<Note> AddNoteAsync(string title, string content);
        Task<List<Note>> GetNotesAsync();
        Task<Note> GetNoteAsync(int id);
        Task<List<Note>> GetNotesAsync(string query);
        Task UpdateNoteAsync(int id, NoteRequest request);
        Task DeleteNoteAsync(int id);
    }
}