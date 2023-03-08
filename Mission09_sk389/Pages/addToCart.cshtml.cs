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
        
        public addToCartModel(IBookstoreRepository temp)
        {
            repo = temp;
        }

        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }
        //Where we receive the form from the "Add to Cart" button
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
        }

        public IActionResult OnPost(int BookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == BookId);

            //If there's already a basket, use it, if not, create a new one
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
            basket.AddItem(b, 1);

            //Attach basket to session
            HttpContext.Session.SetJson("basket", basket);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
