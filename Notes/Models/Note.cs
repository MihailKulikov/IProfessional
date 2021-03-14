﻿using System.ComponentModel.DataAnnotations;

namespace Notes.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        
        public string Title { get; set; }

        public string Content { get; set; }
    }
}