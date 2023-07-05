using CinemaTicketSystem.Web.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaTicketSystem.Web.Models.Domain
{
    public class ShoppingCart
    {
        public Guid Id { get; set; }

        public string OwnerId { get; set; }

        public CinemaTicketSystemUser Owner { get; set; }

        public virtual ICollection<ShoppingCartTicket> ShoppingCartTickets { get; set; }
    }
}
