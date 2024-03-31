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


        public List<Order> GetOrders(int userId)
        {
            using (var context = new SqlConnection(_connectionStr))
            {

                return _context.Orders
                    .Include(o => o.ArchiveOrder)
                    .ThenInclude(od => od.Order.Tickets)
                    .Where(o => o.UserId == userId)
                    .ToList();
            }
        }

        public List<OrderQueryDto> GetOrdersByUserId(int userId)
        {

            using (var context = new SqlConnection(_connectionStr))
            {
                var orders = @"SELECT
                                        O.Id AS OrderId,
                                        O.PaymentType,
                                        O.Status as OrderStatus,
                                        O.CreatedAt as OrderDate,
                                        O.EditedAt,
                                        U.Id AS UserId,
                                        E.Id AS EventId,
                                        E.EventImage,
                                        E.Name AS EventName,
                                        E.StartTime AS EventStartTime,
                                        E.MainOrganizer,
                                        E.OrganizationId,
                                        E.LocationAddress,
                                        E.LocationName,
                                        E.StreamingUrl,
                                        ORG.OrganizationURL,
                                        T.Id AS TicketId,
                                        T.Number as  TicketNumber,
                                        T.CheckCode,
                                        TT.Id As TicketTypeId,
                                        TT.Name as TicketTypeName,
                                        S.SeatAreaId,
                                        SA.Name as SeatAreaName,
                                        S.Id AS SeatID,
                                        S.Number as SeatNumber,
                                        AO.TicketPrice,
                                        AO.PurchaseAmount,
                                        SUM(AO.TicketPrice*AO.PurchaseAmount) AS TotalPrice,
                                        U.Nickname as UserName,
                                        LI.Email AS UserEmail,
                                        U.Mobile AS UserPhoneNumber
                                        FROM Orders O
                                        LEFT JOIN ArchiveOrders AO ON AO.OrderId = O.Id 
                                        LEFT JOIN Tickets T ON O.TicketId = T.Id
                                        LEFT JOIN Seats S ON S.Id = T.SeatId
                                        LEFT JOIN SeatAreas SA ON S.SeatAreaId = SA.Id
                                        LEFT JOIN TicketTypes TT ON T.TicketTypeId =TT.Id
                                        LEFT JOIN Events E ON TT.EventId= E.Id
                                        LEFT JOIN Organizations ORG ON ORG.Id =E.OrganizationId
                                        LEFT JOIN Users U ON ORG.OwnerId = U.Id
                                        LEFT JOIN LogInInfo LI ON U.Id = LI.UserId
                                        WHERE U.Id = @UserID  

                                        GROUP BY O.Id,U.Id,T.Id,E.Id,E.EventImage,E.StartTime,E.Name,E.MainOrganizer,S.SeatAreaId,SA.Name,S.Id,S.Number,AO.TicketPrice,
                                        E.OrganizationId,ORG.OrganizationURL,E.LocationAddress,E.LocationName,E.StreamingUrl,TT.Id,U.Nickname,LI.Email,U.Mobile,
                                        TT.Name,T.Number,AO.PurchaseAmount,O.PaymentType,O.Status,O.CreatedAt,O.EditedAt,T.CheckCode  
                                    ";

                return context.Query<OrderQueryDto>(orders, new { UserID = userId }).ToList();
            }

        }

        public List<Object> GetOrdersDetailByUserId(int userId)
        {

            using (var context = new SqlConnection(_connectionStr))
            {
                var orderDetail = @"SELECT
                                        O.Id AS OrderId,
                                        O.PaymentType,
                                        O.Status as OrderStatus,
                                        O.CreatedAt as OrderDate,
                                        O.EditedAt,
                                        U.Id AS UserId,
                                        E.Id AS EventId,
                                        E.EventImage,
                                        E.Name AS EventName,
                                        E.StartTime AS EventStartTime,
                                        E.MainOrganizer,
                                        E.OrganizationId,
                                        E.LocationAddress,
                                        E.LocationName,
                                        E.StreamingUrl,
                                        ORG.OrganizationURL,
                                        T.Id AS TicketId,
                                        T.Number as  TicketNumber,
                                        TT.Id As TicketTypeId,
                                        TT.Name as TicketTypeName,
                                        S.SeatAreaId,
                                        SA.Name as SeatAreaName,
                                        S.Id AS SeatID,
                                        S.Number as SeatNumber,
                                        AO.TicketPrice,
                                        AO.PurchaseAmount,
                                        SUM(AO.TicketPrice*AO.PurchaseAmount) AS TotalPrice,
                                        U.Nickname as UserName,
                                        LI.Email AS UserEmail,
                                        U.Mobile AS UserPhoneNumber
                                        FROM Orders O
                                        LEFT JOIN ArchiveOrders AO ON AO.OrderId = O.Id 
                                        LEFT JOIN Tickets T ON O.TicketId = T.Id
                                        LEFT JOIN Seats S ON S.Id = T.SeatId
                                        LEFT JOIN SeatAreas SA ON S.SeatAreaId = SA.Id
                                        LEFT JOIN TicketTypes TT ON T.TicketTypeId =TT.Id
                                        LEFT JOIN Events E ON TT.EventId= E.Id
                                        LEFT JOIN Organizations ORG ON ORG.Id =E.OrganizationId
                                        LEFT JOIN Users U ON ORG.OwnerId = U.Id
                                        LEFT JOIN LogInInfo LI ON U.Id = LI.UserId
                                        WHERE U.Id = @UserID  

                                        GROUP BY O.Id,U.Id,T.Id,E.Id,E.EventImage,E.StartTime,E.Name,E.MainOrganizer,S.SeatAreaId,SA.Name,S.Id,S.Number,AO.TicketPrice,
                                        E.OrganizationId,ORG.OrganizationURL,E.LocationAddress,E.LocationName,E.StreamingUrl,TT.Id,U.Nickname,LI.Email,U.Mobile,
                                        TT.Name,T.Number,AO.PurchaseAmount,O.PaymentType,O.Status,O.CreatedAt,O.EditedAt   
                                    ";

                return context.Query<Object>(orderDetail, new { UserID = userId }).ToList();
            }


        }

    }
}

