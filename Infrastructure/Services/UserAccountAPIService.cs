using ApplicationCore;
using ApplicationCore.Helpers;
using ApplicationCore.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Services
{
    public class UserAccountAPIService : IUserAccountAPIService
    {
        private readonly string _connectionStr;
        public UserAccountAPIService(IConfiguration configuration)
        {
            _connectionStr = configuration.GetConnectionString("DatabaseContext");
        }

        public OperationResult GetUserOrderDetailListByUserId(string userId)

        {

            using (SqlConnection connection = new SqlConnection(_connectionStr))
            {
                var sql = @"
                            SELECT
                             O.Id AS OrderId,
                             O.EcpayTradeNo,
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
                             COUNT(T.Id) AS TicketAmount,
                             SUM(TT.Price) AS TotalPrice,
                            TT.Name AS TicketTypeName
                            FROM Orders O

                            LEFT JOIN EVENTS E ON O.EventId= E.Id
                            LEFT JOIN Tickets T ON T.OrderId = O.Id
                            LEFT JOIN TicketTypes TT ON T.TicketTypeId = TT.Id
                            LEFT JOIN Users U ON O.UserId = U.Id
                            LEFT JOIN Organizations ORG ON E.OrganizationId = ORG.Id

                            WHERE U.Id = @userId


                            GROUP BY O.Id, O.EcpayTradeNo, O.PaymentType, O.Status, O.CreatedAt, O.EditedAt, U.Id, E.Id, E.EventImage, 
                            E.Name, E.StartTime, E.MainOrganizer, E.OrganizationId, 
                            E.LocationAddress, E.LocationName, E.StreamingUrl, ORG.OrganizationURL ,TT.NAME
                            ";

                try
                {
                    var data = connection.Query(sql, new { UserID = userId }).ToList();
                    return OperationResultHelper.ReturnSuccessData(data);
                }
                catch (Exception ex)
                {
                    return OperationResultHelper.ReturnErrorMsg(ex.Message);
                }
            }
        }
    }
}
