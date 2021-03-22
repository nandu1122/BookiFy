using BookiFy.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookiFy.Data.Interfaces
{
    public interface IItemRepository
    {
        public IEnumerable<Item> Items { get; }
        public IEnumerable<Item> Laptops { get; }
        public Item GetItemById(int itemId);
    }
}
