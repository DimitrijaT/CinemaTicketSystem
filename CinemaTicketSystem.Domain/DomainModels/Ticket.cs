using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaTicketSystem.Domain.DomainModels
{
    public class Ticket : BaseEntity
    {
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

        public virtual IEnumerable<TicketOrder> TicketOrder { get; set; }
    }
}