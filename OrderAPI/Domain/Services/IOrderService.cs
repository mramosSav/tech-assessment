using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderAPI.Domain.Models;

namespace OrderAPI.Domain.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> ListAsync();
    }
}
