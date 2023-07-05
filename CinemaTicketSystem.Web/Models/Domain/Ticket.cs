using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaTicketSystem.Web.Models.Domain
{
    public class Ticket
    {

        public Guid Id { get; set; }
        public string MovieName { get; set; }

        public string Genre { get; set; }

        public DateTime Date { get; set; }

        public virtual ICollection<ShoppingCartTicket> ShoppingCartTickets { get; set; }
    }
}
