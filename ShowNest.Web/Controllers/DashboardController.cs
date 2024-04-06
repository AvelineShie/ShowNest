﻿using ApplicationCore.Interfaces;
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
        private readonly CreateEventService _createEventService;

        public DashboardController(OverviewService overviewService, OrgGeneralInfoService orgGeneralInfoService, CreateEventService createEventService)
        {
            _overviewService = overviewService;
            _orgGeneralInfoService = orgGeneralInfoService;
            _createEventService = createEventService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CreateEvent()
        {
            //var userIdentifier = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //HttpContext?.User.Identities.FirstOrDefault()
            var userId = 1;
            var vm = _createEventService.GetOrgByOwner(userId);
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> SetEvent()
        {

            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> SetEvent()
        //{

        //    return View();
        //}

        public async Task<IActionResult> SetTicket()
        {

            return View();
        }

        public async Task<IActionResult> SetTable()
        {

            return View();
        }

        public IActionResult EventHub()
        {
            return View();
        }


        public IActionResult SetTicketPage()
        {
            var model = new SetTicketPageViewModel()
            {
                OrganizationName = "MafiaQQ",

                SetTickets = new List<SetTicketViewModel> {
                    new SetTicketViewModel {
                        TicketName = "一般套票",
                        StartTime = new DateTime(2024, 2, 2, 5, 0, 0), // 使用 DateTime 型別
                        EndTime = new DateTime(2024, 2, 6, 8, 0, 0),
                        Price  = 750,
                        Quantity = "300",
                    },
                    new SetTicketViewModel {
                        TicketName = "搖滾區",
                        StartTime = new DateTime(2024, 2, 2, 5, 0, 0),
                        EndTime = new DateTime(2024, 2, 6, 8, 0, 0),
                        Price  = 8000,
                        Quantity = "100",
                    },
                    new SetTicketViewModel {
                        TicketName = "包廂區",
                        StartTime = new DateTime(2024, 2, 2, 5, 0, 0),
                        EndTime = new DateTime(2024, 2, 6, 8, 0, 0),
                        Price  = 10000,
                        Quantity = "300",
                    }
                }

            };
            return View("SetTicket", model);

        }

        public IActionResult Organizations(int id, string ViewType)
        {

            switch (ViewType)
            {
                case "Overview":
                    {
                        var overviewViewModel = _overviewService.GetOverviewViewModel(id);
                        return View("Overview", overviewViewModel);
                    }
                    
                case "OrgAccount":
                    return View("OrgAccount");
                case "OrgGeneralInfo":
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

        public IActionResult CreateNewEvent()
        {
            return View();
        }
    }
}
