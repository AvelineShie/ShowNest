﻿using Microsoft.AspNetCore.Mvc;
using ShowNest.Web.ViewModels.Events;

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
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EventPage()
        {
            return View();
        }

        public IActionResult TicketTypeSelection()
        {
            var model = new TicketTypeSelectionViewModel()
            {
                EventDetails = new EventDetailsViewModel()
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
                TicketPriceTable = new TicketPriceTableViewModel()
                { 
                    TicketTypeName =  "全票",
                    SeatArea = "B1特一, B1特二",
                    TicketPrice = 3000
                }
                
            };


            return View(model);
        }

        public IActionResult SelectArea()
        {
            return View();
        }

        public IActionResult SelectSeats()
        {
            return View();
        }

        public IActionResult Registrations()
        {
            return View();
        }

        public IActionResult PaymentInfo()
        {
            return View();
        }

        public IActionResult OrderDetail()
        {
            return View();
        }
    }
}