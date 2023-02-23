using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission9_mcurzon1.Models.ViewModels
{
    public class BooksViewModel
    {
        public IQueryable<Book> Books { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
