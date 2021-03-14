using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Notes.Models;
using Notes.Repositories;

namespace Notes.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository repository;

        public NoteService(INoteRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Note> AddNoteAsync(NoteRequest request) =>
            await repository.AddNoteAsync(
                request.Title ?? request.Content.Substring(0, Math.Min(50, request.Content.Length)), request.Content);

        public async Task<List<Note>> GetNotesAsync() => await repository.GetNotesAsync();
        public async Task<Note> GetNoteAsync(int id) => await repository.GetNoteAsync(id);
        public async Task<List<Note>> GetNotesAsync(string query) => await repository.GetNotesAsync(query);
        public async Task UpdateNoteAsync(int id, NoteRequest request)
        {
            await repository.UpdateNoteAsync(id, request);
        }

        public async Task DeleteNoteAsync(int id)
        {
            await repository.DeleteNoteAsync(id);
        }
    }
}