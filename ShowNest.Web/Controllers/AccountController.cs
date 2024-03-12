using Microsoft.AspNetCore.Mvc;

namespace ShowNest.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }
        public IActionResult UserEdit()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = "1561972534652114", //your_app_id
                redirect_uri = "https://localhost:7156/Home/FacebookRedirect", //your_redirect_uri
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
                client_id = "1561972534652114", //your_app_id
                client_secret = "a1c6c2dfc077891ed4c1ef27bc9f8079",
                redirect_uri = "https://localhost:7156/Home/FacebookRedirect", //your_redirect_uri
                code = code

            });

            fb.AccessToken = result.access_token;

            dynamic me = fb.Get("/me?fields=name,email");
            string name = me.name;
            string email = me.email;
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
