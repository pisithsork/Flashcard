using System;
using System.Collections.Generic;

namespace Flashcards_API.Models
{
    public partial class Flashcard
    {
        public int Id { get; set; }
        public string Question { get; set; } = null!;
        public string Answer { get; set; } = null!;
    }
}
