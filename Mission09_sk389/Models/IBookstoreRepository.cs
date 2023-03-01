using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_sk389.Models
{
    //Pattern for a class
    public interface IBookstoreRepository
    {
        //Just get, so we can read from this data but not write to it
        IQueryable<Book> Books { get; }
    }
}
