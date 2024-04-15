using ApplicationCore.Entities;
using ShowNest.ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces
{
    public interface IEcpayOrderService
    {
        Task<Dictionary<string, string>> GenerateEcpayOrderAsync(int orderId);

        Task<Dictionary<string, string>> GenerateOrderAsync(string customerOrderId);

        //Task <OrderDto> GenerateOrderAsync(string customerOrderId);
        Task<int> GetCustomerOrderTotalAmountAsync(string customerOrderId);
        Task<string> GetCustomerOrderNameAsync(string customerOrderId);
        Task<string> GetCheckMacValue(Dictionary<string, string> order);

        public string GenerateOrderIdAsync();
        //Task<string> GetCheckMacValue(OrderDto order);
    }
}