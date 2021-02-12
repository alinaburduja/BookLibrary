using Library.Models;
using Library.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService authorService;

        public AuthorController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        [HttpPost]
        public Author Post([FromBody] Author author)
        {
            return authorService.PostAuthor(author);
        }

        [Route("{id}")]
        [HttpGet]
        public Author GetById([FromRoute]Guid id)
        {
            return authorService.GetById(id);
        }


        [Route("{id}")]
        [HttpDelete]
        public Author Delete([FromRoute] Author author)
        {
            return authorService.Delete(author);
        }
        

        [HttpGet]
        public IEnumerable<Author> Get()
        {
            return null;
        }

        [Route("author/{id}")]
        [HttpDelete]
        public void DeleteById([FromRoute] Guid id)
        {
            authorService.DeleteByAuthorId(id);
        }
    }
}
