using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Security.Cryptography;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ShowNest.Web.Services
{
    public class OrderService 
    {
        private readonly OrderCenterService _orderCenterService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public OrderService(
          IRepository<Order> orderRepo,
          IRepository<ArchiveOrder> archiveOrderRepo,
          IRepository<Ticket> ticket,
          IHttpContextAccessor httpContextAccessor, OrderCenterService orderCenterService
            )
        {
            _orderCenterService = orderCenterService;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<Dictionary<string, string>> GenerateOrderAsync()
        {
            var orderId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 20);
            string userId =  _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var orderName = await _orderCenterService.GetCustomerOrderNameAsync(orderId);
            //需填入你的網址
            var website = $"https://5f3c-1-164-230-54.ngrok-free.app/";
            int totalAmount = await _orderCenterService.GetCustomerOrderTotalAmountAsync(userId);
            var  order = new Dictionary<string, string>
            {
                { "MerchantTradeNo",  orderId},
                { "MerchantTradeDate",  DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")},
                { "TotalAmount",  $"{totalAmount}"},
                { "TradeDesc",  "無"},
                { "ItemName",  $"{orderName}"},
                { "ExpireDate",  "1"},
                { "ReturnURL",  $"{website}/api/Ecpay/AddPayInfo"},
                { "OrderResultURL", $"{website}/Events/OrderDetail?={orderId}"},
                { "PaymentInfoURL",  $"{website}/api/Ecpay/AddAccountInfo"},
                { "ClientRedirectURL",  $"{website}/Events/OrderDetail?={orderId}"},
                { "MerchantID",  "3002607"},
                { "IgnorePayment",  "GooglePay#WebATM#CVS#BARCODE#ApplePay#ATM#TWQR#BNPL"},
                { "PaymentType",  "aio"},
                { "ChoosePayment",  "Credit"},
                { "EncryptType",  "1"},
            };
            //檢查碼
            order["CheckMacValue"] = GetCheckMacValue(order);
            return order;

           
        }

        private string GetCheckMacValue(Dictionary<string, string> order)
        {
            var param = order.Keys.OrderBy(x => x).Select(key => key + "=" + order[key]).ToList();

            var checkValue = string.Join("&", param);

            //測試用的 HashKey
            var hashKey = "5294y06JbISpM5x9";

            //測試用的 HashIV
            var HashIV = "v77hoKGq4kWxNNIS";

            checkValue = $"HashKey={hashKey}" + "&" + checkValue + $"&HashIV={HashIV}";

            checkValue = HttpUtility.UrlEncode(checkValue).ToLower();

            checkValue = GetSHA256(checkValue);

            return checkValue.ToUpper();
        }
        private string GetSHA256(string value)
        {
            var result = new StringBuilder();
            var sha256 = SHA256.Create();
            var bts = Encoding.UTF8.GetBytes(value);
            var hash = sha256.ComputeHash(bts);

            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }

            return result.ToString();
        }
    }
}
