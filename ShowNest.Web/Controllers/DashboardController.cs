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


        public async Task<IActionResult> CreateEvent()
        {
            return View();
        }


        public async Task<IActionResult> SetEvent()
        {
            
            return View();
        }

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

        public IActionResult Organizations(string viewType)
        {
            switch (viewType)
            {
                case "Overview":
                    return View("Overview");
                case "OrgAccount":
                    return View("OrgAccount");
                case "OrgGeneralInfo":
                    return View("OrgGeneralInfo");
                case "OrgAuthority":
                    return View("OrgAuthority");

                default: 
                    return BadRequest("Invalid view type.");

            }

        }
    }
}
