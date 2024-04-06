using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Infrastructure.Services
{
    public class OrderCenterService : IOrderCenterService
    {
        private readonly DatabaseContext _context;
        private readonly string _connectionStr;

        public OrderCenterService(DatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            _connectionStr = configuration.GetConnectionString("DatabaseContext");
        }

        public async Task<Dictionary<string, string>> GenerateOrderAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetCustomerOrderNameAsync(string orderId)
        {
            var order = _context.Orders
            .Include(o => o.ArchiveOrder)
            .FirstOrDefault(o => o.Id.ToString() == orderId);

            if (order == null)
            {
                throw new Exception("Order not found");
            }

            return Task.FromResult(order.ArchiveOrder.EventName);
        }

        public Task<int> GetCustomerOrderTotalAmountAsync(string userId)
        {
            var temp = _context.Orders
                  .Include(o => o.ArchiveOrder)
                  .Where(o => o.UserId.ToString() == (userId))
                  .SelectMany(o => o.Tickets)
                  .Select(x => new
                  {
                      x.Order.ArchiveOrder.TicketPrice,
                      x.Order.ArchiveOrder.PurchaseAmount
                  })
                  .ToList();
            return Task.FromResult((int)temp
                   .Sum(od => od.PurchaseAmount * od.TicketPrice));
        }
    }
}
       

