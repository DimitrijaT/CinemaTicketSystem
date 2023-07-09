using CinemaTicketSystem.Domain.DomainModels;
using CinemaTicketSystem.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CinemaTicketSystem.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public AdminController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("[action]")]
        public List<Order> GetAllActiveOrders()
        {
            return this._orderService.getAllOrders();
        }


        [HttpPost("[action]")]
        public Order GetDetailsForOrder(BaseEntity model)
        {
            return this._orderService.getOrderDetails(model);
        }
    }

}

