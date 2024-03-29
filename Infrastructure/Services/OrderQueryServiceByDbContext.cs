using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
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
        private readonly string _connectionStr;

        public OrderQueryService(DatabaseContext context, IConfiguration configuration)
        {
            __context = context;
            _connectionStr = configuration.GetConnectionString("DatabaseContext");
        }

        public decimal GetCustomerOrderTotalAmount(int userId)
        {
            var temp = __context.Orders
                .Include(o=>o.ArchiveOrder.Order)
                .Where(o=>o.UserId==userId)
                .SelectMany(o=>o.ArchiveOrder.Order.Tickets)
                .Select(x => new
                {
                    x.Order.ArchiveOrder.TicketPrice,
                    x.Order.ArchiveOrder.PurchaseAmount
                })
                .ToList();
            return temp 
                .Sum(od=>od.PurchaseAmount*od.TicketPrice);
        }
        public List<Order> GetOrders(int userId)
        {
            return __context.Orders
                .Include(o=>o.ArchiveOrder)
                .ThenInclude(od=>od.Order.Tickets)
                .Where(o=>o.UserId==userId)
                .ToList();
        }
        //public List<OrderQueryDto> GetOrdersByUserId(int userId)
        //{
        //    var orders = GetOrders(userId);
        //    return orders.Select(o=> new OrderQueryDto
        //    {
        //        OrderId=o.ArchiveOrder.OrderId,
        //        OrderDate=o.ArchiveOrder.Order.CreatedAt,
        //        OrderDetails =ArchiveOrder.Select(od=>new OrderDetailQueryDto
        //        {
        //            OrderId=od.Order.OrderId,
        //            TicketId=od.Order.TicketId,
        //            TicketPrice=od.Order.TicketPrice,
        //            PurchaseAmount=od.Order.PurchaseAmount,
        //            PurchaseDate=od.Order.PurchaseDate,
        //            PurchaseDetails=od.Order.PurchaseDetails
                    
        //        }).ToList()

        //    }).ToList();

        //}
    }
}
