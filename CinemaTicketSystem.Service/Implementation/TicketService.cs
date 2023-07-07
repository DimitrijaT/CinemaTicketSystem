using CinemaTicketSystem.Domain.DomainModels;
using CinemaTicketSystem.Domain.Dto;
using CinemaTicketSystem.Repository.Interface;
using CinemaTicketSystem.Service.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CinemaTicketSystem.Service.Implementation
{
    public class TicketService : ITicketService
    {
        private readonly IRepository<Ticket> _ticketRepository;
        private readonly IRepository<ShoppingCartTicket> _shoppingCartTicketRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<TicketService> _logger; // Logger

        public TicketService(IUserRepository userRepository,
            IRepository<Ticket> ticketRepository,
            IRepository<ShoppingCartTicket> shoppingCartTicketRepository,
            ILogger<TicketService> logger)
        {
            _userRepository = userRepository;
            _ticketRepository = ticketRepository;
            _shoppingCartTicketRepository = shoppingCartTicketRepository;
            _logger = logger; // Logger
        }

        public bool AddToShoppingCart(AddToShoppingCartDto item, string userID)
        {
            var user = this._userRepository.Get(userID);

            var userShoppingCart = user.UserCart;

            if (item.SelectedTicketId != null && userShoppingCart != null)
            {
                var ticket = this.GetDetailsForTicket(item.SelectedTicketId);

                if (ticket != null)
                {
                    ShoppingCartTicket itemToAdd = new ShoppingCartTicket
                    {
                        Ticket = ticket,
                        TicketId = ticket.Id,
                        ShoppingCart = userShoppingCart,
                        ShoppingCartId = userShoppingCart.Id,
                        Quantity = item.Quantity
                    };

                    _logger.LogInformation("Ticket was successfully added into ShoppingCart");
                    this._shoppingCartTicketRepository.Insert(itemToAdd);
                    return true;
                }
                return false;
            }
            _logger.LogInformation("Something was wrong. TicketId or UserShoppingCart may be unavailible!");
            return false;
        }

        public void CreateNewTicket(Ticket p)
        {
            this._ticketRepository.Insert(p);
        }

        public void DeleteTicket(Guid id)
        {
            var ticket = this.GetDetailsForTicket(id);
            this._ticketRepository.Delete(ticket);
        }

        public List<Ticket> GetAllTickets()
        {
            _logger.LogInformation("GetAllProducts was called!");
            return this._ticketRepository.GetAll().ToList();
        }

        public Ticket GetDetailsForTicket(Guid? id)
        {
            return this._ticketRepository.Get(id);
        }

        public AddToShoppingCartDto GetShoppingCartInfo(Guid? id)
        {
            var ticket = this.GetDetailsForTicket(id);
            AddToShoppingCartDto model = new AddToShoppingCartDto
            {
                SelectedTicket = ticket,
                SelectedTicketId = ticket.Id,
                Quantity = 1
            };
            return model;
        }

        public void UpdateExistingTicket(Ticket p)
        {
            this._ticketRepository.Update(p);
        }
    }
}