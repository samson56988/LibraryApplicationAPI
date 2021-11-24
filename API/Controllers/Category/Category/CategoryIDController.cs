using API.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Models;

namespace API.Controllers.Category.Category
{
    public class CategoryIDController : ApiController
    {
        private readonly CategoryLogic category = new CategoryLogic();

        [HttpGet]
        public Models.Category GetCategoryID(int id)
        {
            return category.GetCategoryByID(id);
        }

    }
}
