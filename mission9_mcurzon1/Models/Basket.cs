using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission9_mcurzon1.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        public void AddItem (Book book, double price, int qty)
        {
            BasketLineItem line = Items
                .Where(b => b.Book.BookId == book.BookId)
                .FirstOrDefault();
            if (line == null) 
            {
                Items.Add(new BasketLineItem
                {
                    Book = book,
                    Price = price,
                    Quantity = qty
                });
            } 
            else
            {
                line.Quantity += qty;
            }
        }
        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Price * x.Quantity);
            return sum;
        }
    }
    public class BasketLineItem 
    {
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }

}
