using CinemaTicketSystem.Domain.Identity;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CinemaTicketSystem.Domain.DomainModels
{
    public class Order : BaseEntity
    {
        public string UserId { get; set; }

        public CinemaTicketSystemUser User { get; set; }

        public virtual IEnumerable<TicketOrder> TicketOrders { get; set; }
    }
}