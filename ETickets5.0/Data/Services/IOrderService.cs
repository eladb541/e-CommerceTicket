using ETickets5._0.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ETickets5._0.Data.Services
{
    public interface IOrdersService
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress);
        Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole);
     
    }
}
