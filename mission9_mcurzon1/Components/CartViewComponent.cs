using Microsoft.AspNetCore.Mvc;
using mission9_mcurzon1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission9_mcurzon1.Components
{
    public class CartViewComponent : ViewComponent
    {
        private Basket basket;
        private IBookstoreRepository repo { get; set; }

        public CartViewComponent (Basket temp)
        {
            basket = temp;
        }
        public IViewComponentResult Invoke ()
        {
            return View(basket);
        }
    }
}
