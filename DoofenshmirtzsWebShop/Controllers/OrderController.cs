using DoofenshmirtzsWebShop.DTOs.Requests;
using DoofenshmirtzsWebShop.DTOs.Responses;
using DoofenshmirtzsWebShop.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoofenshmirtzsWebShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<OrderResponse> orders = await _orderService.GetAllOrders();
                if(orders == null)
                {
                    return Problem("Got nothing... Unexpected");
                }
                if(orders.Count == 0)
                {
                    return NoContent();
                }
                return Ok(orders);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetById([FromRoute] int orderId)
        {
            try
            {
                OrderResponse order = await _orderService.GetById(orderId);
                if (order == null)
                {
                    return NotFound();
                }
                return Ok(order);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NewOrder newOrder)
        {
            try
            {
                OrderResponse order = await _orderService.Create(newOrder);
                if(order == null)
                {
                    return Problem("Order was not created, something went wrong");
                }
                return Ok(order);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }
        [HttpDelete("{orderId}")]
        public async Task<IActionResult> Delete([FromRoute] int orderId)
        {
            try
            {
                bool result = await _orderService.Delete(orderId);
                if(!result)
                {
                    return Problem("Order was not deleted, something went wrong");
                }
                return NoContent();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }
        [HttpPut("{orderId}")]
        public async Task<IActionResult> Update([FromRoute] int orderId, [FromBody] UpdateOrder updateOrder)
        {
            try
            {
                OrderResponse order = await _orderService.Update(orderId, updateOrder);
                if(order == null)
                {
                    return Problem("Order was not updated, something went wrong");
                }
                return Ok(order);
            }
            catch (Exception Ex)
            {

                return Problem(Ex.Message);
            }
        }
    }
}
