using Microsoft.AspNetCore.Mvc;
using mission9_mcurzon1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission9_mcurzon1.Components
{
    public class CategoryViewComponent : ViewComponent
    {
        private IBookstoreRepository repo { get; set; }
        public CategoryViewComponent (IBookstoreRepository temp)
        {
            repo = temp;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            var categories = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);
            return View(categories);
        }
    }
}
