using System.Collections.Generic;
using System.Drawing.Text;
using System.Globalization;
using System.Security.Claims;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Elfie.Serialization;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using ShowNest.Web.Models;
using ShowNest.Web.Services;
using ShowNest.Web.Services.Events;
using ShowNest.Web.ViewModels.Events;
using ShowNest.Web.ViewModels.Organization;
using Ticket = ApplicationCore.Entities.Ticket;


namespace ShowNest.Web.Controllers
{

    public class EventsController : Controller
    {

        /// <summary>
        /// 測試於網址列輸入的參數並查詢資料庫內容
        /// </summary>
        /// <param name="OrganizationId"></param>
        /// <param name="EventId"></param>
        /// <returns></returns>
        //private readonly ShowNestContext _context;
        //public EventsController(ShowNestContext context)
        //{
        //    _context = context;
        //}
        //public IActionResult Index(string OrganizationId, string EventId)
        //{
        //    var organization = _context.Organizations.FirstOrDefault(x => x.OrganizationId == OrganizationId);
        //    if (organization == null)
        //    {
        //        // 組織不存在，返回相應的頁面或錯誤訊息
        //        return NotFound(); // 或者其他適當的處理
        //    }

        //    // 組織存在，繼續執行其他操作
        //    return View();
        //}
        //以上測試中--------------------------------------------------------------

        private readonly EventIndexService _eventIndexService;
        private readonly OrderTicketService _orderQueryService;
        private readonly IOrderRepository _orderRepo;
        private readonly IEcpayOrderService _ecpayOrderService;
        private readonly EventPageService _eventPageService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly DatabaseContext _context;
        //private readonly SearchEventService _searchEventService;



        public EventsController(EventIndexService eventIndexService, OrderTicketService orderQueryService,
            IOrderRepository orderRepo, EventPageService eventPageService, IEcpayOrderService ecpayOrderService,
            IHttpContextAccessor httpContextAccessor, DatabaseContext context)
        {
            _eventIndexService = eventIndexService;
            _orderQueryService = orderQueryService;
            _orderRepo = orderRepo;
            _eventPageService = eventPageService;
            _ecpayOrderService = ecpayOrderService;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            
        }

        [Route("Events/Explore")]
        public async Task<IActionResult> Index()
        {
            var eventIndexCategoryTags = await _eventIndexService.GetEventIndexCategoryTags();

            return View(eventIndexCategoryTags);
        }

        public IActionResult Search()
        {
            return View();
        }

        //[HttpGet]
        ////[Route("Events")]
        //public IActionResult Search(QueryParametersViewModel queryParameters)
        //{
        //    Console.WriteLine($"Name: {queryParameters.inputstring}, MinPrice: {queryParameters.MinPrice}, MaxPrice: {queryParameters.MaxPrice}, StartTime: {queryParameters.StartTime}, EndTime: {queryParameters.EndTime}");
        //    ///Events/Explore?inputstring=play&MaxPrice=300&MinPrice=10&StartTime=0&EndTime=0&CategoryTag=2
        //    var searchResults = _searchEventService.SearchEventString(
        //    queryParameters.inputstring,
        //    queryParameters.MinPrice,
        //    queryParameters.MaxPrice,
        //    queryParameters.StartTime,
        //    queryParameters.EndTime
        //    );

        //    return RedirectToAction("Index", "Events", searchResults);
        //}



        public IActionResult EventPage(int EventId)
        {
            var eventPageViewModel = _eventPageService.GetEventPageViewModel(EventId);

            return View(eventPageViewModel);
        }


        public IActionResult TicketTypeSelectionWithoutSeats()
        {
            return View();
        }

        public IActionResult TicketTypeSelection()
        {
            return View();
        }

        public IActionResult SeatSelector()
        {
            return View();
        }

        public IActionResult SelectArea()
        {
            return View();
        }

        public IActionResult SeatsSelection()
        {
            return View();
        }

        public IActionResult Registrations()
        {

            var RegistrationsFakeData = _orderQueryService.GetRegistrationsFakeData();
            return View(RegistrationsFakeData);
        }

        public async Task<IActionResult> PaymentInfo(string customerOrderId)
        {
            // var userId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            
             //var GenerateOrderToEcpay = await _ecpayOrderService.GenerateOrderAsync(customerOrderId);
            // var checkMacValue = await _ecpayOrderService.GetCheckMacValue(GenerateOrderToEcpay);
            // ViewData["CheckMacValue"] = checkMacValue;
            return View();
        }

        public async Task<IActionResult> OrderDetail(int customerOrderId)
        {

            //var GenerateOrderToEcpay = await _ecpayOrderService.GenerateOrderAsync(customerOrderId);
            return View();
        }

        
        /// step5 : 取得付款資訊，更新資料庫
        [HttpPost]
        [Route("Events/PayInfo/{id}")]
        public ActionResult PayInfo(IFormCollection formData)
        {
            var data = new Dictionary<string, string>();
            foreach (string key in formData.Keys)
            {
                data.Add(key, formData[key]);
            }
            //var ecpayOrder = _context.EcpayOrders.Where(m => m.MerchantTradeNo == temp).FirstOrDefault();
            
            string OrderId = formData["CustomField1"];
            var model = new EcpayClientComformViewModel { Data = data, Id = OrderId };
            return View("EcpayView", model);
        }

        //檢查登入狀態BY大頭
        [HttpGet("checkLoginStatus")]
        public async Task<IActionResult> CheckLoginStatus()
        {
            var result = await HttpContext.AuthenticateAsync();
            if (result.Succeeded)
            {
                return Ok(new { isLoggedIn = true });
            }
            else
            {
                return Ok(new { isLoggedIn = false });
            }
        }

    }
}