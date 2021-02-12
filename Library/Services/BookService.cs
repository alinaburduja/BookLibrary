using Library.Context;
using Library.Models;
using Library.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly AppDbContext context;

        public BookService(AppDbContext context)
        {
            this.context = context;
        }

        public Book PostBook(Book book)
        {
            context.Books.Add(book);
            context.SaveChanges();

            return book;
        }


        public List<List<Book>> ListOfListsWithBooks()
        {
            var listWithBooks = context.Books.ToList();
            List<List<Book>> listOfListsWithBooks = new List<List<Book>>();


            var listWithBookGenres = GetUniqueGenres(listWithBooks);

            for(var i = 0; i < listWithBookGenres.Count; i++)
            {
               var listWithBookSameGenre = ListWithSameGenre(listWithBookGenres[i]);
                listOfListsWithBooks.Add(listWithBookSameGenre);

            }

            return listOfListsWithBooks;
        }

        public List<Book> ListWithSameGenre(BookGenre genre)
        {
            return context.Books.Where(book => book.Genre == genre).ToList();
        }

        public List<BookGenre> GetUniqueGenres(List<Book> books)
        {
            List<BookGenre> bookGenres = (books).Select(book => book.Genre).Distinct().ToList();

            return bookGenres;
        }

        public IEnumerable<Book> GetByAuthorId(Guid authorId, BookGenre genre)
        {
           return context.Books.Where(book => book.AuthorId == authorId && book.Genre == genre);
        }

        public IEnumerable<Book> GetFilteredBooks(string text, int startYear, int endYear)
        {
            return context.Books.Where(book => book.Title.Contains(text) 
                                       && book.Year >= startYear && book.Year <= endYear);
        }


        public Book GetById(Guid id)
        {
            return context.Books.Include(i => i.Author).First(book => book.Id == id);
        }

        public void DeleteById(Guid id)
        {
            Book book = context.Books.Where(book => book.Id == id).Single<Book>();
            context.Books.Remove(book);
            context.SaveChanges();

        }

    }
}
