using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderAPI.Domain.Models;
using OrderAPI.Domain.Services;
using OrderAPI.Domain.Repositories;

namespace OrderAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this._orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Order>> ListAsync()
        {
            return await _orderRepository.ListAsync();
        }
    }
}
