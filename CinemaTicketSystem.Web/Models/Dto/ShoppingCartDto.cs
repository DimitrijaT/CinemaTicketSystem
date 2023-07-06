using CinemaTicketSystem.Web.Models.Domain;
//using EShop.Web.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaTicketSystem.Web.Models.Dto
{
    public class ShoppingCartDto
    {

        public List<ShoppingCartTicket> ShoppingCartTickets { get; set; }

        public double TotalPrice { get; set; }
    }
}
