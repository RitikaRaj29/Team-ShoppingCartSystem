﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingCartSystem.Models;
using OnlineShoppingCartSystem.Repository;
using OnlineShoppingCartSystem.Services.Customer;

namespace OnlineShoppingCartSystem.Controllers.Customer
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public readonly OrderService _orderService;
        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrders();
            return Ok(orders);
                                          
        }

        [HttpGet("{userid:int}")]
        public async Task<IActionResult> GetOrdersById(int userid)
        {
            var order = await _orderService.GetOrdersByUserId(userid);
            if(order == null)
            {
                return NotFound();  
            }
            return Ok(order);
        }

        //[HttpPost]
        //public async Task<IActionResult> InsertOrder([Bind()]Orders entity)
        //{
        //    await _orderService.InsertOrder(entity);
        //    await _orderService.Save();
        //    return Ok();   

            

           
        //}


    }
}
