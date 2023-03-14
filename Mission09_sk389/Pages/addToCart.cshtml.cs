using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission09_sk389.Models;
using Mission09_sk389.Models.Infrastructure;

namespace Mission09_sk389.Pages
{
    public class addToCartModel : PageModel
    {
        //Build an instance of the database, so we can pull the data once
        // we have the BookId (what we typically do in a controller)
        private IBookstoreRepository repo { get; set; }
        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }

        public addToCartModel(IBookstoreRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        //Where we receive the form from the "Add to Cart" button
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int BookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == BookId);

            basket.AddItem(b, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Book.BookId == bookId).Book);

            return RedirectToPage(new {ReturnUrl = returnUrl});
        }
    }
}
