using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ShowNest.Web.Helpers;
using Microsoft.Extensions.Caching.Memory;
using ShowNest.ApplicationCore.DTOs;


namespace ShowNest.Web.WebAPI
{
    [ApiController]
    public class EcpayController : ControllerBase
    {
        private readonly DatabaseContext _dbContext;
        private readonly IMemoryCache _cache;
        private readonly EcpayHttpHelpers _ecpayHttpHelpers;
     
        public EcpayController(DatabaseContext dbContext, EcpayHttpHelpers ecpayHttpHelpers, IMemoryCache cache)
        {
            _dbContext = dbContext;
            _ecpayHttpHelpers = ecpayHttpHelpers;
            _cache = cache;
        }
        [HttpPost]
        [Route("api/Ecpay/AddOrders")]
        public string AddOrders([FromBody] OrderDto json)
        {
            string num = "0";
            try
            {
                EcpayOrder Orders = new EcpayOrder();
                Orders.MemberId = json.MerchantID;
                Orders.MerchantTradeNo = json.MerchantTradeNo;
                Orders.RtnCode = 0; //未付款
                Orders.RtnMsg = "訂單成功尚未付款";
                Orders.TradeNo = json.MerchantID.ToString();
                Orders.TradeAmt = json.TotalAmount;
                Orders.PaymentDate = Convert.ToDateTime(json.MerchantTradeDate);
                Orders.PaymentType = json.PaymentType;
                Orders.PaymentTypeChargeFee = "0";
                Orders.TradeDate = json.MerchantTradeDate;
                Orders.SimulatePaid = 0;
                _dbContext.EcpayOrders.Add(Orders);
                _dbContext.SaveChanges();
                num = "OK";
            }
            catch (Exception ex)
            {
                num = ex.ToString();
            }
            return num;
        }

        [HttpPost]
        [Route("api/Ecpay/AddPayInfo")]
        public HttpResponseMessage AddPayInfo(JObject info)
        {
            try
            {
                _cache.Set(info.Value<string>("MerchantTradeNo"), info, DateTime.Now.AddMinutes(60));
                return _ecpayHttpHelpers.ResponseOK();
            }
            catch (Exception e)
            {
                return _ecpayHttpHelpers.ResponseError();
            }

        }
    }
}
