using BookiFy.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookiFy.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<Item> InStock { get; set; }
    }
}
