using CinemaTicketSystem.Domain.DomainModels;
using CinemaTicketSystem.Domain.Dto;
using CinemaTicketSystem.Repository.Interface;
using CinemaTicketSystem.Service.Interface;
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

        public TicketService(IUserRepository userRepository, IRepository<Ticket> ticketRepository, IRepository<ShoppingCartTicket> shoppingCartTicketRepository)
        {
            _userRepository = userRepository;
            _ticketRepository = ticketRepository;
            _shoppingCartTicketRepository = shoppingCartTicketRepository;
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

                    this._shoppingCartTicketRepository.Insert(itemToAdd);
                    return true;
                }
                return false;
            }
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