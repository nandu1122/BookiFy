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
    public class ShoppingCartController : Controller
    {
        private readonly IItemRepository _itemRepository;
        private readonly ShoppingCart _shoppingCart;
        public ShoppingCartController(IItemRepository itemRepository, ShoppingCart shoppingCart)
        {
            _itemRepository = itemRepository;
            _shoppingCart = shoppingCart;
        }
        public IActionResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var sCVM = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = (double)_shoppingCart.GetShoppingCartTotal()

            };
            return View(sCVM);
        }
        public RedirectToActionResult AddToShoppingCart(int itemID)
        {
            var selectedItem = _itemRepository.Items.FirstOrDefault(p => p.ItemId == itemID);
            if (selectedItem != null)
            {
                _shoppingCart.AddToCart(selectedItem, 1);

            }
            return RedirectToAction("Index");
        }
        public RedirectToActionResult RemoveFromShoppingCart(int itemId)
        {
            var selectedItem = _itemRepository.Items.FirstOrDefault(p => p.ItemId == itemId);
            if (selectedItem != null)
            {
                _shoppingCart.RemoveFromCart(selectedItem, 1);

            }
            return RedirectToAction("Index");
        }
    }
}
