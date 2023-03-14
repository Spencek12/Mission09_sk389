using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_sk389.Models
{
    public class Basket
    {
        //First part of this line declares, the second part instantiates
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        public virtual void AddItem (Book book, int qty)
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

        public virtual void RemoveItem(Book book)
        {
            Items.RemoveAll(x => x.Book.BookId == book.BookId);
        }

        public virtual void ClearBasket()
        {
            Items.Clear();
        }
        public virtual double CalculateTotal()
        {            
            double sum = Items.Sum(x => (x.Book.Price * x.Quantity));

            return sum;
        }
    }

  
    public class BasketLineItem
    {
        [Key]
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
