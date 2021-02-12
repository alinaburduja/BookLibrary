using Library.Models;
using Library.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService bookService;
        
        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpPost]
        public Book Post([FromBody] Book book)
        {
            return bookService.PostBook(book);
        }

        [Route("{id}")]
        [HttpGet]
        public Book GetById([FromRoute]Guid id)
        {
            return bookService.GetById(id);
        }

        [Route("author/{authorId}")]
        [HttpGet]
        public IEnumerable<Book> GetByAuthorId([FromRoute] Guid authorId, [FromQuery] BookGenre genre)
        {
            return bookService.GetByAuthorId(authorId, genre);
        }

        [Route("filter")]
        [HttpGet]
        public IEnumerable<Book> GetFilteredBooks([FromQuery] string text, [FromQuery] int startYear, [FromQuery] int endYear)
        {
            return bookService.GetFilteredBooks(text, startYear, endYear);
        }

        [Route("books/genres")]
        [HttpGet]
        public List<List<Book>> ListOfListsWithBooks()
        {
            
           return bookService.ListOfListsWithBooks();
        }

        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return null;
        }

        [Route("{id}")]
        [HttpDelete]
        public void DeleteById([FromRoute] Guid id)
        {
           bookService.DeleteById(id);
        }
    }
}
