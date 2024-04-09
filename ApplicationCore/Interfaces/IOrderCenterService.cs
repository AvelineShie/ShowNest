using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IOrderCenterService
    {
        Task<Dictionary<string, string>> GenerateOrderAsync();
        Task<int> GetCustomerOrderTotalAmountAsync(string userId);
        Task<string> GetCustomerOrderNameAsync(string orderId);
    }
}
