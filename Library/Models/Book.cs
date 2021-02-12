using System;
using System.Collections.Generic;

namespace Library.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int PagesCount { get; set; }

        public int Year { get; set; }
        public Author Author { get; set; }
        public Guid AuthorId { get; set; }

        public BookGenre Genre { get; set; }

    }
}
