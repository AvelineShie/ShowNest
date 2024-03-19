using Microsoft.AspNetCore.Mvc;
using Infrastructure.Data;
using Newtonsoft.Json;
using ApplicationCore.Entities;

namespace ShowNest.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly DatabaseContext _context;
        public AccountController(DatabaseContext context)
        {
            _context = context;
        }
        public IActionResult UserEdit()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = "1346987129576805", //your_app_id
                redirect_uri = "https://localhost:7156", //your_redirect_uri
                scope = "public_profile,email"  //public_profile,email
            });
            ViewBag.Url = loginUrl;
            return View();
        }
        public IActionResult FacebookRedirect(string code)

        {
            var fb = new FacebookClient();
            dynamic result = fb.Get("/oauth/access_token", new
            {
                client_id = "1346987129576805", //your_app_id
                client_secret = "a647392a10dd9c64d0153eb5eba5eae5",
                redirect_uri = "https://localhost:7156", //your_redirect_uri

                code = code

            });

            fb.AccessToken = result.access_token;

            dynamic me = fb.Get("/me?fields=name,email");
            string name = me.name;
            string email = me.email;
            var userData = new Dictionary<string, string>
            {
                {"Name",name },
                {"Email",email}
            };
            string UserDataJson = JsonConvert.SerializeObject(userData, Formatting.Indented);
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "UserData.json");
            return RedirectToAction("UserEdit");
        }
        public IActionResult Prefills()
        {
            return View();
        }

        public IActionResult ChangePassword()
        {
            return View();
        }
        public IActionResult Identities()
        {
            return View();
        }
        public IActionResult Orders()
        {
            return View();
        }
        public IActionResult JoinedOrganizations()
        {
            return View();
        }
        public IActionResult ReclaimOrders()
        {
            return View();
        }
        public IActionResult MyTicketList()
        {
            return View();
        }
        public IActionResult PastTicketList()
        {
            return View();
        }
        public IActionResult MyTickets()
        {
            return View();
        }
        //登入起點
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInInfo LogInInfo)
        {
            var dbUser = await _context.LogInInfos
                .FirstOrDefaultAsync(a => a.Account == LogInInfo.Account && a.Password == LogInInfo.Password);
            //Account與Email擇一登入還沒完成，目前只能使用Account登入

            if (dbUser != null)
            {
                // 登入成功，重定向到Privacy
                return RedirectToAction("Privacy", "Home");
            }
            else
            {
                // 登入失敗，返回錯誤信息
                //ModelState.AddModelError("", "帳號或密碼錯誤");
                return RedirectToAction("Error", "Home");
            }
        }
        //public IActionResult LogIn()
        //{
        //    return View();
        //}
        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult ForgetPassword()
        {
            return View();
        }
    }
}
