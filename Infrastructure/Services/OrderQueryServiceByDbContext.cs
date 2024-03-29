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
                .Include(o => o.ArchiveOrder.Order)
                .Where(o => o.UserId == userId)
                .SelectMany(o => o.ArchiveOrder.Order.Tickets)
                .Select(x => new
                {
                    x.Order.ArchiveOrder.TicketPrice,
                    x.Order.ArchiveOrder.PurchaseAmount
                })
                .ToList();
            return temp
                .Sum(od => od.PurchaseAmount * od.TicketPrice);
        }
        public List<Order> GetOrders(int userId)
        {
            return __context.Orders
                .Include(o => o.ArchiveOrder)
                .ThenInclude(od => od.Order.Tickets)
                .Where(o => o.UserId == userId)
                .ToList();
        }
        public List<OrderQueryDto> GetOrdersByUserId(int userId)
        {

            using (var context = new SqlConnection(_connectionStr))
            {
                var orderDetail = @"SELECT
                                    O.Id AS OrderId,
                                    U.Id AS UserId,
                                    T.Id AS TicketId,
                                    E.Id AS EventId,
                                    E.EventImage,
                                    E.MainOrganizer,
                                    E.OrganizationId,
                                    ORG.OrganizationURL,
                                    E.LocationAddress,
                                    E.LocationName,
                                    E.StreamingUrl,
                                    TT.Id As TicketTypeId,
                                    TT.Name as TicketTypeName,
                                    T.Number as  TicketNumber,
                                    AO.PurchaseAmount,
                                    AO.TicketPrice,
                                    O.PaymentType,
                                    O.Status as OrderStatus,
                                    O.CreatedAt as OrderDate,
                                    O.EditedAt
                                    FROM Orders O
                                    LEFT JOIN ArchiveOrders AO ON AO.OrderId = O.Id 
                                    LEFT JOIN Tickets T ON O.TicketId = T.Id
                                    LEFT JOIN TicketTypes TT ON T.TicketTypeId =TT.Id
                                    LEFT JOIN Events E ON TT.EventId= E.Id
                                    LEFT JOIN Organizations ORG ON ORG.Id =E.OrganizationId
                                    LEFT JOIN Users U ON ORG.OwnerId = U.Id
                                    WHERE U.Id = @UserID
                                    ";

                return context.Query<OrderQueryDto>(orderDetail, new { UserID = userId }).ToList();
            }





            //    var orders = GetOrders(userId);
            //    return orders.Select(o => new OrderQueryDto
            //    {
            //        OrderId = o.ArchiveOrder.OrderId,
            //        OrderDate = o.ArchiveOrder.Order.CreatedAt,
            //        TicketId = o.ArchiveOrder.Order.TicketId,
            //        OrderDetails = new List<OrderDetailQueryDto>
            //{
            //    new OrderDetailQueryDto
            //    {
            //        EvnetId = o
            //        TicketId = o.ArchiveOrder.Order.TicketId,
            //        TicketPrice = o.ArchiveOrder.TicketPrice,
            //        PurchaseAmount = o.ArchiveOrder.PurchaseAmount,
            //        CreatedAt = o.ArchiveOrder.CreatedAt,

            //    }
            //}
            //    }).ToList();

            //}
        }
    }
}
