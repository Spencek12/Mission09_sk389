using Microsoft.AspNetCore.Mvc;
using Mission09_sk389.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_sk389.Components
{
    //Categories view component that inherits from "ViewComponent"
    public class CategoriesViewComponent : ViewComponent
    {
        //Load up dataset
        private IBookstoreRepository repo { get; set; }

        //When this class is built, bring in IBookStoreRepository
        public CategoriesViewComponent(IBookstoreRepository temp)
        {
            repo = temp;
        }

        //Pull out distinct categories from dataset
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
