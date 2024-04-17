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
using ApplicationCore.Entities;
using System.Collections;


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
        
        public async Task<Dictionary<string, string>> GenerateEcpayOrderAsync(int orderId)
        {
            var order = await _context.Orders
                .Include(i => i.Event)
                .Include(i => i.Tickets)
                .ThenInclude(i => i.TicketType)
                .Where(i => i.Id == orderId).FirstOrDefaultAsync();
            var tradeNo = GenerateOrderIdAsync();
            var totalAmount = order.Tickets.Sum(i => i.TicketType.Price);

            var eventName = order.Event.Name;
            var website = "https://77b4-1-164-227-63.ngrok-free.app";

            //綠界需要的參數
            var ecpayData = new Dictionary<string, string>
            {
                {"MerchantTradeNo", tradeNo},
                {"MerchantTradeDate", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")},
                {"TotalAmount", $"{(int)totalAmount}"},
                {"TradeDesc", "無"},
                {"ItemName", $"{eventName}"},
                {"ExpireDate", "1"},
                {"ReturnURL", $"{website}/api/Ecpay/AddPayInfo"},
                {"OrderResultURL", $"{website}/Events/PayInfo/{orderId}"},
                {"PaymentInfoURL", $"{website}/api/Ecpay/AddAccountInfo"},
                {"ClientRedirectURL", $"{website}/Events/PayInfo/{orderId}"},
                {"MerchantID", "3002607"},
                {"IgnorePayment", "GooglePay#WebATM#CVS#BARCODE"},
                {"PaymentType", "aio"},
                {"ChoosePayment", "ALL"},
                {"EncryptType", "1"},
            };
            ecpayData.Add("CheckMacValue", await GetCheckMacValue(ecpayData).ConfigureAwait(false));
            
            //var ecpayOrder = await _context.EcpayOrders.Where(i => i.MerchantTradeNo == tradeNo).FirstOrDefaultAsync();
            
                var ecpayOrder = new EcpayOrder();
                ecpayOrder.MemberId = ecpayData["MerchantID"];
                ecpayOrder.MerchantTradeNo = ecpayData["MerchantTradeNo"];
                ecpayOrder.RtnCode = 0; //未付款
                ecpayOrder.RtnMsg = "訂單成功尚未付款";
                ecpayOrder.TradeNo = ecpayData["MerchantTradeNo"];
                ecpayOrder.TradeAmt = Convert.ToInt32(totalAmount);
                ecpayOrder.PaymentDate = Convert.ToDateTime(ecpayData["MerchantTradeDate"]);
                ecpayOrder.PaymentType = ecpayData["PaymentType"];
                ecpayOrder.PaymentTypeChargeFee = "0";
                ecpayOrder.TradeDate = ecpayData["MerchantTradeDate"];
                ecpayOrder.SimulatePaid = 0;
                ecpayOrder.OrderId = orderId;

                _context.EcpayOrders.Add(ecpayOrder);
                await _context.SaveChangesAsync();

            return ecpayData;
        }


        //-----------------------------------原始粗暴版綠界------------------------------------------------
        
        //public async Task<Dictionary<string, string>> GenerateOrderAsync(string customerOrderId)
        //{
        //    var orderId = GenerateOrderIdAsync();
        //    var eventName = await GetCustomerOrderNameAsync(customerOrderId);
        //    //需填入你的網址
        //    var website = $"https://9fe4-1-164-227-63.ngrok-free.app";

        //    int totalAmount = await GetCustomerOrderTotalAmountAsync(customerOrderId);
        //    var order = new Dictionary<string, string>
        //    {
        //        //綠界需要的參數
        //        {"MerchantTradeNo", orderId},
        //        {"MerchantTradeDate", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")},
        //        {"TotalAmount", $"{totalAmount}"},
        //        {"TradeDesc", "無"},
        //        {"ItemName", $"{eventName}"},
        //        {"ExpireDate", "1"},
        //        {"CustomField1", ""},
        //        {"CustomField2", ""},
        //        {"CustomField3", ""},
        //        {"CustomField4", ""},
        //        {"ReturnURL", $"{website}/api/Ecpay/AddPayInfo"},
        //        {"OrderResultURL", $"{website}/Events/PayInfo/{orderId}"},
        //        {"PaymentInfoURL", $"{website}/api/Ecpay/AddAccountInfo"},
        //        {"ClientRedirectURL", $"{website}/Events/PayInfo/{orderId}"},
        //        {"MerchantID", "3002607"},
        //        {"IgnorePayment", "GooglePay#WebATM#CVS#BARCODE"},
        //        {"PaymentType", "aio"},
        //        {"ChoosePayment", "ALL"},
        //        {"EncryptType", "1"},
        //    };
        //    //檢查碼
        //    order["CheckMacValue"] = await GetCheckMacValue(order);
        //    return (order);
        //}

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
            var param = order.Keys.OrderBy(x => x).Select(key => key + "=" + order[key]).ToList();
            var checkValue = string.Join("&", param);

            //測試用的 HashKey
            var hashKey = "pwFHCqoQZGmho4w6";

            //測試用的 HashIV
            var HashIV = "EkRm7iFT261dpevs";

            checkValue = $"HashKey={hashKey}" + "&" + checkValue + $"&HashIV={HashIV}";

            checkValue = HttpUtility.UrlEncode(checkValue).ToLower();

            checkValue = await GetSHA256(checkValue);

            Mac = checkValue;

            return checkValue.ToUpper();
        }
        public string Mac { get; private set; }

        public string GetCalculatedMac()
        {
            return Mac;
        }

        public string GenerateOrderIdAsync()
        {
            var orderId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 20);
            return orderId;
        }

        public async Task<string> GetCustomerOrderNameAsync(string customerOrderId)
        {
            var order = await _context.Orders
                .Include(o => o.ArchiveOrder)
                .FirstOrDefaultAsync(o =>
                    o.Id.ToString() == 1.ToString() && o.ArchiveOrder.OrderId.ToString() == 1.ToString());

            if (order == null)
            {
                throw new Exception($"Order with ID {customerOrderId} ");
            }

            return order.ArchiveOrder.EventName;
        }

        public Task<int> GetCustomerOrderTotalAmountAsync(string customerOrderId)
        {
            var totalAmount = _context.Orders
                .Where(o => o.Id.ToString() == 1.ToString())
                .SelectMany(o => o.Tickets)
                .Sum(ticket => ticket.Order.ArchiveOrder.TicketPrice);

            return Task.FromResult((int) totalAmount);
        }
    }
}