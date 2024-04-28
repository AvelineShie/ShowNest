using Microsoft.AspNetCore.Mvc;
using Infrastructure.Data;
using Newtonsoft.Json;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.CodeAnalysis.Elfie.Extensions;
using static System.Runtime.InteropServices.JavaScript.JSType;
using ShowNest.Web.Services.AccountService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Google.Apis.Auth;
using Microsoft.Extensions.Logging;

namespace ShowNest.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountService _accountService;
        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }
        //登入
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LoginViewModel Login, string eventId = null)
        {
            var result = await _accountService.LogInAsync(Login);
            if (result.IsSuccess)
            {
                if (!string.IsNullOrEmpty(eventId))
                {
                    return RedirectToAction("EventPage", "Events", new { eventId = eventId });
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", result.ErrorMessage);
                return View(Login);
            }
        }
        //註冊
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SignUp(RegisterViewModel SignUp, string eventId = null)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.RegisterUserAsync(SignUp, ModelState.IsValid);
                if (result.IsSuccess)
                {
                    var loginResult = await _accountService.LogInAsync(new LoginViewModel { Account = SignUp.Account, Password = SignUp.Password });
                    if (loginResult.IsSuccess)
                    {
                        if (!string.IsNullOrEmpty(eventId))
                        {
                            return RedirectToAction("EventPage", "Events", new { eventId = eventId });
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", loginResult.ErrorMessage);
                    }
                }
                else
                {
                    ModelState.AddModelError("", result.ErrorMessage);
                }
            }
            return View(SignUp);
        }
        //編輯取得資料
        [HttpGet]
        public async Task<IActionResult> UserEdit()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return RedirectToAction("LogIn");
            }
            var userId = int.Parse(userIdClaim.Value);

            var result = await _accountService.GetUserAccountByIdAsync(userId);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, result.ErrorMessage);
                return View();
            }
            var viewModel = result.UserAccount;
            return View(viewModel);
        }
        //編輯寫入資料
        [HttpPost]
        public async Task<IActionResult> UserEdit(UserAccountViewModel model)
        {
            var selectedAreaIdsString = Request.Form["SelectedAreaIds"].ToString();
            var selectedAreaIds = string.IsNullOrEmpty(selectedAreaIdsString)
                ? new List<int>()
                : selectedAreaIdsString.Split(',').Select(int.Parse).ToList();
            model.SelectedAreas = selectedAreaIds;
            if (ModelState.IsValid)
            {
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                if (userIdClaim == null)
                {
                    return RedirectToAction("LogIn");
                }
                var userId = int.Parse(userIdClaim.Value);
                var result = await _accountService.UpdateUserAccountByIdAsync(userId, model);
                if (result.IsSuccess)
                {
                    TempData["SuccessMessage"] = "您的資料已成功更新。";
                    return RedirectToAction("UserEdit");
                }
                else
                {
                    if (result.ErrorMessage.Contains("帳號已存在"))
                    {
                        ModelState.AddModelError("Account", "帳號已存在");
                    }
                    else if (result.ErrorMessage.Contains("Email已存在"))
                    {
                        ModelState.AddModelError("Email", "Email已存在");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, result.ErrorMessage);
                    }
                }
            }
            return View(model);
        }
        //修改密碼
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.ChangePassword(model, true);
                if (result.IsSuccess)
                {
                    //修改成功刪除Session資料
                    HttpContext.Session.Remove("TempPassword");
                    HttpContext.Session.Remove("IsGoogleRegister");

                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                    TempData["Message"] = "修改成功，請重新登入";
                    return RedirectToAction("LogIn");
                }
                else
                {
                    // 如果 ModelState 無效，則將錯誤訊息存儲到 TempData 中
                    TempData["ErrorMessage"] = "請確認輸入是否正確。";
                }
            }
            return View(model);
        }
        //登出
        public async Task<IActionResult> logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
        //GOOGLE進入點
        //GOOGLE登入或註冊
        public async Task<IActionResult> GoogleRegisterOrLogin(string eventId = null)
        {
            string? formCredential = Request.Form["credential"];
            string? formToken = Request.Form["g_csrf_token"];
            string? cookiesToken = Request.Cookies["g_csrf_token"];

            // 如果eventId是null字符，將其設置為null，不然第三方登入會一直錯誤
            if (eventId == "null")
            {
                eventId = null;
            }
            var result = await _accountService.RegisterOrLoginWithGoogle(formCredential, formToken, cookiesToken, eventId);
            if (result.IsSuccess)
            {
                // 直接根據eventId是否存在來決定重定向的目標
                if (eventId == null)
                {
                    // 如果eventId不存在，則重定向到首頁
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // 如果eventId存在，則重定向到指定的活動頁面
                    return RedirectToAction("EventPage", "Events", new { eventId = eventId });
                }
            }
            else
            {
                ModelState.AddModelError("", result.ErrorMessage);
                return View("Error"); // 假設你有一個名為"Error"的視圖來顯示錯誤訊息
            }
        }
        //Google抓活動
        public IActionResult GenerateGoogleOneTapLoginUri(string eventId)
        {
            if (string.IsNullOrEmpty(eventId))
            {
                // 如果eventId為空或空字符串，將用戶重定向到首頁
                return RedirectToAction("Index", "Home");
            }
            //未佈署版本
            //var baseUri = "https://localhost:7156/Account/GoogleRegisterOrLogin";
            //佈署修正
            var baseUri = "https://shownestci.azurewebsites.net/Account/GoogleRegisterOrLogin";
            var loginUri = $"{baseUri}?eventId={eventId}";
            return Json(new { loginUri = loginUri });
        }
        
        
        
        
        
        //忘記密碼
        public IActionResult ForgetPassword()
        {
            return View();
        }
        public IActionResult Prefills()
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
    }
}
