using ETickets5._0.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ETickets5._0.Data.Services
{
    public interface IOrderService
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string useremailAdress);
        Task<List<Order>>GetOrdersByUserIdAsync(string userId);
    }
}
