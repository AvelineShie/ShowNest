using ApplicationCore;
using ApplicationCore.Entities;
using ApplicationCore.Helpers;
using ApplicationCore.Interfaces;
using Dapper;
using Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Infrastructure.Services
{
    public class OrderAPIService : IOrderQueryService
    {
        private readonly DatabaseContext _context;
        private readonly string _connectionStr;

        public OrderAPIService(DatabaseContext context, IConfiguration configuration)
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

        public OperationResult GetOrderDetailByOrderId(string userId, int orderId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionStr))
            {
                var sql = @"
                            SELECT
                             O.Id AS OrderId,
                             O.PaymentType,
                             O.Status AS OrderStatus,
                             O.CreatedAt AS OrderDate,
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
                             AO.TicketPrice,
                             AO.PurchaseAmount,
                             SUM(AO.TicketPrice * AO.PurchaseAmount) AS TotalPrice,
                             O.ContactPerson,
                             O.ParticipantPeople,

                             (
                                   SELECT
                                        T.Id AS TicketId,
                                        T.Number AS TicketNumber,
                                        T.CheckCode,
                                        TT.Id AS TicketTypeId,
                                        TT.Name AS TicketTypeName,
                                        TT.Price AS TicketPrice,
                                        S.SeatAreaId,
                                        SA.Name AS SeatAreaName,
                                        S.Id AS SeatID,
                                        S.Number AS SeatNumber
                                    FROM Tickets T
                                    LEFT JOIN TicketTypes TT ON T.TicketTypeId = TT.Id
                                    LEFT JOIN Seats S ON S.Id = T.SeatId
                                    LEFT JOIN SeatAreas SA ON S.SeatAreaId = SA.Id
                                    WHERE T.OrderId = O.Id
                                    FOR JSON PATH
                                ) AS TicketList

                             FROM Orders O
                             LEFT JOIN ArchiveOrders AO ON AO.OrderId = O.Id
                             LEFT JOIN Tickets T ON O.TicketId = T.Id
                             LEFT JOIN Seats S ON S.Id = T.SeatId
                             LEFT JOIN SeatAreas SA ON S.SeatAreaId = SA.Id
                             LEFT JOIN TicketTypes TT ON T.TicketTypeId = TT.Id
                             LEFT JOIN Events E ON TT.EventId = E.Id
                             LEFT JOIN Organizations ORG ON ORG.Id = E.OrganizationId
                             LEFT JOIN Users U ON ORG.OwnerId = U.Id
                             LEFT JOIN LogInInfo LI ON U.Id = LI.UserId
                            WHERE U.Id = @UserID AND O.Id=@OrderID

                             GROUP BY O.Id,U.Id,T.Id,E.Id,E.EventImage,E.StartTime,E.Name,E.MainOrganizer,S.SeatAreaId,SA.Name,S.Id,S.Number,AO.TicketPrice,
                             E.OrganizationId,ORG.OrganizationURL,E.LocationAddress,E.LocationName,E.StreamingUrl,TT.Id,O.ContactPerson,
                             O.ParticipantPeople,TT.Name,T.Number,AO.PurchaseAmount,O.PaymentType,O.Status,O.CreatedAt,O.EditedAt,T.CheckCode
                            ";

                try
                {
                    var data = connection.Query(sql, new { UserID = userId, OrderID = orderId }).First();
                    return OperationResultHelper.ReturnSuccessData(data);
                }
                catch (Exception ex)
                {
                    return OperationResultHelper.ReturnErrorMsg(ex.Message);
                }
            }
        }

        public OperationResult UpdateOrderContactPerson(string contactPersonJson, int orderId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionStr))
            {
                var sql = @"
                            UPDATE Orders
                            SET ContactPerson=@ContactPersonJson
                            WHERE id=@OrderID;
                            ";

                try
                {
                    connection.Query(sql, new { ContactPersonJson = contactPersonJson, OrderID = orderId });
                    return OperationResultHelper.ReturnSuccessData("Update Success!");
                }
                catch (Exception ex)
                {
                    return OperationResultHelper.ReturnErrorMsg(ex.Message);
                }
            }
        }

        public class OrderContactPerson
        {
            public string ContactPersonJson { get; set; }
            public int OrderID { get; set; }
        }



    }

}

       

