using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookiFy.Data.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Item Item { get; set; }
        public double Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
