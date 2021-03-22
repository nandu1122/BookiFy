using BookiFy.Data.Interfaces;
using BookiFy.Models;
using BookiFy.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BookiFy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IItemRepository _itemRepository;
        private readonly ICategoryRepository _categoryRepository;
        public HomeController(IItemRepository itemRepository, ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _itemRepository = itemRepository;
            
        }
        public ViewResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                InStock = _itemRepository.Items
            };
            return View(homeViewModel);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
