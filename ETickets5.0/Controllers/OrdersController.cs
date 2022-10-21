using ETickets5._0.Data.Cart;
using ETickets5._0.Data.Services;
using ETickets5._0.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ETickets5._0.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly ShoppingCart _shoppingCart;
        
        public OrdersController(IMovieService movieService, ShoppingCart shoppingCart)
        {
            _movieService = movieService;
            _shoppingCart = shoppingCart;
        }
        public IActionResult ShoppingCart()
        {
            var items=_shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartVM()
            {
                shoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(response);
        }
        public async Task<IActionResult> AddItemToShoppingCart(int id)
        {
            var item=await _movieService.getmovieById(id);
            if (item !=null)
            {
                _shoppingCart.AddItemToCart(item);

            }
            return RedirectToAction(nameof(ShoppingCart));
        }
        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _movieService.getmovieById(id);
            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);

            }
            return RedirectToAction(nameof(ShoppingCart));
        }
    }
}
