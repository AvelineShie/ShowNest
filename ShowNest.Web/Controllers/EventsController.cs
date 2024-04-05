using System.Collections.Generic;
using System.Drawing.Text;
using System.Globalization;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Elfie.Serialization;
using Infrastructure.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IRepository<ArchiveOrder> _archiveOrderRepo;
        private readonly IRepository<ApplicationCore.Entities.Ticket> _ticket;
        private readonly IOrderRepository _orderRepo;
        private readonly OrderTicketService _registrationService;
        private readonly EventPageService _eventPageService;

        //private readonly IOrderQueryService _orderQueryService;


        public EventsController(EventIndexService eventIndexService, OrderTicketService orderQueryService,
            IRepository<ArchiveOrder> archiveOrderRepo, IRepository<ApplicationCore.Entities.Ticket> ticket, IOrderRepository orderRepo)
        {
            _eventIndexService = eventIndexService;
            _orderQueryService = orderQueryService;
            _archiveOrderRepo = archiveOrderRepo;
            _ticket = ticket;
            _orderRepo = orderRepo;
          
        }

        public IActionResult Index(int page)
        {
            //var eventIndexViewModel = _eventIndexService.GetEventIndexViewModel();

            //int CardsPerPage = 9;
            //int TotalPages = (int)Math.Ceiling((double)eventIndexViewModel.EventEventCards.Count / CardsPerPage);
            //page = Math.Max(1, Math.Min(page, TotalPages));

            //eventIndexViewModel.EventEventCards = eventIndexViewModel.EventEventCards
            //                                        .Skip((page - 1) * CardsPerPage)
            //                                        .Take(CardsPerPage)
            //                                        .ToList();

            //ViewData["TotalPages"] = TotalPages;
            //ViewData["CurrentPage"] = page;
           
            return View();
        }

        public IActionResult Search([FromQuery] QueryParametersViewModel parameters)
        {
            ///Events/Search?Id=1&Name=SSS&MaxPrice=300&MinPrice=10&StartTime=0&EndTime=0&CategoryTag=2
            return View();
        }
        public IActionResult EventPage(string EventId)
        {
            var eventPageViewModel = _eventPageService.GetEventPageViewModel(EventId);

            return View(eventPageViewModel);
        }




        public IActionResult TicketTypeSelection()
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

        public IActionResult PaymentInfo()
        {
            return View();
        }

        public IActionResult OrderDetail()
        {
           
            //var userId = 1;
            //var OrderDetail = _orderQueryService.GetMemberOrders(userId);
           
            return View();
            //string name = string.Empty;
            //if (id.HasValue)
            //{
            //    var order = _orderRepo.FirstOrDefault(o => o.Id == id.Value);
            //    if (order != null)
            //    {
            //        var ArchiveOrder = _archiveOrderRepo.List(ao => ao.OrderId == order.Id);
            //        name = $"{order.Id} : {ArchiveOrder.Sum(ao => (ao.TicketPrice * ao.PurchaseAmount))}";
            //    }
            //}
            //ViewData["OrderName"] = name;
        }
     
    }
}