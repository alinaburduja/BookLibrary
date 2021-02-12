using Library.Models;
using System;

namespace Library.Services.Interfaces
{
    public interface IAuthorService
    {
        Author PostAuthor(Author author);
        Author GetById(Guid id);

        Author Delete(Author author);

        void DeleteByAuthorId(Guid id);
    }
}
