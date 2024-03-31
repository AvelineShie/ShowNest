using Microsoft.AspNetCore.Mvc;
using Infrastructure.Data;
using Newtonsoft.Json;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.CodeAnalysis.Elfie.Extensions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ShowNest.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly DatabaseContext _context;
        public AccountController(DatabaseContext context)
        {
            _context = context;
            //_context.Database.EnsureCreated();
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
        ////登入起點
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LoginViewModel Login)
        {
            var dbUser = await _context.LogInInfos.
                FirstOrDefaultAsync(a => a.Account == Login.Account && a.Password == Login.Password);

            if (dbUser != null)
            {
                var claims = new List<Claim>
                {
                    //new Claim(ClaimTypes.Name,"Dato"),
                    //new Claim(ClaimTypes.Role,"Admin")
                    new Claim("UserId",dbUser.UserId.ToString())
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    new AuthenticationProperties()
                    {
                        //是否儲存為持續性的cookie(記住我?[V])
                        IsPersistent = true
                    }
                   );
                //var passwordToSHA256 = Login.Password.ToSHA256();
                //資料庫存入尚未加密，之後增加
                //Account與Email擇一登入還沒完成，目前只能使用Account登入

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
        //登出
        public async Task<IActionResult> logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Privacy", "Home");
            //頁面還沒好
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
