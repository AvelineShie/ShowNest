using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IOrderQueryService
    {
        List<OrderQueryDto> GetOrdersByUserId(int userId);
        List<Order> GetOrders(int userId);
        decimal GetCustomerOrderTotalAmount(int userId);
    }
    public class OrderQueryDto
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int TicketId {  get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderDetailQueryDto> OrderDetails { get; set; }
    }
    public class OrderDetailQueryDto
    {
        public int EvnetId { get; set; }       
        public string EvnetName { get; set; }
        public DateTime EventStartTime { get; set; }

        // Event Status
        public string OrderStatus { get; set; }

        // Event Information
        public string EventName { get; set; }
        public string EventHost { get; set; }
        public string EventLocation { get; set; }
        public string LocationAddress { get; set; }  
        public string LocationName {  get; set; }
        public string StreamingPlatform { get; set; }
        public string StreamingUrl { get; set; }
        public int TicketId { get; set; }
        public string TicketTypeName { get; set; } 
        public string TicketNumber { get; set; }
        public string SeatNumber { get; set; }
        public decimal TicketPrice { get; set; }
        public int PurchaseAmount { get; set; }
        public byte PaymentType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? EditedAt { get; set; }

    }

}
