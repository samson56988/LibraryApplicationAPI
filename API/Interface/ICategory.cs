using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Interface
{
    public interface ICategory
    {
        IEnumerable<Category> GetCategories();
        Category GetCategoryByID(int id);
        Category AddCategory(Category category);
        Category UpdateCategory(Category category);
        void DeleteCategory(int id);

    }
}
