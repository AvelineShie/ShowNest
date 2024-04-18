using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ShowNest.Web.Helpers;
using Microsoft.Extensions.Caching.Memory;
using ShowNest.ApplicationCore.DTOs;
using ShowNest.Web.ViewModels.Orders;
using Microsoft.EntityFrameworkCore;
using CloudinaryDotNet.Actions;
using System.Web;
using System.Security.Policy;


namespace ShowNest.Web.WebAPI
{
    [ApiController]
    public class EcpayApiController : ControllerBase
    {
        private readonly DatabaseContext _dbContext;
        private readonly IMemoryCache _cache;
        private readonly EcpayHttpHelpers _ecpayHttpHelpers;
        private readonly IEcpayOrderService _ecpayOrderService;
        private readonly string _website;

        public EcpayApiController(DatabaseContext dbContext, EcpayHttpHelpers ecpayHttpHelpers, IMemoryCache cache,
            IEcpayOrderService ecpayOrderService, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _ecpayHttpHelpers = ecpayHttpHelpers;
            _cache = cache;
            _website = configuration["WebsiteUrl"];
            _ecpayOrderService = ecpayOrderService;
        }

        //-----------------------------------原始粗暴版綠界新增訂單在DB------------------------------------------------
        //[HttpPost]
        //[Route("api/Ecpay/AddOrders")]
        //public string AddOrders([FromBody] OrderDto json)
        //{
        //    if (json == null)
        //    {
        //        return "Error: json object is null.";
        //    }

        //    string num = "0";
        //    try
        //    {
        //        EcpayOrder Orders = new EcpayOrder();
        //        Orders.MemberId = json.MerchantID;
        //        Orders.MerchantTradeNo = json.MerchantTradeNo;
        //        Orders.RtnCode = 0; //未付款
        //        Orders.RtnMsg = "訂單成功尚未付款";
        //        Orders.TradeNo = json.MerchantID.ToString();
        //        Orders.TradeAmt = json.TotalAmount;
        //        Orders.PaymentDate = Convert.ToDateTime(json.MerchantTradeDate);
        //        Orders.PaymentType = json.PaymentType;
        //        Orders.PaymentTypeChargeFee = "0";
        //        Orders.TradeDate = json.MerchantTradeDate;
        //        Orders.SimulatePaid = 0;
        //        _dbContext.EcpayOrders.Add(Orders);
        //        _dbContext.SaveChanges();

        //        // 假設您已經知道要更新的訂單的唯一識別碼（例如 Id）
        //        int orderId = 1; // 這裡只是示例，您需要根據實際情況提供正確的訂單識別碼

        //        // 找到該訂單並更新 EcpayTradeNo 欄位
        //        var orderToUpdate = _dbContext.Orders.FirstOrDefault(o => o.Id == orderId);
        //        if (orderToUpdate != null)
        //        {
        //            orderToUpdate.EcpayTradeNo = json.MerchantTradeNo;
        //            _dbContext.SaveChanges();
        //        }
        //        else
        //        {
        //            // 如果找不到訂單，處理錯誤情況
        //            num = "Error: Order not found.";
        //        }


        //        num = "OK";
        //    }
        //    catch (Exception ex)
        //    {
        //        num = ex.ToString();
        //    }

        //    return num;
        //}

