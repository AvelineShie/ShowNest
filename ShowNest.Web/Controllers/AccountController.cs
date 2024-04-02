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

namespace ShowNest.Web.Controllers
{
    public class AccountController : Controller
    {
        //登入
        private readonly AccountService _accountService;
        //註冊
        private readonly UserService _userService;

        public AccountController(AccountService accountService, UserService userService)
        {
            _accountService = accountService;
            _userService = userService;
        }
        //登入
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LoginViewModel Login)
        {
            var result = await _accountService.LogInAsync(Login);
            if (result.IsSuccess)
            {
                //登入成功，導向頁面
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // 登入失敗，返回錯誤信息 (待修)
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
        public async Task<ActionResult> SignUp(RegisterModel SignUp)
        {
            if (ModelState.IsValid)
            {
                // 使用UserService進行註冊
                bool isRegistered = await _userService.RegisterUserAsync(SignUp, ModelState.IsValid);
                if (isRegistered)
                {
                    // 註冊成功後，重定向到登入後頁面(待修)
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    // 註冊失敗，返回VIEW以顯示錯誤訊息
                    // 要加一個錯誤訊息到
                    ModelState.AddModelError("", "註冊失敗，請稍後再試。");
                }
            }

            //如果模型狀態不正確，則返回視圖以顯示錯誤訊息
            return View(SignUp);
        }
        public IActionResult UserEdit()
        {
            return View();
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

        //登出
        public async Task<IActionResult> logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
            
        }
 

        public IActionResult ForgetPassword()
        {
            return View();
        }
    }
}
