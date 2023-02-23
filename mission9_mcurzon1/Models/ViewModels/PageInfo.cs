using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission9_mcurzon1.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalNumBooks { get; set; }
        public int BooksPerPage { get; set; }
        public int CurrentPage { get; set; }
        //calculate number of pages needed
        public int TotalPages => (int) Math.Ceiling((double) TotalNumBooks / BooksPerPage);
    }
}
