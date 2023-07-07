using CinemaTicketSystem.Domain.DomainModels;
using System;

namespace CinemaTicketSystem.Domain.Dto
{
    public class AddToShoppingCartDto
    {
        public Ticket SelectedTicket { get; set; }
        public Guid SelectedTicketId { get; set; }
        public int Quantity { get; set; }
    }
}