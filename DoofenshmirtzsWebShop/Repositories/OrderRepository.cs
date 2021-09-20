using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoofenshmirtzsWebShop.Database.Entities;
using Microsoft.EntityFrameworkCore;
using DoofenshmirtzsWebShop.Database;
using DoofenshmirtzsWebShop.Services;
using DoofenshmirtzsWebShop.Repositories;
using DoofenshmirtzsWebShop.DTOs.Responses;

namespace DoofenshmirtzsWebShop.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAll();
        Task<Order> GetById(int orderId);
        Task<Order> Create(Order order);
        Task<Order> Update(int orderId, Order order);
        Task<Order> Delete(int orderId);
    }
    public class OrderRepository : IOrderRepository
    {
        private readonly DoofenshmirtzWebShopContext _context;
        public OrderRepository(DoofenshmirtzWebShopContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAll()
        {
            return await _context.Order.Include(a => a.Users).Include(i => i.orderItems)
                .ToListAsync();

        }
        public async Task<Order> GetById(int orderId)
        {
            return await _context.Order.FirstOrDefaultAsync(b => b.orderID == orderId);
        }
        public async Task<Order> Create(Order order)
        {
            _context.Order.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }
        public async Task<Order> Update(int orderId, Order order)
        {
            Order updateOrder = await _context.Order.FirstOrDefaultAsync(a => a.orderID == orderId);
            if(updateOrder != null)
            {
                //updateOrder.orderID = order.orderID;
                updateOrder.orderDate = order.orderDate;
                updateOrder.userID = order.userID;
                updateOrder.orderItemId = order.orderItemId;
                await _context.SaveChangesAsync();
            }
            return updateOrder;
        }
        public async Task<Order> Delete(int orderId)
        {
            Order order = await _context.Order.
                FirstOrDefaultAsync(a => a.orderID == orderId);
            if(order != null)
            {
                _context.Order.Remove(order);
                await _context.SaveChangesAsync();
            }
            return order;
        }
    }
}
