using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Interface
{
    public interface IBooks
    {
        IEnumerable<Books> GetBooks();
        Books GetBookByID(int id);
        Books AddBooks(Books book);
        Books UpdateBooks(Books book);
        List<Category> PopulateCategory();
        void DeleteBooks(int id);
    }
}
