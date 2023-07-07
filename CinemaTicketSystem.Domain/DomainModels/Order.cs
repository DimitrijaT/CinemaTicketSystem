using CinemaTicketSystem.Domain.Identity;
using System.Collections.Generic;

namespace CinemaTicketSystem.Domain.DomainModels
{
    public class Order : BaseEntity
    {
        public string UserId { get; set; }

        public CinemaTicketSystemUser User { get; set; }

        public IEnumerable<TicketOrder> TicketOrders { get; set; }
    }
}