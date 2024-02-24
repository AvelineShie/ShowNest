using Microsoft.AspNetCore.Mvc;

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

        public IActionResult SelectTicketTypes()
        {
            return View();
        }

        public IActionResult SelectSeats()
        {
            return View();
        }
        public IActionResult SelectArea()
        {
            return View();
        }
    }
}
