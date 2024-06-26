﻿using ApplicationCore.Interfaces;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShowNest.Web.Services.Dashboard;
using ShowNest.Web.ViewModels.Dashboard;
using ShowNest.Web.ViewModels.Events;
using System.Drawing.Text;
using System.Security.Claims;

namespace ShowNest.Web.Controllers
{
    //[Authorize]
    public class DashboardController : Controller
    {
        private readonly OverviewService _overviewService;
        private readonly OrgGeneralInfoService _orgGeneralInfoService;
        private readonly ICreateEventService _createEventService;
        private readonly IEventOverviewService _eventOverviewService;

        public DashboardController(OverviewService overviewService, OrgGeneralInfoService orgGeneralInfoService, ICreateEventService createEventService, IEventOverviewService eventOverviewService)
        {
            _overviewService = overviewService;
            _orgGeneralInfoService = orgGeneralInfoService;
            _createEventService = createEventService;
            _eventOverviewService = eventOverviewService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SetEvent()
        {
            return View();
        }

        public IActionResult CreateEvent()
        {
            return View();
        }

        public IActionResult Events(int id, string viewType)
        {
            switch (viewType)
            {
                case "Overview":
                    {
                        int eventId = id;
                        return View("EventOverview", eventId);
                    }
                case "GeneralInfo":
                    {
                        int eventId = id;
                        return View("EventGeneralInfo", eventId);
                    }
                default:
                    return BadRequest("Invalid view type.");

            }
        }

        public IActionResult Organizations(int id, string ViewType)
        {

            switch (ViewType)
            {
                case "Overview":
                    {
                        var overviewViewModel = _overviewService.GetOverviewViewModel(id);
                        return View("OrgOverview", overviewViewModel);
                    }
                    
                case "OrgAccount":
                    return View("OrgAccount");
                case "GeneralInfo":
                    {
                        var orgGeneralInfoViewModel = _orgGeneralInfoService.GetOrgGeneralInfoViewModel(id);
                        return View("OrgGeneralInfo", orgGeneralInfoViewModel);
                    }
                    
                case "OrgAuthority":
                    return View("OrgAuthority");

                default: 
                    return BadRequest("Invalid view type.");

            }

        }

        public IActionResult CreateNewEvent() //範例
        {
            return View();
        }

        //    var userIdentifier = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    HttpContext?.User.Identities.FirstOrDefault()
        //之後以HttpContext的登入訊息取得資料
        //    var userId = 2;
        //    var vm = _createEventService.GetOrgByUserId(userId);
        //    return View(vm);


        public IActionResult SetTable()
        {
            return View();
        }

        public IActionResult SetTicket()
        {
            return View();
        }


        //public IActionResult SetTicketPage()
        //{
        //    var model = new SetTicketPageViewModel()
        //    {
        //        OrganizationName = "MafiaQQ",

        //        SetTickets = new List<TicketDetail> {
        //            new TicketDetail {
        //                TicketName = "一般套票",
        //                StartTime = new DateTime(2024, 2, 2, 5, 0, 0), // 使用 DateTime 型別
        //                EndTime = new DateTime(2024, 2, 6, 8, 0, 0),
        //                Price  = 750,
        //                Quantity = "300",
        //            },
        //            new TicketDetail {
        //                TicketName = "搖滾區",
        //                StartTime = new DateTime(2024, 2, 2, 5, 0, 0),
        //                EndTime = new DateTime(2024, 2, 6, 8, 0, 0),
        //                Price  = 8000,
        //                Quantity = "100",
        //            },
        //            new TicketDetail {
        //                TicketName = "包廂區",
        //                StartTime = new DateTime(2024, 2, 2, 5, 0, 0),
        //                EndTime = new DateTime(2024, 2, 6, 8, 0, 0),
        //                Price  = 10000,
        //                Quantity = "300",
        //            }
        //        }
        //    };
        //    return View("SetTicket", model);
        //}

    }
}
