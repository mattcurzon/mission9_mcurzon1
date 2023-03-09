using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mission9_mcurzon1.Models;
using mission9_mcurzon1.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace mission9_mcurzon1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BookstoreContext context { get; set; }
        private IBookstoreRepository repo;

        public HomeController(ILogger<HomeController> logger, IBookstoreRepository temp)
        {
            _logger = logger;
            repo = temp;
        }

        public IActionResult Index(string category, int pageNum = 1)
        {
            int pageSize = 10;

            var x = new BooksViewModel
            {
                Books = repo.Books
                .Where(x => x.Category == category || category == null)
                .OrderBy(x => x.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = 
                    (category == null ?
                    repo.Books.Count()
                    : repo.Books.Where(x => x.Category == category).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };
            return View(x);
        }
        public IActionResult Cart()
        {
            return View();
;        }
        public IActionResult Privacy()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult AllBooks()
        {
            var books = repo.Books.ToList();
            return View(books);
        }
    }
}
