using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Books
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int categoryID { get; set; }

        public string Category { get; set; }
    }
}