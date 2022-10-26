using ETickets5._0.Data.Cart;
using Microsoft.AspNetCore.Mvc;
namespace ETickets5._0.Data.ViewComponents
   
{
    public class ShoppingCartSummary:ViewComponent
    {

        private readonly ShoppingCart _shoppingCart;
        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            _shoppingCart=shoppingCart;
        }
        public IViewComponentResult Invoke()
        {

            var items = _shoppingCart.GetShoppingCartItems();
            return View(items.Count);
        }




    }

}
