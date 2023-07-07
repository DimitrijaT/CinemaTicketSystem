using CinemaTicketSystem.Domain.DomainModels;
using System.Collections.Generic;

namespace CinemaTicketSystem.Service.Interface
{
    public interface IOrderService
    {
        public List<Order> getAllOrders();

        public Order getOrderDetails(BaseEntity model);
    }
}