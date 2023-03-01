﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_sk389.Models.ViewModels
{
    //Store information about pages (passed all as one unit)
    public class PageInfo
    {
        public int TotalNumBooks { get; set; }
        public int BooksPerPage { get; set; }
        public int CurrentPage { get; set; }

        //Figure out how many pages we need
        public int TotalPages =>(int) Math.Ceiling((double) TotalNumBooks / BooksPerPage);
    }
}
