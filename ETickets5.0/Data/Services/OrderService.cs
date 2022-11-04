using ETickets5._0.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETickets5._0.Data.Services
{
    public class OrderService : IOrdersService
        
    {
        private readonly AppDbContext _context;
        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole)
        {

            var orders = await _context.Orders.Include(n => n.OrderItems).ThenInclude(n => n.Movie).Where(n => n.UserId ==
            userId).ToListAsync();
            return orders;

        }

        public Task GetOrdersByUserIdAndRoleAsync(string userId)
        {
            throw new System.NotImplementedException();
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress)
        {
            var order = new Order()
            {
                Email = userEmailAddress,
                UserId = userId
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    MovieId = item.Movie.Id,
                    OrderId = order.Id,
                    Price = item.Movie.Price

                };
                await _context.OrderItems.AddAsync(orderItem);




            }
            await _context.SaveChangesAsync();











        }
    }
}
