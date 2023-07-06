using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaTicketSystem.Web.Models.Domain
{
    public class Ticket
    {

        public Guid Id { get; set; }
        [Required]
        public string MovieName { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int Price { get; set; }

        public virtual ICollection<ShoppingCartTicket> ShoppingCartTickets { get; set; }
    }
}
