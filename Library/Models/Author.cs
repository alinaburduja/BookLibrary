using System;
using System.Collections.Generic;

namespace Library.Models
{
    public class Author
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int BirthYear { get; set; }

   /*     public List<Book> Books { get; set; }*/
    }
}
