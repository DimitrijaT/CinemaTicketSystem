﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaTicketSystem.Web.Models.Domain
{
    public class ShoppingCartTicket
    {
        public Guid TicketId { get; set; }

        public Ticket Ticket { get; set; }
        public Guid ShoppingCartId { get; set; }

        public ShoppingCart ShoppingCart { get; set; }
    }
}