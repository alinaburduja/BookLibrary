using Library.Context;
using Library.Models;
using Library.Services.Interfaces;
using System;
using System.Linq;

namespace Library.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly AppDbContext context;

        public AuthorService(AppDbContext context)
        {
            this.context = context;
        }

        public Author GetById(Guid id)
        {
            return context.Authors.First(author => author.Id == id);
        }

        public Author Delete(Author author)
        {
            context.Authors.Remove(author);
            context.SaveChanges();

            return author;
        }

        public Author PostAuthor(Author author)
        {
            context.Authors.Add(author);
            context.SaveChanges();

            return author;
        }

        public void DeleteByAuthorId(Guid id)
        {
            Author author = context.Authors.Where(author => author.Id == id).Single<Author>();
            context.Authors.Remove(author);
            context.SaveChanges();

        }
    }
}
