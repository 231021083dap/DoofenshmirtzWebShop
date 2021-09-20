using DoofenshmirtzsWebShop.Database.Entities;
using DoofenshmirtzsWebShop.DTOs.Requests;
using DoofenshmirtzsWebShop.DTOs.Responses;
using DoofenshmirtzsWebShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoofenshmirtzsWebShop.Services
{
    public interface IOrderItemService
    {
        Task<List<OrderItemResponse>> GetAllOrderItems();
        Task<OrderItemResponse> GetById(int oderItemid);
        Task<OrderItemResponse> Create(NewOrderItem newOrderItem);
        Task<OrderItemResponse> Update();
        Task<OrderItemResponse> Delete();
    }
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IProductRepository _orderProductRepository;
        public OrderItemService(IOrderItemRepository orderItemRepository, IProductRepository productRepository)
        {
            _orderItemRepository = orderItemRepository;
            _orderProductRepository = productRepository;
        }

        public Task<OrderItemResponse> Create(NewOrderItem newOrderItem)
        {
            throw new NotImplementedException();
        }

        public Task<OrderItemResponse> Delete()
        {
            throw new NotImplementedException();
        }

        public async Task<List<OrderItemResponse>> GetAllOrderItems()
        {
            List<OrderItem> orderItems = await _orderItemRepository.GetAll();
            return orderItems.Select(o => new OrderItemResponse
            {
                ID = o.orderItemID,
                quantity = o.orderItemQuantity,
                price = o.orderItemPrice,
                Products = new ProductResponse
                {
                    ID = o.Products.productID,
                    name = o.Products.productName,
                    stock = o.Products.productStock,
                    price = o.Products.productPrice,
                    description = o.Products.productDescription,
                    categoryId = o.Products.categoryID,
                },
                
                
            }).ToList();
        }

        public Task<OrderItemResponse> GetById(int oderItemid)
        {
            throw new NotImplementedException();
        }

        public Task<OrderItemResponse> Update()
        {
            throw new NotImplementedException();
        }
    }
}
