using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ShowNest.Web.WebAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class EcpayController : ControllerBase
    {
        //public string AddOrders(get_localStorage json)
        //{
        //    string num = "0";
        //    try
        //    {
        //        EcpayOrders Orders = new EcpayOrders();
        //        Orders.MemberID = json.MerchantID;
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
        //        db.EcpayOrders.Add(Orders);
        //        db.SaveChanges();
        //        num = "OK";
        //    }
        //    catch (Exception ex)
        //    {
        //        num = ex.ToString();
        //    }
        //    return num;
        //}
    }
}
