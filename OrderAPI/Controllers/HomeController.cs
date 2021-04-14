using Microsoft.AspNetCore.Mvc;
using OrderAPI.Domain.Models;
using OrderAPI.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderAPI.Persistence.Contexts;

namespace OrderAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {

        private readonly IOrderService _orderService;
        public AppDbContext _context;

        public HomeController(IOrderService orderService, AppDbContext context)
        {
            _orderService = orderService;
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            var orders = await _orderService.ListAsync();
            return orders;
        }

        [HttpGet("listBy")]
        public async Task<IEnumerable<Order>> GetWithFilter(long pNum)
        {
            var orders = await _orderService.ListAsync();
            var custName = _context.Customers.Where(c => c.PhoneNumber == pNum).FirstOrDefault();

            return orders.Where(o => o.PhoneNumber == pNum);
        }

        [HttpGet("add")]
        public ActionResult createOrder(long pNum, string product)
        {
            _context.Orders.Add(new Order { PhoneNumber = pNum, Product = product});
            _context.SaveChanges();
            return Redirect(Url.Content("~/home"));
        }

        [HttpGet("update")]
        public ActionResult updateOrder(long pNum, string product, string prodNew)
        {
            var curOrder = _context.Orders.Where(o => o.PhoneNumber == pNum && o.Product == product).FirstOrDefault();
            curOrder.Product = prodNew;
            _context.SaveChanges();
            return Redirect(Url.Content("~/home"));
        }

        [HttpGet("cancel")]
        public ActionResult cancelOrder(long pNum, string product)
        {
            var curOrder = _context.Orders.Where(o => o.PhoneNumber == pNum && o.Product == product).FirstOrDefault();
            _context.Orders.Remove(curOrder);
            _context.SaveChanges();
            return Redirect(Url.Content("~/home"));
        }
    }
}
