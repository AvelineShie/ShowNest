using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IOrderQueryService
    {
        List<OrderQueryDto> GetOrdersByUserId(string userId);
        List<Order> GetOrders(string customerId);
        decimal GetCustomerOrderTotalAmount(string customerId);
    }
    public class OrderQueryDto
    {
        public int OrderId { get; set; }
        public string UserName { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderDetailQueryDto> OrderDetails { get; set; }
    }
    public class OrderDetailQueryDto
    {
        public int EvnetId { get; set; }
        public string EvnetName { get; set; }
        public int Quantity { get; set; }
        public decimal SellingPrice { get; set; }
    }

}
