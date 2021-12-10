using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WillysWacky5.Data.Cart;
using WillysWacky5.Data.Services;
using WillysWacky5.Data.ViewModels;

namespace WillysWacky5.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IProductService _productService;
        private readonly ShoppingCart _shoppingCart;
        public OrdersController(IProductService productService, ShoppingCart shoppingCart)
        {
            _productService = productService;
            _shoppingCart = shoppingCart;
        }
        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(response);
        }

        public async Task<RedirectToActionResult> AddItemToShoppingCart(int id)
        {
            var item = await _productService.GetProductByIdAsync(id);

            if(item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }
    }
}
