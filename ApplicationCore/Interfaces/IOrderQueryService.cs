using ApplicationCore.Entities;
using DemoShop.ApplicationCore.Interfaces.TodoService.Dto;
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
        //List<OrderQueryDto> GetOrdersByUserId(int userId);
        //List<Order> GetOrders(int userId);
        decimal GetCustomerOrderTotalAmount(int userId);
        OperationResult GetOrderDetailByOrderId(string userId, int orderId);
        OperationResult UpdateOrderContactPerson(string contactPersonJson, int orderId);
    };
    //public class OrderQueryDto
    //{
    //    public int OrderId { get; set; }
    //    public int UserId { get; set; }
    //    public DateTime OrderDate { get; set; }
    //    public DateTime? EditedAt { get; set; }
    //    public string UserEmail { get; set; }
    //    public string UserName { get; set; }
    //    public int UserPhoneNumber { get; set; }
    //    public string StreamingUrl { get; set; }
    //    public int OrganizationId { get; set; }
    //    public int EvnetId { get; set; }
    //    public DateTime EventStartTime { get; set; }
    //    public string MainOrganizer { get; set; }
    //    public string OrganizationURL { get; set; }

    //    public string OrganizationUrl { get; set; }

    //    public string EventName { get; set; }
    //    public string EventImage { get; set; }
    //    public string EventHost { get; set; }
    //    public string LocationName { get; set; }
    //    public string LocationAddress { get; set; }  
       
    //    public int OrderStatus { get; set; }
    //    public byte PaymentType { get; set; }

    //    public List<OrderDetailQueryDto> orderDetailQueryDtos { get; set; }
       
    //}
    //public class OrderDetailQueryDto
    //{
    //    public int TicketTypeId {  get; set; }
     
    //    public string TicketTypeName { get; set; }
    //    public int TicketId { get; set; }
    //    public string TicketNumber { get; set; }
    //    public int SeatAreaId { get; set; }
    //    public string SeatArea { get; set; }
    //    public int SeatsId { get; set; }
    //    public int SeatNumber { get; set; }
    //    public decimal TicketPrice { get; set; }
    //    public int PurchaseAmount { get; set; }


    //}

}
