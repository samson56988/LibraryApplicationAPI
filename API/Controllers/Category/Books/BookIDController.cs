using API.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers.Category.Books
{
    public class BookIDController : ApiController
    {
        private readonly BooksLogic book = new BooksLogic();

        [HttpGet]
        public Models.Books GetBookID(int id)
        {
            return book.GetBookByID(id);
        }
    }
}
