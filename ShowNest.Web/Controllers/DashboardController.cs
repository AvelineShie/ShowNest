using Microsoft.AspNetCore.Mvc;
using ShowNest.Web.ViewModels.Dashboard;
using ShowNest.Web.ViewModels.Events;

namespace ShowNest.Web.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NewEvent()
        {
            return View();
        }

        public IActionResult Events(string viewType)
        {
            if (viewType == "CreateActivity")
            {
                return View("CreateActivity");
            }

            if (viewType == "SetActivity")
            {
                return View("SetActivity");
            }

            if (viewType == "SetTicket")
            {
                return SetTicketPage();
                //return View("SetTicket");
            }

            if(viewType == "SetTable")
            {
                return View("SetTable");
            }

            if (viewType == "ActivitiesList")
            {
                return View("ActivitiesList");
            }
            if (viewType == "RegistrationList")
            {
                return View("RegistrationList");
            }

            return BadRequest("Invalid view type.");
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
                        SalesUnit = 2,
                    },
                    new SetTicketViewModel {
                        TicketName = "搖滾區",
                        StartTime = new DateTime(2024, 2, 2, 5, 0, 0),
                        EndTime = new DateTime(2024, 2, 6, 8, 0, 0),
                        Price  = 8000,
                        Quantity = "100",
                        SalesUnit = 1,
                    },
                    new SetTicketViewModel {
                        TicketName = "包廂區",
                        StartTime = new DateTime(2024, 2, 2, 5, 0, 0),
                        EndTime = new DateTime(2024, 2, 6, 8, 0, 0),
                        Price  = 10000,
                        Quantity = "300",
                        SalesUnit = 1,
                    }
                }

            };
            return View("SetTicket", model);

        }

        public IActionResult Organizations(string viewType)
        {
            switch (viewType)
            {
                case "Overview":
                    return View("Overview");
                case "Eventslist":
                    return View("Eventslist");
                case "info":
                    return View("info");

                default: 
                    return BadRequest("Invalid view type.");

            }

        }
    }
}
