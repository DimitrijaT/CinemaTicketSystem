using CinemaTicketSystem.Domain.DomainModels;
using CinemaTicketSystem.Repository.Interface;
using CinemaTicketSystem.Service.Interface;
using System.Collections.Generic;

namespace CinemaTicketSystem.Service.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public List<Order> getAllOrders()
        {
            return this._orderRepository.getAllOrders();
        }

        public Order getOrderDetails(BaseEntity model)
        {
            return this._orderRepository.getOrderDetails(model);
        }
    }
}