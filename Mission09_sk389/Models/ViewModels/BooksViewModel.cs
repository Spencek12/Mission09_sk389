using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_sk389.Models.ViewModels
{
    public class BooksViewModel
    {
        //Original project's data set coming from the repository
        public IQueryable<Book> Books { get; set; }
        //Page info
        public PageInfo PageInfo { get; set;}
    } 
}
