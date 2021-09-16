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
    }
    public class OrderRepository : IOrderRepository
    {
        private readonly DoofenshmirtzWebShopContext _context;
        public OrderRepository( DoofenshmirtzWebShopContext context)
        {
            _context = context;
        }
        public async Task<List<Order>> GetAll()
        {
            return await _context.Order.Include(a => a.orderID).ToListAsync();
 
        }
    }
}
