using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class OrderQueryServiceByDbContext:IOrderQueryService
    {
        private readonly DatabaseContext __context;
        private readonly string custormerId;

        public OrderQueryServiceByDbContext(DatabaseContext context, string custormerId)
        {
            __context = context;
            this.custormerId = custormerId;
        }


        List<Order> IOrderQueryService.GetOrders(string customerId)
        {
            return __context.Orders.ToList();
        }
    }
}
