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
        public async Task<IActionResult> LogIn(LoginViewModel Login, string eventId = null)
        {
            var result = await _accountService.LogInAsync(Login);
            if (result.IsSuccess)
            {
                // 登入成功，檢查是否有eventId參數
                if (!string.IsNullOrEmpty(eventId))
                {
                    // 如果有eventId參數，則重定向到原本的活動頁
                    return RedirectToAction("EventPage", "Events", new { eventId = eventId });
                }
                else
                {
                    // 否則，重定向到預設的頁面
                    return RedirectToAction("Index", "Home");
                }
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
        public async Task<ActionResult> SignUp(RegisterViewModel SignUp, string eventId = null)
        {
            if (ModelState.IsValid)
            {
                // 使用AccountService進行註冊
                var result = await _userService.RegisterUserAsync(SignUp, ModelState.IsValid);
                if (result.IsSuccess)
                {
                    // 註冊成功後，將用戶登入
                    var loginResult = await _accountService.LogInAsync(new LoginViewModel { Account = SignUp.Account, Password = SignUp.Password });
                    if (loginResult.IsSuccess)
                    {
                        // 登入成功後，檢查是否有eventId參數
                        if (!string.IsNullOrEmpty(eventId))
                        {
                            // 如果有eventId參數，則重定向到原本的活動頁
                            return RedirectToAction("EventPage", "Events", new { eventId = eventId });
                        }
                        else
                        {
                            // 否則，重定向到預設的頁面
                            return RedirectToAction("Index", "Home");
                        }
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
        //編輯取得資料
        [HttpGet]
        public async Task<IActionResult> UserEdit()
        {
            // 從HttpContext中獲取當前使用者的ID
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return RedirectToAction("LogIn"); // 如果用戶未登入，則重定向到登入頁面
            }

            // 從Claim中取得使用者的ID並轉換為整數
            var userId = int.Parse(userIdClaim.Value);

            // 使用Service來取得使用者資料
            var result = await _accountService.GetUserAccountByIdAsync(userId);
            if (!result.IsSuccess)
            {
                // 如果資料庫操作失敗，顯示錯誤訊息
                ModelState.AddModelError(string.Empty, result.ErrorMessage);
                return View();
            }

            // 從Service的結果中獲取UserAccountViewModel實例
            var viewModel = result.UserAccount;

            return View(viewModel); // 將ViewModel傳遞給View
        }
        //編輯寫入資料
        [HttpPost]
        public async Task<IActionResult> UserEdit(UserAccountViewModel model)
        {
            // 從表單提交的資料中提取出所有選中的區域ID
            var selectedAreaIdsString = Request.Form["SelectedAreaIds"].ToString();
            var selectedAreaIds = string.IsNullOrEmpty(selectedAreaIdsString)
                ? new List<int>()
                : selectedAreaIdsString.Split(',').Select(int.Parse).ToList();

            // 將selectedAreaIds賦值給model的SelectedAreas屬性
            model.SelectedAreas = selectedAreaIds;

            if (ModelState.IsValid)
            {
                // 從HttpContext中獲取當前使用者的ID
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

                if (userIdClaim == null)
                {
                    return RedirectToAction("LogIn"); // 如果用戶未登入，則重定向到登入頁面
                }

                // 從Claim中取得使用者的ID並轉換為整數
                var userId = int.Parse(userIdClaim.Value);

                // 使用Service來更新使用者資料，包含偏好設定
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

        //登出
        public async Task<IActionResult> logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");

        }

        //忘記密碼
        public IActionResult ForgetPassword()
        {
            return View();
        }
    }
}
