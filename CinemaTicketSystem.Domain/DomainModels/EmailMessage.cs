using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaTicketSystem.Domain.DomainModels
{
    public class EmailMessage : BaseEntity
    {
        public string MailTo { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }

        // If the message that is cached is sent or not
        public Boolean Status { get; set; }

    }
}
