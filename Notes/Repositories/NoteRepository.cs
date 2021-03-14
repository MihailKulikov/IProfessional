using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Notes.DataBase;
using Notes.Models;

namespace Notes.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly NotesDbContext context;

        public NoteRepository([FromServices] NotesDbContext context)
        {
            this.context = context;
        }

        public async Task<Note> AddNoteAsync(string title, string content)
        {
            var addedNote = (await context.AddAsync(new Note {Content = content, Title = title})).Entity;
            await context.SaveChangesAsync();
            return addedNote;
        }

        public async Task<List<Note>> GetNotesAsync() => await context.Notes.ToListAsync();
        public async Task<Note> GetNoteAsync(int id) => await context.Notes.FindAsync(id);

        public async Task<List<Note>> GetNotesAsync(string query)
        {
            return await context.Notes.AsQueryable()
                .Where(note => note.Title.Contains(query) || note.Content.Contains(query)).ToListAsync();
        }

        public async Task UpdateNoteAsync(int id, NoteRequest request)
        {
            var note = await context.Notes.FindAsync(id);
            note.Content = request.Content;
            note.Title = request.Title ?? request.Content.Substring(0, Math.Min(50, request.Content.Length));
            await context.SaveChangesAsync();
        }

        public async Task DeleteNoteAsync(int id)
        {
            var note = new Note {Id = id};
            context.Notes.Attach(note);
            context.Notes.Remove(note);
            await context.SaveChangesAsync();
        }
    }
}