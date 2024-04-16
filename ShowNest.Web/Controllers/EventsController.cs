﻿using System.Collections.Generic;
using System.Drawing.Text;
using System.Globalization;
using System.Security.Claims;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Elfie.Serialization;
using Infrastructure.Services;
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
        private readonly SearchEventService _searchEventService;



        public EventsController(EventIndexService eventIndexService, OrderTicketService orderQueryService,
            IOrderRepository orderRepo, EventPageService eventPageService, IEcpayOrderService ecpayOrderService,
            IHttpContextAccessor httpContextAccessor, DatabaseContext context, SearchEventService searchEventService)
        {
            _eventIndexService = eventIndexService;
            _orderQueryService = orderQueryService;
            _orderRepo = orderRepo;
            _eventPageService = eventPageService;
            _ecpayOrderService = ecpayOrderService;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _searchEventService = searchEventService;
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

            var GenerateOrderToEcpay = await _ecpayOrderService.GenerateOrderAsync(customerOrderId);
            // var checkMacValue = await _ecpayOrderService.GetCheckMacValue(GenerateOrderToEcpay);
            // ViewData["CheckMacValue"] = checkMacValue;
            return View(GenerateOrderToEcpay);
        }

        public async Task<IActionResult> OrderDetail(string customerOrderId)
        {

            var GenerateOrderToEcpay = await _ecpayOrderService.GenerateOrderAsync(customerOrderId);
            return View(GenerateOrderToEcpay);
        }

        public IActionResult BuyTicket()
        {
            var model = new TicketTypeSelectionViewModel()
            {
                EventDetail = new EventDetailViewModel()
                {
                    MainImage = "https://picsum.photos/1300/600/?random=10",
                    EventName = "NOT SUPER JUNIOR-L.S.S. THE SHOW : TH3EE GUYS",
                    StartTime = DateTime.Now,
                    EventLocation = "亞洲國際博覽館 10號展館 / 國際機場亞洲國際博覽館",
                    EventHost = "ShowNest",
                    TicketCollectionChannel = "電子票券",
                    SeatAreaImage = "https://picsum.photos/1200/1200/?random=10"
                },
                PaymentMethods = new List<PaymentMethodViewModel>
                {
                    new PaymentMethodViewModel()
                    {
                        PaymentMethodName = "信用卡"
                    },
                    new PaymentMethodViewModel()
                    {
                        PaymentMethodName = "ATM"
                    }
                },
                TicketPriceRow = new List<TicketPriceViewModel>{
                    new TicketPriceViewModel()
                    {
                        SeatArea = "B1特一, B1特二",
                        SeatSelectionMethod = "自行選位",
                        Tickets = new TicketsViewModel()
                        {
                            TicketTypeName = "全票",
                            TicketPrice = 3000
                        }
                    },
                    new TicketPriceViewModel()
                    {
                        SeatArea = "紫1D, 紫1B, 黃2C, 紫1A, 紫1C, 紅1A, 紅1B, 紅1C, 紅1D",
                        SeatSelectionMethod = "自行選位",
                        Tickets = new TicketsViewModel()
                        {
                            TicketTypeName = "全票",
                            TicketPrice = 2600
                        }
                    },
                    new TicketPriceViewModel()
                    {
                        SeatArea = "紫2C, 紅2B, 紫1E, 紅2D, 紅2C, 紫2B, 紫2D, 黃2B, 紅1E, 黃2D",
                        SeatSelectionMethod = "自行選位",
                        Tickets = new TicketsViewModel()
                        {
                            TicketTypeName = "全票",
                            TicketPrice = 2400
                        }
                    },
                    new TicketPriceViewModel()
                    {
                        SeatArea = "紫2C, 紅2B, 紅2D, 紅2C, 紫2B, 紫2D, 紫2E, 紅2E, 黃2A, 黃2E",
                        SeatSelectionMethod = "自行選位",
                        Tickets = new TicketsViewModel()
                        {
                            TicketTypeName = "全票",
                            TicketPrice = 2200
                        }
                    }
                }
            };
            return View(model);
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

            string temp = formData["MerchantTradeNo"]; //寫在LINQ(下一行)會出錯，
            var ecpayOrder = _context.EcpayOrders.Where(m => m.MerchantTradeNo == temp).FirstOrDefault();

            if (ecpayOrder != null)
            {
                ecpayOrder.RtnCode = int.Parse(formData["RtnCode"]);
                if (formData["RtnMsg"] == "Succeeded")
                {
                    ecpayOrder.RtnMsg = "已付款";
                    var orderToUpdate = _context.Orders.FirstOrDefault(o => o.EcpayTradeNo == temp);
                    if (orderToUpdate != null)
                    {
                        orderToUpdate.Status = 1;
                        _context.SaveChanges(); // 保存變更到資料庫
                    }
                }
                ecpayOrder.PaymentDate = Convert.ToDateTime(formData["PaymentDate"]);
                ecpayOrder.SimulatePaid = int.Parse(formData["SimulatePaid"]);
                _context.SaveChanges();
            }

            return View("EcpayView", data);
        }
        [HttpGet]
        public async Task<IActionResult> Ecpay(string customerOrderId)
        {
            var userId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            var GenerateOrderToEcpay = await _ecpayOrderService.GenerateOrderAsync(customerOrderId);
            return View(GenerateOrderToEcpay);
        }
    }
}