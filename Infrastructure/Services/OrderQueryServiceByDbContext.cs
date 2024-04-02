using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Dapper;
using Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Services
{
    public class OrderQueryService : IOrderQueryService
    {
        private readonly DatabaseContext _context;
        private readonly string _connectionStr;

        public OrderQueryService(DatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            _connectionStr = configuration.GetConnectionString("DatabaseContext");
        }

        public decimal GetCustomerOrderTotalAmount(int userId)
        {
            var temp = _context.Orders
                .Include(o => o.ArchiveOrder)
                .Where(o => o.UserId == (userId))
                .SelectMany(o => o.Tickets)
                .Select(x => new
                {
                    x.Order.ArchiveOrder.TicketPrice,
                    x.Order.ArchiveOrder.PurchaseAmount
                })
                .ToList();
            return temp
                   .Sum(od => od.PurchaseAmount * od.TicketPrice);
        }
    }
}


        //public List<Order> GetOrders(int userId)
        //{
        //    using (var context = new SqlConnection(_connectionStr))
        //    {

        //        return _context.Orders
        //            .Include(o => o.ArchiveOrder)
        //            .ThenInclude(od => od.Order.Tickets)
        //            .Where(o => o.UserId == userId)
        //            .ToList();
        //    }
        //}

       

