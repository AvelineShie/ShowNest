﻿using Microsoft.AspNetCore.Mvc;
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
        private readonly AccountService _userService;

        public AccountController(AccountService accountService, AccountService userService)
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
                // 登入失敗，返回錯誤信息
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
        public async Task<ActionResult> SignUp(RegisterViewModel SignUp)
        {
            if (ModelState.IsValid)
            {
                // 使用UserService進行註冊
                var result = await _userService.RegisterUserAsync(SignUp, ModelState.IsValid);
                if (result.IsSuccess)
                {
                    // 註冊成功後，將用戶登入
                    var loginResult = await _accountService.LogInAsync(new LoginViewModel { Account = SignUp.Account, Password = SignUp.Password });
                    if (loginResult.IsSuccess)
                    {
                        // 登入成功後，重定向到首頁
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        // 登入失敗，返回VIEW以顯示錯誤訊息
                        ModelState.AddModelError("", loginResult.ErrorMessage);
                    }
                }
                else
                {
                    // 註冊失敗，返回VIEW以顯示錯誤訊息
                    ModelState.AddModelError("", result.ErrorMessage);
                }
            }

            //如果MODEL狀態不正確，則返回VIEW以顯示錯誤訊息
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
                    // 密碼更換成功，重定向到成功頁面或者提示用戶
                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                    TempData["Message"] = "修改成功，請重新登入";

                    return RedirectToAction("LogIn");
                }
                else
                {
                    // 密碼更換失敗，顯示錯誤訊息
                    ModelState.AddModelError(string.Empty, result.ErrorMessage);
                }
            }
            // 如果模型無效，則返回視圖以顯示錯誤訊息
            return View(model);
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
