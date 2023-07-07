using CinemaTicketSystem.Domain.DomainModels;
using System.Collections.Generic;

namespace CinemaTicketSystem.Repository.Interface
{
    public interface IOrderRepository
    {
        public List<Order> getAllOrders();

        public Order getOrderDetails(BaseEntity model);
    }
}