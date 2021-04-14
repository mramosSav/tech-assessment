using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderAPI.Domain.Models;
using OrderAPI.Domain.Repositories;
using OrderAPI.Persistence.Contexts;

namespace OrderAPI.Persistence.Repositories
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Order>> ListAsync()
        {
            return await _context.Orders.ToListAsync();
        }
    }
}
