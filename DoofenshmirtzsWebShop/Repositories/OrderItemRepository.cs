using DoofenshmirtzsWebShop.Database;
using DoofenshmirtzsWebShop.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoofenshmirtzsWebShop.DTOs.Responses;

namespace DoofenshmirtzsWebShop.Repositories
{
    public interface IOrderItemRepository
    {
        Task<List<OrderItem>> GetAll();
        Task<OrderItem> GetById(int orderItemId);
        Task<OrderItem> Create(OrderItem orderItem);
        Task<OrderItem> Update(int orderItemId, OrderItem order);
        Task<OrderItem> Delete(int orderItemId);
    }
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly DoofenshmirtzWebShopContext _context;
        public OrderItemRepository(DoofenshmirtzWebShopContext context)
        {
            _context = context;
        }
        public async Task<OrderItem> Create(OrderItem orderItem)
        {
            _context.OrderItem.Add(orderItem);
            await _context.SaveChangesAsync();
            return orderItem;
        }

        public async Task<OrderItem> Delete(int orderItemId)
        {
            OrderItem orderItem = await _context.OrderItem.FirstOrDefaultAsync(a => a.orderItemID == orderItemId);
            if(orderItem != null)
            {
                _context.OrderItem.Remove(orderItem);
                await _context.SaveChangesAsync();
            }
            return orderItem;
        }

        public async Task<List<OrderItem>> GetAll()
        {
            return await _context.OrderItem.Include(a => a.Product).ToListAsync();
        }

        public async Task<OrderItem> GetById(int orderItemId)
        {
            return await _context.OrderItem.FirstOrDefaultAsync(b => b.orderItemID == orderItemId);
        }

        public async Task<OrderItem> Update(int orderItemId, OrderItem orderItem)
        {
             _context.OrderItem.Add(orderItem);
            await _context.SaveChangesAsync();
            return orderItem;
        }
    }
}
