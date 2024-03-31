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

namespace ShowNest.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }


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
                // 登入失敗，返回錯誤信息
                ModelState.AddModelError("", result.ErrorMessage);
                return View(Login);
            }

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
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SignUp(RegisterModel model)
        {
            //if (ModelState.IsValid)
            //{
            //    var userName = new ApplicationUser { UserName = model.Email, Email = model.Email };
            //    var email = new
            //    var result = await UserManager.CreateAsync(user, model.Password);
            //    if (result.Succeeded)
            //    {
            //        // 進行註冊成功後的邏輯，例如：發送確認郵件
            //        return RedirectToAction("Index", "Home");
            //    }
            //    AddErrors(result);
            //}

            //如果模型狀態不正確，則返回視圖以顯示錯誤訊息
            return View(model);
        }

        public IActionResult ForgetPassword()
        {
            return View();
        }
    }
}
