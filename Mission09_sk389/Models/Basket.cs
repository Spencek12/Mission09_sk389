using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_sk389.Models
{
    public class Basket
    {
        //First part of this line declares, the second part instantiates
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        public void AddItem (Book book, int qty)
        {
            BasketLineItem line = Items
                .Where(b => b.Book.BookId == book.BookId)
                .FirstOrDefault();
            if (line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Book = book,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += line.Quantity;
            }
        }
        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Book.Price);

            return sum;
        }
    }

  
    public class BasketLineItem
    {
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
