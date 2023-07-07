using CinemaTicketSystem.Domain.DomainModels;
using CinemaTicketSystem.Domain.Dto;
using CinemaTicketSystem.Repository.Interface;
using CinemaTicketSystem.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CinemaTicketSystem.Service.Implementation
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IRepository<ShoppingCart> _shoppingCartRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<TicketOrder> _ticketOrderRepository;
        private readonly IUserRepository _userRepository;

        public ShoppingCartService(IRepository<ShoppingCart> shoppingCartRepository, IUserRepository userRepository, IRepository<Order> orderRepository, IRepository<TicketOrder> ticketOrderRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _userRepository = userRepository;
            _orderRepository = orderRepository;
            _ticketOrderRepository = ticketOrderRepository;
        }

        public bool deleteProductFromSoppingCart(string userId, Guid productId)
        {
            if (!string.IsNullOrEmpty(userId) && productId != null)
            {
                var loggedInUser = this._userRepository.Get(userId);

                var userShoppingCart = loggedInUser.UserCart;

                var itemToDelete = userShoppingCart.ShoppingCartTickets.Where(z => z.TicketId.Equals(productId)).FirstOrDefault();

                userShoppingCart.ShoppingCartTickets.Remove(itemToDelete);

                this._shoppingCartRepository.Update(userShoppingCart);

                return true;
            }
            return false;
        }

        public ShoppingCartDto getShoppingCartInfo(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                var loggedInUser = this._userRepository.Get(userId);

                var userCard = loggedInUser.UserCart;

                var allProducts = userCard.ShoppingCartTickets.ToList();

                var allProductPrices = allProducts.Select(z => new
                {
                    ProductPrice = z.Ticket.Price,
                    Quantity = z.Quantity
                }).ToList();

                double totalPrice = 0.0;

                foreach (var item in allProductPrices)
                {
                    totalPrice += item.Quantity * item.ProductPrice;
                }

                var result = new ShoppingCartDto
                {
                    ShoppingCartTickets = allProducts,
                    TotalPrice = totalPrice
                };

                return result;
            }
            return new ShoppingCartDto();
        }

        public bool order(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                var loggedInUser = this._userRepository.Get(userId);
                var userCard = loggedInUser.UserCart;

                Order order = new Order
                {
                    Id = Guid.NewGuid(),
                    User = loggedInUser,
                    UserId = userId
                };

                this._orderRepository.Insert(order);

                List<TicketOrder> ticketOrders = new List<TicketOrder>();

                var result = userCard.ShoppingCartTickets.Select(z => new TicketOrder
                {
                    Id = Guid.NewGuid(),
                    TicketId = z.Ticket.Id,
                    OrderedTicket = z.Ticket,
                    OrderId = order.Id,
                    UserOrder = order,
                    Quantity = z.Quantity
                }).ToList();

                ticketOrders.AddRange(result);

                foreach (var item in ticketOrders)
                {
                    this._ticketOrderRepository.Insert(item);
                }

                loggedInUser.UserCart.ShoppingCartTickets.Clear();

                this._userRepository.Update(loggedInUser);

                return true;
            }

            return false;
        }
    }
}