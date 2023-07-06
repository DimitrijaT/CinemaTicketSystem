using CinemaTicketSystem.Web.Data;
using CinemaTicketSystem.Web.Models.Domain;
using CinemaTicketSystem.Web.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CinemaTicketSystem.Web.Controllers
{
    public class ShoppingCartController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ShoppingCartController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Get the ID of the logged in User:
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Select * from Users where Id LIKE userId

            var loggedInUser = await _context.Users.Where(z => z.Id == userId)
                .Include("UserCart")
                .Include("UserCart.ShoppingCartTickets")
                .Include("UserCart.ShoppingCartTickets.Ticket")
                .FirstOrDefaultAsync();

            var userShoppingCart = loggedInUser.UserCart;

            var AllTickets = userShoppingCart.ShoppingCartTickets.ToList();

            // Get the sum of all Tickets:

            var AllTicketPrice = AllTickets.Select(z => new
            {
                Price = z.Ticket.Price,
                Quantity = z.Quantity
            }).ToList();

            var totalPrice = 0;

            foreach (var item in AllTicketPrice)
            {
                totalPrice += item.Quantity * item.Price;
            }

            ShoppingCartDto scDto = new ShoppingCartDto
            {
                ShoppingCartTickets = AllTickets,
                TotalPrice = totalPrice
            };


            return View(scDto);
        }


        public async Task<IActionResult> DeleteFromShoppingCart(Guid? id)
        {
            // Get the ID of the logged in User:
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Select * from Users where Id LIKE userId
            if (!string.IsNullOrEmpty(userId) && id != null)
            {
                var loggedInUser = await _context.Users.Where(z => z.Id == userId)
                    .Include("UserCart")
                    .Include("UserCart.ShoppingCartTickets")
                    .Include("UserCart.ShoppingCartTickets.Ticket")
                    .FirstOrDefaultAsync();

                var userShoppingCart = loggedInUser.UserCart;

                // Get the item we want to delete
                var itemToDelete = userShoppingCart.ShoppingCartTickets.Where(z => z.TicketId == id).FirstOrDefault();

                userShoppingCart.ShoppingCartTickets.Remove(itemToDelete);

                // Update Database for deleted ticket
                _context.Update(userShoppingCart);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "ShoppingCart");
        }


        public async Task<IActionResult> Order()
        {

            // Get the ID of the logged in User:
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Select * from Users where Id LIKE userId
            if (!string.IsNullOrEmpty(userId))
            {
                var loggedInUser = await _context.Users.Where(z => z.Id == userId)
                    .Include("UserCart")
                    .Include("UserCart.ShoppingCartTickets")
                    .Include("UserCart.ShoppingCartTickets.Ticket")
                    .FirstOrDefaultAsync();

                var userShoppingCart = loggedInUser.UserCart;

                Order order = new Order
                {
                    Id = Guid.NewGuid(),
                    User = loggedInUser,
                    UserId = userId
                };

                _context.Add(order);

                await _context.SaveChangesAsync();

                // Da se postavat biletite vo narachkata

                List<TicketOrder> ticketOrders = new List<TicketOrder>();

                var result = userShoppingCart.ShoppingCartTickets.Select(z => new TicketOrder
                {
                    TicketId = z.Ticket.Id,
                    OrderedTicket = z.Ticket,
                    OrderId = order.Id,
                    UserOrder = order
                }).ToList();

                ticketOrders.AddRange(result);

                foreach (var item in ticketOrders)
                {
                    _context.Add(item);
                }
                await _context.SaveChangesAsync();

                loggedInUser.UserCart.ShoppingCartTickets.Clear();

                _context.Update(loggedInUser);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "ShoppingCart");
        }
    }
}
