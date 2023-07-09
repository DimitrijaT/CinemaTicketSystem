using System;
using System.Text.Json.Serialization;

namespace CinemaTicketSystem.Domain.DomainModels
{
    public class TicketOrder : BaseEntity
    {
        public Guid TicketId { get; set; }

        public Ticket OrderedTicket { get; set; }

        public Guid OrderId { get; set; }

        //[JsonIgnore]
        public Order UserOrder { get; set; }

        public int Quantity { get; set; }
    }
}