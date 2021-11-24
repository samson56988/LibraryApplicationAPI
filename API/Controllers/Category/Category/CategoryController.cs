using API.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers.Category
{
    public class CategoryController : ApiController
    {
        private readonly CategoryLogic category = new CategoryLogic();

        [HttpGet]
        public IEnumerable<Models.Category> GetCategory()
        {
            return category.GetCategories().ToList();
        }

        [HttpPost]
        public Models.Category CreateCategory([FromBody] Models.Category categorys)
        {
            return category.AddCategory(categorys);
        }

        [HttpPut]
        public Models.Category UpdateCategory([FromBody] Models.Category categorys)
        {
            return category.UpdateCategory(categorys);
        }

        [HttpDelete]
        public void DeleteCategory(int id)
        {
            category.DeleteCategory(id);
        }
    }
}
