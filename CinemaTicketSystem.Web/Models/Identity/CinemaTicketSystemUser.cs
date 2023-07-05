﻿using CinemaTicketSystem.Web.Models.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaTicketSystem.Web.Models.Identity
{
    public class CinemaTicketSystemUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Address { get; set; }

        public virtual ShoppingCart UserCart { get; set; }
    }
}