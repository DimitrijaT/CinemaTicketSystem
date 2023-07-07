using CinemaTicketSystem.Domain.DomainModels;
using System.Collections.Generic;

namespace CinemaTicketSystem.Domain.Dto
{
    public class ShoppingCartDto
    {
        public List<ShoppingCartTicket> ShoppingCartTickets { get; set; }

        public double TotalPrice { get; set; }
    }
}