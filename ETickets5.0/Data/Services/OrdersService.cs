using ETickets5._0.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETickets5._0.Data.Services
{
    public class OrdersService : IOrderService
    {
        private readonly AppDbContext _conext;
        public OrdersService(AppDbContext conext)
        {
            _conext = conext;
        }

        public async Task<List<Order>> GetOrdersByUserIdAsync(string userId)
        {
            var orders = await _conext.Orders.Include(n => n.OrderItems).ThenInclude(n => n.Movie).Where(n => n.UserId
         == userId).ToListAsync();
            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string useremailAdress)
        {
            var order = new Order()
            {

                UserId = userId,
                 Email = useremailAdress
            };
            await _conext.Orders.AddAsync(order);
            await _conext.SaveChangesAsync();

            foreach (var item in items)
            {

                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    MovieId = item.Movie.Id,
                    OrderId = item.Id,
                    Price = item.Movie.Price


                };
             await   _conext.OrderItems.AddAsync(orderItem);


            }
            await _conext.SaveChangesAsync();

        




        }
    }
}
