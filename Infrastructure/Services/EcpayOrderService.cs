using ApplicationCore.Interfaces;
using FluentEcpay;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShowNest.ApplicationCore.DTOs;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web;



namespace Infrastructure.Services
{
    public class EcpayOrderService : IEcpayOrderService
    {
        private readonly DatabaseContext _context;
        private readonly string _connectionStr;

        

        public EcpayOrderService(DatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            _connectionStr = configuration.GetConnectionString("DatabaseContext");
        }


        public async Task<Dictionary<string,string>> GenerateOrderAsync(string customerOrderId)
        {
            var orderId = GenerateOrderIdAsync();
            var eventName = await GetCustomerOrderNameAsync( customerOrderId);
            //需填入你的網址
            var website = $"https://67b5-1-164-250-93.ngrok-free.app";
           
            int totalAmount = await GetCustomerOrderTotalAmountAsync( customerOrderId);
            var order = new Dictionary<string, string>
        {
            //綠界需要的參數
            { "MerchantTradeNo", orderId },
            { "MerchantTradeDate", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") },
            { "TotalAmount", $"{totalAmount}" },
            { "TradeDesc", "無" },
            { "ItemName", $"{eventName}" },
            { "ExpireDate", "1" },
            { "CustomField1", "" },
            { "CustomField2", "" },
            { "CustomField3", "" },
            { "CustomField4", "" },
            { "ReturnURL", $"{website}/api/Ecpay/AddPayInfo" },
            { "OrderResultURL", $"{website}/Events/PayInfo/{orderId}" },
            { "PaymentInfoURL", $"{website}/api/Ecpay/AddAccountInfo" },
            { "ClientRedirectURL", $"{website}/Events/PayInfo/{orderId}" },
            { "MerchantID", "3002607" },
            { "IgnorePayment", "GooglePay#WebATM#CVS#BARCODE" },
            { "PaymentType", "aio" },
            { "ChoosePayment", "ALL" },
            { "EncryptType", "1" },
        };
            //檢查碼
            order["CheckMacValue"] = await GetCheckMacValue(order);
            return (order);
            //var order =  new OrderDto
            //{
            //    MerchantTradeNo = orderId,
            //    MerchantTradeDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
            //    TotalAmount = totalAmount,
            //    TradeDesc =$"無",
            //    ItemName=$"{eventName}",
            //    ReturnURL = $"{website}/api/Ecpay/AddPayInfo",
            //    OrderResultURL = $"{website}/Events/OrderDetail/{orderId}",
            //    PaymentInfoURL=$"{website}/api/Ecpay/AddAccountInfo" ,
            //    ClientBackURL = $"{website}/Events/OrderDetail/{orderId}",
            //    MerchantID = "3002607",
            //    PaymentType= "aio",
            //    ChoosePayment = "ALL",
            //    EncryptType= 1,
            //};
            //return order;
        }

        private Task<string> GetSHA256(string value)
        {
            var result = new StringBuilder();
            var sha256 = SHA256.Create();
            var bts = Encoding.UTF8.GetBytes(value);
            var hash = sha256.ComputeHash(bts);

            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }

            return Task.FromResult(result.ToString());
        }

        public async Task<string> GetCheckMacValue(Dictionary<string, string> order)
        {

            //// 使用反射獲取 OrderDto 的所有公共實例屬性
            //var properties = typeof(OrderDto).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            //// 將屬性轉換為鍵值對，並按照鍵的字母順序排序
            //var param = properties.OrderBy(p => p.Name)
            //                      .Select(p => p.Name + "=" + p.GetValue(order))
            //                      .ToList();

            var param = order.Keys.OrderBy(x => x).Select(key => key + "=" + order[key]).ToList();
            var checkValue = string.Join("&", param);

            //測試用的 HashKey
            var hashKey = "pwFHCqoQZGmho4w6";

            //測試用的 HashIV
            var HashIV = "EkRm7iFT261dpevs";

            checkValue = $"HashKey={hashKey}" + "&" + checkValue + $"&HashIV={HashIV}";

            checkValue = HttpUtility.UrlEncode(checkValue).ToLower();

            checkValue = await GetSHA256(checkValue);

            return await Task.FromResult(checkValue.ToUpper());
        }
        public string GenerateOrderIdAsync()
        {
            var orderId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 20);
            return orderId;
        }

        public async Task<string> GetCustomerOrderNameAsync( string customerOrderId)
        {
            var order = await _context.Orders
                .Include(o => o.ArchiveOrder)
                .FirstOrDefaultAsync(o => o.Id.ToString() == 1.ToString() && o.ArchiveOrder.OrderId.ToString() == 1.ToString());

            if (order == null)
            {
                throw new Exception($"Order with ID {customerOrderId} ");
            }

            return order.ArchiveOrder.EventName;
        }

        public Task<int> GetCustomerOrderTotalAmountAsync(string customerOrderId)
        {
            var totalAmount = _context.Orders
                .Where(o =>o.Id.ToString() == 1.ToString())
                .SelectMany(o => o.Tickets)
                .Sum(ticket => ticket.Order.ArchiveOrder.TicketPrice);

            return Task.FromResult((int)totalAmount);
        }
      
     }
}
       

