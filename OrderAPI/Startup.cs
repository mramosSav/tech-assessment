using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OrderAPI.Domain.Repositories;
using OrderAPI.Domain.Services;
using OrderAPI.Persistence.Contexts;
using OrderAPI.Persistence.Repositories;
using OrderAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderAPI.Domain.Models;

namespace OrderAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<AppDbContext>(options => {
                options.UseInMemoryDatabase("OrderAPI-in-memory");
            });

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            AddTestData(context);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void AddTestData(AppDbContext context)
        {
            var testOrder = new Order { Id = 100, PhoneNumber = 3245687653, Product = "Toaster" };

            var testCusty = new Customer { FirstName = "Yolanda", LastName = "Faren", Age = 23, StreetAddress = "123 goober ave", City = "Goobville", State = "GB", PostalCode = 60006, PhoneNumber = 3245687653};

            context.Orders.Add(testOrder);
            context.Customers.Add(testCusty);
            context.SaveChanges();
        }
    }
}
