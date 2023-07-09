using System;

namespace CinemaTicketSystem.Domain.DomainModels
{
    public class ShoppingCartTicket : BaseEntity
    {
        public Guid TicketId { get; set; }

        public virtual Ticket Ticket { get; set; }
        public Guid ShoppingCartId { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }

        public int Quantity { get; set; }
    }
}