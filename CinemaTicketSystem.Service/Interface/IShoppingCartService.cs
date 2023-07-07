using CinemaTicketSystem.Domain.Dto;
using System;

namespace CinemaTicketSystem.Service.Interface
{
    public interface IShoppingCartService
    {
        ShoppingCartDto getShoppingCartInfo(string userId);

        bool deleteProductFromSoppingCart(string userId, Guid productId);

        bool order(string userId);
    }
}