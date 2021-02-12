using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Services.Interfaces
{
    public interface IBookService
    {
        Book PostBook(Book book);
        Book GetById(Guid id);

        IEnumerable<Book> GetByAuthorId(Guid authorId, BookGenre genre);

        IEnumerable<Book> GetFilteredBooks(string text, int startYear, int endYear);

        List<List<Book>> ListOfListsWithBooks();

        void DeleteById(Guid id);




    }
}
