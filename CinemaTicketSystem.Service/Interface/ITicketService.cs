using CinemaTicketSystem.Domain.DomainModels;
using CinemaTicketSystem.Domain.Dto;
using System;
using System.Collections.Generic;

namespace CinemaTicketSystem.Service.Interface
{
    public interface ITicketService
    {
        List<Ticket> GetAllTickets();

        Ticket GetDetailsForTicket(Guid? id);

        void CreateNewTicket(Ticket p);

        void UpdateExistingTicket(Ticket p);

        AddToShoppingCartDto GetShoppingCartInfo(Guid? id);

        void DeleteTicket(Guid id);

        bool AddToShoppingCart(AddToShoppingCartDto item, string userID);
    }
}