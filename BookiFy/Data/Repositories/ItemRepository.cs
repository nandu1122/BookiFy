using BookiFy.Data.Interfaces;
using BookiFy.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookiFy.Data.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _appDbContext;
        public ItemRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }
        public IEnumerable<Item> Items => _appDbContext.Items.Include(c => c.Category);

        public IEnumerable<Item> Laptops => _appDbContext.Items.Where(p => p.InStock).Include(c => c.Category);



        public Item GetItemById(int itemId)
        => _appDbContext.Items.FirstOrDefault(p => p.ItemId == itemId);
    }
}
