using CinemaTicketSystem.Domain.Identity;
using System.Collections.Generic;

namespace CinemaTicketSystem.Domain.DomainModels
{
    public class ShoppingCart : BaseEntity
    {
        public string OwnerId { get; set; }

        public virtual CinemaTicketSystemUser Owner { get; set; }

        public virtual ICollection<ShoppingCartTicket> ShoppingCartTickets { get; set; }
    }
}