﻿using ETickets5._0.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETickets5._0.Data.Cart
{
    public class ShoppingCart
    {
        public AppDbContext _context { get; set; }
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public ShoppingCart(AppDbContext context)
        {
                _context = context;
        }

        public void AddItemToCart(Movie movie)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Movie.Id == movie.Id && n.ShoppingCartId == ShoppingCartId);
            if (shoppingCartItem==null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Movie = movie,
                    Amount = 1

                };
                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _context.SaveChanges();
        }
        public void RemoveItemFromCart(Movie movie)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Movie.Id == movie.Id && n.ShoppingCartId == ShoppingCartId);
            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount>1)
                {
                    shoppingCartItem.Amount--;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }
                
            }
          
            _context.SaveChanges();

        }
        public static ShoppingCart GetShoppingCart(System.IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = service.GetService<AppDbContext>();

            string cartId = session.GetString("CartId")?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);
           
            return new ShoppingCart(context) { ShoppingCartId = cartId };
        
        }
        public List<ShoppingCartItem> GetShoppingCartItems()
        {

           return ShoppingCartItems?? (ShoppingCartItems = _context.ShoppingCartItems.Where(n =>n.ShoppingCartId ==
           ShoppingCartId).Include(n=> n.Movie).ToList());
        }
        public double GetShoppingCartTotal()
        {
            var total= _context.ShoppingCartItems.Where(n=>n.ShoppingCartId==ShoppingCartId).Select(n=>n.Movie.Price* n.Amount).Sum();
            return total;

        }
        public async Task ClearShoppingCart()
        {

            var items = await _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).ToListAsync();
            _context.ShoppingCartItems.RemoveRange(items);
            await _context.SaveChangesAsync();
        
        }
       
    }
}
