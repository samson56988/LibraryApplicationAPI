using API.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers.Category.Books
{
    public class BooksController : ApiController
    {
        private readonly BooksLogic book = new BooksLogic();

        [HttpGet]
        public IEnumerable<Models.Books> GetBooks()
        {
            return book.GetBooks().ToList();
        }

        [HttpPost]
        public Models.Books CreateBook([FromBody] Models.Books books)
        {
            return book.AddBooks(books);
        }

        [HttpPut]
        public Models.Books UpdateBook([FromBody] Models.Books books)
        {
            return book.UpdateBooks(books);
        }

        [HttpDelete]
        public void DeleteBook(int id)
        {
            book.DeleteBooks(id);
        }
    }
}
