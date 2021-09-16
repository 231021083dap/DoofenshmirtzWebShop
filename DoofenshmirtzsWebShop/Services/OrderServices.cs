using DoofenshmirtzsWebShop.DTOs.Requests;
using DoofenshmirtzsWebShop.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoofenshmirtzsWebShop.Repositories;
using DoofenshmirtzsWebShop.Database.Entities;

namespace DoofenshmirtzsWebShop.Services
{
    public interface IOrderService
    {
        Task<List<OrderResponse>> GetAllOrders();
        Task<OrderResponse> GetById(int orderId);
        Task<OrderResponse> Create(NewOrder newOrder);
        Task<OrderResponse> Update(int orderId, UpdateOrder updateOrder);
        Task<bool> Delete(int orderId);
    }
    public class OrderServices : IOrderService
    {
        private readonly IOrderRepository _IOrderRepository;
        public OrderServices(IOrderRepository orderRepository)
        {
            _IOrderRepository = orderRepository;
        }
        public async Task<List<OrderResponse>> GetAllOrders()
        {
            List<Order> orders = await _IOrderRepository.GetAll();
            return orders.Select(o => new OrderResponse
            {
                ID = o.orderID,
                date = o.orderDate,
             

            }).ToList();
        }
        public Task<OrderResponse> GetById(int orderId)
        {
            throw new NotImplementedException();
        }
        public Task<OrderResponse> Create(NewOrder newOrder)
        {
            throw new NotImplementedException();
        }

        public Task<OrderResponse> Update(int orderId, UpdateOrder updateOrder)
        {
            throw new NotImplementedException();
        }
        public Task<bool> Delete(int orderId)
        {
            throw new NotImplementedException();
        }

    }
}
