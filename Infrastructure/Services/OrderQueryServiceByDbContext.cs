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
    public class OrderQueryService:IOrderQueryService
    {
        private readonly DatabaseContext __context;
        private readonly string custormerId;

        public OrderQueryService(DatabaseContext context, string custormerId)
        {
            __context = context;
            this.custormerId = custormerId;
        }

        public decimal GetCustomerOrderTotalAmount(string customerId)
        {
            throw new NotImplementedException();
        }

        public List<OrderQueryDto> GetOrdersByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        List<Order> IOrderQueryService.GetOrders(string customerId)
        {
            return __context.Orders.ToList();
        }
    }
}
