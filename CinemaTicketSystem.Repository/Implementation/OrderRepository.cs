using CinemaTicketSystem.Domain.DomainModels;
using CinemaTicketSystem.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CinemaTicketSystem.Repository.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Order> entities;
        private string errorMessage = string.Empty;

        public OrderRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<Order>();
        }

        public List<Order> getAllOrders()
        {
            var result = entities
                .Include(z => z.User)
                .Include(z => z.TicketOrders)
                .Include("TicketOrders.OrderedTicket")
                .ToListAsync().Result;

            return result;
        }

        public Order getOrderDetails(BaseEntity model)
        {
            return entities
               .Include(z => z.User)
               .Include(z => z.TicketOrders)
               .Include("TicketOrders.OrderedTicket")
               .SingleOrDefaultAsync(z => z.Id == model.Id).Result;
        }
    }
}