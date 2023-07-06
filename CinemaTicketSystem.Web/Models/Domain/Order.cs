using CinemaTicketSystem.Web.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaTicketSystem.Web.Models.Domain
{
    public class Order
    {

        public Guid Id { get; set; }

        public string UserId { get; set; }

        public CinemaTicketSystemUser User { get; set; }

        public IEnumerable<TicketOrder> TicketOrders { get; set; }
    }
}
