using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ShowNest.Web.Controllers
{
    public class AccountController : Controller
    {
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
            string UserDataJson =JsonConvert.SerializeObject(userData,Formatting.Indented);
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
        public IActionResult LogIn()
        {
            return View();
        }
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
