﻿using CinemaTicketSystem.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace CinemaTicketSystem.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return View(this._shoppingCartService.getShoppingCartInfo(userId));
        }

        public IActionResult DeleteFromShoppingCart(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = this._shoppingCartService.deleteProductFromSoppingCart(userId, id);

            if (result)
            {
                return RedirectToAction("Index", "ShoppingCart");
            }
            else
            {
                return RedirectToAction("Index", "ShoppingCart");
            }
        }

        public Boolean Order()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = this._shoppingCartService.order(userId);

            return result;
        }

        //public IActionResult PayOrder(string stripeEmail, string stripeToken)
        //{
        //    var customerService = new CustomerService();
        //    var chargeService = new ChargeService();
        //    string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        //    var order = this._shoppingCartService.getShoppingCartInfo(userId);

        //    var customer = customerService.Create(new CustomerCreateOptions
        //    {
        //        Email = stripeEmail,
        //        Source = stripeToken
        //    });

        //var charge = chargeService.Create(new ChargeCreateOptions
        //{
        //    Amount = (Convert.ToInt32(order.TotalPrice) * 100),
        //    Description = "EShop Application Payment",
        //    Currency = "usd",
        //    Customer = customer.Id
        //});

        //    if (charge.Status == "succeeded")
        //    {
        //        var result = this.Order();

        //        if (result)
        //        {
        //            return RedirectToAction("Index", "ShoppingCard");
        //        }
        //        else
        //        {
        //            return RedirectToAction("Index", "ShoppingCard");
        //        }
        //    }

        //    return RedirectToAction("Index", "ShoppingCard");
        //}
    }
}