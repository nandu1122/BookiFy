using BookiFy.Data;
using BookiFy.Data.Interfaces;
using BookiFy.Data.Models;
using BookiFy.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookiFy.Controllers
{
    public class ItemController : Controller
    {
        private readonly AppDbContext _context;
       
        private readonly IItemRepository _itemRepository;
        private readonly ICategoryRepository _categoryRepository;
        public ItemController(IItemRepository itemRepository, ICategoryRepository categoryRepository,AppDbContext context)
        {
            _categoryRepository = categoryRepository;
            _itemRepository = itemRepository;
            _context = context;
        }
        public ViewResult List()
        {
            ViewBag.Name = "Items";
            ItemViewModel vm = new ItemViewModel();
            vm.Items = _itemRepository.Items;
            vm.CurrentCategory = "ItemCategory";
            return View(vm);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("ItemId,ItemaName,ShortDescription,LongDescription,Price,Category,InStock")] Item item ,[Bind("CategoryId,CategoryName")] Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                
                _context.SaveChanges();
                return RedirectToAction("List");
            }

            return View(item);
        }
    }
}
