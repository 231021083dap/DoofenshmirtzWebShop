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
        Task<OrderItemResponse> GetById(int orderItemID);
        Task<OrderItemResponse> Create(NewOrderItem newOrderItem);
        Task<OrderItemResponse> Update(int orderItemID, UpdateOrderItem updateOrderItem);
        Task<bool> Delete(int orderItemID);
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

        public async Task<OrderItemResponse> Create(NewOrderItem newOrderItem)
        {
            OrderItem orderItem = new OrderItem
            {
                orderItemQuantity = newOrderItem.orderItemQuantity,
                orderItemPrice = newOrderItem.orderItemPrice,
                orderID = newOrderItem.orderID
            };
            orderItem = await _orderItemRepository.Create(orderItem);
            if(orderItem != null)
            {
                orderItem.Product = await _orderProductRepository.getProductById(orderItem.productID);
                return new OrderItemResponse
                {
                    ID = orderItem.orderItemID,
                    quantity = orderItem.orderItemQuantity,
                    price = orderItem.orderItemPrice,
                    orderID = orderItem.orderItemID,
                    Product = new ProductResponse
                    {
                        ID = orderItem.Product.productID,
                        name = orderItem.Product.productName,
                        price = orderItem.Product.productPrice,
                        stock = orderItem.Product.productStock,
                        description = orderItem.Product.productDescription,
                        category = new ProductCategoryResponse
                        {
                            joinCategoryId = orderItem.Product.Category.categoryID,
                            categoryName = orderItem.Product.Category.categoryName
                        }

                    }
                };
            }
            return null;
           
        }

        public async Task<bool> Delete(int orderItemID)
        {
            var result = await _orderItemRepository.Delete(orderItemID);
            return true;
        }

        public async Task<List<OrderItemResponse>> GetAllOrderItems()
        {
            List<OrderItem> orderItems = await _orderItemRepository.GetAll();
            return orderItems.Select(o => new OrderItemResponse
            {
                ID = o.orderItemID,
                quantity = o.orderItemQuantity,
                price = o.orderItemPrice,
                orderID = o.orderID,
                Product = new ProductResponse
                {
                    ID = o.Product.productID,
                    name = o.Product.productName,
                    stock = o.Product.productStock,
                    price = o.Product.productPrice,
                    description = o.Product.productDescription,
                    category = new ProductCategoryResponse
                    {
                        joinCategoryId = o.Product.categoryID,
                        categoryName = o.Product.Category.categoryName
                    }
                },
                
                
            }).ToList();
        }

        public async Task<OrderItemResponse> GetById(int oderItemid)
        {
            OrderItem orderItem = await _orderItemRepository.GetById(oderItemid);
            return orderItem == null ? null : new OrderItemResponse
            {
                ID = orderItem.orderItemID,
                quantity = orderItem.orderItemQuantity,
                price = orderItem.orderItemPrice,
                orderID = orderItem.orderID,
                Product = new ProductResponse
                {
                    ID = orderItem.Product.productID,
                    price = orderItem.Product.productPrice,
                    stock = orderItem.Product.productStock,
                    description = orderItem.Product.productDescription,
                    category = new ProductCategoryResponse
                    {
                        joinCategoryId = orderItem.Product.categoryID,
                        categoryName = orderItem.Product.Category.categoryName
                    }


                }

            };
        }

        public async Task<OrderItemResponse> Update(int orderItemID, UpdateOrderItem updateOrderItem)
        {
            OrderItem orderItem = new OrderItem
            {
                orderItemQuantity = updateOrderItem.orderItemQuantity,
                orderItemPrice = updateOrderItem.orderItemPrice,
                orderID = updateOrderItem.orderID
            };
            orderItem = await _orderItemRepository.Update(orderItemID, orderItem);
            orderItem.Product = await _orderProductRepository.getProductById(orderItem.productID);
            return orderItem == null ? null : new OrderItemResponse
            {
                ID = orderItem.orderItemID,
                quantity = orderItem.orderItemQuantity,
                price = orderItem.orderItemPrice,
                orderID = orderItem.orderID,
                Product = new ProductResponse
                {
                    ID = orderItem.Product.productID,
                    price = orderItem.Product.productPrice,
                    stock = orderItem.Product.productStock,
                    description = orderItem.Product.productDescription,
                    category = new ProductCategoryResponse
                    {
                        joinCategoryId = orderItem.Product.Category.categoryID,
                        categoryName = orderItem.Product.Category.categoryName
                    }
                }
            };

        }
    }
}
