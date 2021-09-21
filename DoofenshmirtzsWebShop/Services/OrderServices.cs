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
        private readonly IOrderRepository _OrderRepository;
        private readonly IUserRepository _UserRepository;
        private readonly IProductRepository _productRepository;
        public OrderServices(IOrderRepository orderRepository, IUserRepository userRepository, IProductRepository productRepository)
        {
            _OrderRepository = orderRepository;
            _UserRepository = userRepository;
            _productRepository = productRepository;
        }
        public async Task<List<OrderResponse>> GetAllOrders()
        {
            List<Order> orders = await _OrderRepository.GetAll();
            return orders.Select(o => new OrderResponse
            {
                ID = o.orderID,
                date = o.orderDate,
                User = new OrderUserResponse
                {
                    ID = o.User.userID,
                    email = o.User.userEmail,
                    username = o.User.userName
                }

            }).ToList();
        }
        public async Task<OrderResponse> GetById(int orderId)
        {
            Order order = await _OrderRepository.GetById(orderId);
            return order == null ? null : new OrderResponse
            {
                ID = order.orderID,
                date = order.orderDate,
                User = new OrderUserResponse
                {

                    ID = order.User.userID,
                    email = order.User.userEmail,
                    username = order.User.userName,
                    address = order.User.address.Select(a => new AddressResponse
                    {
                        ID = a.addressID,
                        customerName = a.addressCustomerName,
                        streetName = a.addressStreetName,
                        postalCode = a.addressPostalCode,
                        countryName = a.addressCountryName,
                    }).ToList()

                },
                OrderItems = order.orderItems.Select( a => new OrderOrderItemResponse
                {
                    ID = a.orderItemID,
                    quantity = a.orderItemQuantity,
                    price = a.orderItemPrice,
                    orderID = a.orderID
                }).ToList()

            };
        }
        public async Task<OrderResponse> Create(NewOrder newOrder)
        {
           
            Order order = new()
            {
                orderDate = newOrder.orderDate,
                userID = newOrder.userID
            };
            order = await _OrderRepository.Create(order);
            order.User = await _UserRepository.getByID(order.userID);
            return order == null ? null : new OrderResponse
            {
                ID = order.orderID,
                date = order.orderDate,
                User = new OrderUserResponse
                {
                    ID = order.User.userID,
                    email = order.User.userEmail,
                    username = order.User.userName
                }
            };
        }

        public async Task<OrderResponse> Update(int orderId, UpdateOrder updateOrder)
        {
            Order order = new Order
            {
                orderDate = updateOrder.orderDate,
                userID = updateOrder.userID
            };
            order = await _OrderRepository.Update(orderId, order);
            order.User = await _UserRepository.getByID(order.userID);
            //order.orderItems = await _productRepository.
            return order == null ? null : new OrderResponse
            {
                ID = order.orderID,
                date = order.orderDate,
                User = new OrderUserResponse
                {
                    ID = order.User.userID,
                    email = order.User.userEmail,
                    username = order.User.userName
                },
                
            };
        }
        public async Task<bool> Delete(int orderId)
        {
            var result = await _OrderRepository.Delete(orderId);
            return true;
        }

    }
}
