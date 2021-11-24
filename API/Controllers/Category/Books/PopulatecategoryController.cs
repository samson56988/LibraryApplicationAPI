using API.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers.Category.Books
{
    public class PopulatecategoryController : ApiController
    {

        private readonly BooksLogic  logic = new BooksLogic();

        [HttpGet]
        public List<Models.Category> PopulateCategory()
        {
            return logic.PopulateCategory().ToList();
        }
    }
}