        //收到綠界的付款結果訊息，並判斷檢查碼是否相符，檢查碼相符後，回應1|OK
        [HttpPost]
        [Route("api/Ecpay/AddPayInfo")]
        public async Task<IActionResult> AddPayInfo([FromForm] IFormCollection info)
        {
            var website = _website;
            string receivedCheckMacValue = info["CheckMacValue"];
            string temp = info["MerchantTradeNo"];
            //var order = _dbContext.EcpayOrders.Where(m => m.MerchantTradeNo == temp).Select(x => x.OrderId).FirstOrDefault();
            var ecpayOrder = _dbContext.EcpayOrders.Where(m => m.MerchantTradeNo == temp).FirstOrDefault();

            if (ecpayOrder != null)
            {
                //_cache.Set(info.Value<string>("MerchantTradeNo"), info, DateTime.Now.AddMinutes(60));
                ecpayOrder.RtnCode = int.Parse(info["RtnCode"]);
                if (info["RtnMsg"] == "交易成功")
                {
                    ecpayOrder.RtnMsg = "已付款";
                    var orderToUpdate = _dbContext.Orders.FirstOrDefault(o => o.Id == ecpayOrder.OrderId);
                    if (orderToUpdate != null)
                    {
                        ecpayOrder.RtnCode = 1;
                        orderToUpdate.Status = 1;
                        var paymentDate = info["PaymentDate"];
                        ecpayOrder.PaymentDate = DateTime.Now;
                        _dbContext.EcpayOrders.Update(ecpayOrder);
                        _dbContext.SaveChanges();

                        return Content("1|ok");
                    }
                }
                else
                {
                    var orderToUpdate = _dbContext.Orders.FirstOrDefault(o => o.Id == ecpayOrder.OrderId);
                    orderToUpdate.Status = 2;
                    _dbContext.Orders.Update(orderToUpdate);
                    _dbContext.SaveChanges();
                    return Content("0|error");
                }
            }
            return Content("0|error");


            //string MerchantTradeDate = info["MerchantTradeDate"];
            //string TotalAmount = info["TotalAmount"];
            //string TradeDesc = info["TradeDesc"];
            //string ItemName = info["ItemName"];
            //string ExpireDate = info["ExpireDate"];
            //string ReturnURL = info["ReturnURL"];
            //string OrderResultURL = info["OrderResultURL"];
            //string PaymentInfoURL = info["PaymentInfoURL"];
            //string ClientRedirectURL = info["ClientRedirectURL"];
            //string MerchantID = info["MerchantID"];
            //string IgnorePayment = info["IgnorePayment"];
            //string PaymentType = info["PaymentType"];
            //string ChoosePayment = info["ChoosePayment"];
            //string EncryptType = info["EncryptType"];

            //var orderInfo = new Dictionary<string, string>
            //{
            //    {"MerchantTradeNo", temp},
            //    {"MerchantTradeDate",MerchantTradeDate},
            //    {"TotalAmount",TotalAmount},
            //    {"TradeDesc", TradeDesc},
            //    {"ItemName",ItemName},
            //    {"ExpireDate", ExpireDate},
            //    {"ReturnURL",ReturnURL},
            //    {"OrderResultURL",OrderResultURL},
            //    {"PaymentInfoURL", PaymentInfoURL},
            //    {"ClientRedirectURL", ClientRedirectURL},
            //    {"MerchantID", MerchantID},
            //    {"IgnorePayment", IgnorePayment},
            //    {"PaymentType",PaymentType},
            //    {"ChoosePayment", ChoosePayment},
            //    {"EncryptType", EncryptType},
            //};
            //string generatedCheckMacValue = await _ecpayOrderService.GetCheckMacValue(orderInfo);
           
            //var tempffff = 111;
            //if (generatedCheckMacValue == receivedCheckMacValue)
            //{
            //    if (ecpayOrder != null)
            //    {
            //        //_cache.Set(info.Value<string>("MerchantTradeNo"), info, DateTime.Now.AddMinutes(60));
            //        ecpayOrder.RtnCode = int.Parse(info["RtnCode"]);
            //        if (info["RtnMsg"] == "交易成功")
            //        {
            //            ecpayOrder.RtnMsg = "已付款";
            //            var orderToUpdate = _dbContext.Orders.FirstOrDefault(o => o.Id == ecpayOrder.OrderId);
            //            if (orderToUpdate != null)
            //            {
            //                ecpayOrder.RtnCode = 1;
            //                orderToUpdate.Status = 2;
            //                var paymentDate = info["PaymentDate"];
            //                ecpayOrder.PaymentDate = DateTime.Now;
            //                _dbContext.EcpayOrders.Update(ecpayOrder);
            //                _dbContext.SaveChanges();

            //                //return await Task.FromResult<IActionResult>(Content("1|ok"));
            //                return Content("1|ok");
            //            }
            //        }
            //        //return await Task.FromResult<IActionResult>(Content("0|error"));
            //    }
            //    return Content("0|error");
            //}
            //else
            //{
            //    return Content("0|error");
            //}
        }
      

        [HttpPost]
        [Route("api/Ecpay/GetEcpayOrderInfo")]
        public async Task<IActionResult> GetEcpayOrderInfo(CreateEcpayOrderRequest request)
        {
            var result = await _ecpayOrderService.GenerateEcpayOrderAsync(request.OrderId);

            return Ok(result);
        }

    }
}
