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
        private readonly IOrdersService _ordersService;
       
        public OrdersController(IMovieService movieService, ShoppingCart shoppingCart, IOrdersService ordersService)
        {
            _movieService = movieService;
            _shoppingCart = shoppingCart;
            _ordersService = ordersService;
        }


        public async Task<IActionResult>Index()
        {
            string userId = "";
            var orders = await _ordersService.GetOrdersByUserIdAndRoleAsync(userId, "User");
            return View(orders);

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



        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            string userId = "";
            string userEmailAdress = "";
          
           await _ordersService.StoreOrderAsync(items, userId, userEmailAdress);
            await _shoppingCart.ClearShoppingCart();
            return View("CompleteOrder");

        }
    }
}
