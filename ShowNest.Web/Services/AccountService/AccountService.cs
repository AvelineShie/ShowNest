﻿using ApplicationCore.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ShowNest.Web.Services.AccountService
{
    public class AccountService
    {
        private readonly DatabaseContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        // 設定一個帳戶異常狀態
        public class AccountException : Exception
        {
            public AccountException(string message) : base(message)
            {
            }
        }

        public AccountService(DatabaseContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }


        //註冊
        public async Task<(bool IsSuccess, string ErrorMessage)> RegisterUserAsync(RegisterViewModel model, bool isValid)
        {
            if (!isValid)
            {
                return (false, "請確認輸入是否正確。");
            }

            try
            {
                var existingUser = await _context.LogInInfos
                    .FirstOrDefaultAsync(u => u.Account == model.Account || u.Email == model.Email);

                if (existingUser != null)
                {
                    return (false, "帳號或Email已存在");
                }

                var user = new User
                {
                    Birthday = model.Birthday,
                    CreatedAt = DateTime.Now,
                    Nickname = model.Account

                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                var loginInfo = new LogInInfo
                {
                    Account = model.Account,
                    Email = model.Email,
                    Password = HashPassword(model.Password),
                    UserId = user.Id,
                    CreatedAt = DateTime.Now
                };

                _context.LogInInfos.Add(loginInfo);
                await _context.SaveChangesAsync();

                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
        //登入
        public async Task<(bool IsSuccess, string ErrorMessage)> LogInAsync(LoginViewModel login)
        {
            //先檢查帳號
            var dbUser = await _context.LogInInfos
                .FirstOrDefaultAsync(a => a.Account == login.Account || a.Email == login.Account);

            if (dbUser == null)
            {
                //帳號不存在
                return (false, "帳號、Email未註冊");
            }
            else
            {
                //檢查密碼
                if (dbUser.Password != HashPassword(login.Password))
                {
                    // 如果密碼不正確，返回"帳號或密碼錯誤"的錯誤訊息
                    return (false, "帳號或密碼錯誤");
                }

                else
                {
                    //有找到帳號、且密碼正確
                    var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == dbUser.UserId);
                    var role = await _context.OrganizationAndUserMappings.FirstOrDefaultAsync(o => o.Id == user.Id);

                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Nickname),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    //new Claim(ClaimTypes.Sid, user.Id.ToString())
                   // new Claim(ClaimTypes.Role, role.OrganizationId.ToString())
                };
                    // 只有在角色存在時才添加角色相關的Claim
                    if (role != null)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role.OrganizationId.ToString()));
                    }
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        new AuthenticationProperties()
                        {
                            IsPersistent = true
                        });

                    return (true, null);
                }
            }

        }

        //修改密碼
        public async Task<(bool IsSuccess, string ErrorMessage)> ChangePassword(ChangePasswordViewModel model, bool isValid)
        {
            // VIEWMODEL已擋，不確定會不會有錯誤狀況，保險寫
            if (!isValid)
            {
                return (false, "請確認輸入是否正確。");
            }

            // 從HttpContext中獲取當前使用者的ID
            var userIdClaim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                // 如果找不到使用者ID宣告，則可能是用戶未登入
                return (false, "用戶未登入。");
            }

            // 比對舊密碼
            bool isOldPasswordCorrect = await VerifyOldPassword(userIdClaim.Value, model.Password);
            if (!isOldPasswordCorrect)
            {
                return (false, "舊密碼不正確。");
            }

            // 如果舊密碼比對成功，則進行密碼更新的操作
            var dbUser = await _context.LogInInfos.FirstOrDefaultAsync(u => u.UserId == int.Parse(userIdClaim.Value));
            if (dbUser == null)
            {
                // 如果找不到對應的使用者，則返回失敗
                return (false, "找不到對應的使用者。");
            }

            // 更新密碼
            dbUser.Password = HashPassword(model.NewPassword);
            dbUser.EditedAt = DateTime.Now; // 更新編輯時間

            await _context.SaveChangesAsync();

            return (true, null);
        }
        //比對舊密碼
        private async Task<bool> VerifyOldPassword(string userId, string oldPassword)
        {
            // 從HttpContext中獲取當前使用者的ID
            var userIdClaim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                // 如果找不到使用者ID宣告，則可能是用戶未登入
                return false;
            }

            // 使用獲取到的使用者ID來查詢資料庫
            var dbUser = await _context.LogInInfos.FirstOrDefaultAsync(u => u.UserId == int.Parse(userIdClaim.Value));
            if (dbUser == null)
            {
                // 如果找不到對應的使用者，則返回失敗
                return false;
            }

            // 假設您的資料庫中存儲的密碼雜湊欄位名稱為PasswordHash
            string storedHash = dbUser.Password;
            string hashedOldPassword = HashPassword(oldPassword); // 假設您有一個HashPassword方法來進行密碼雜湊

            // 比對雜湊後的舊密碼與資料庫中的密碼雜湊
            return storedHash == hashedOldPassword;
        }

        //取得使用者資料
        public async Task<(bool IsSuccess, UserAccountViewModel UserAccount, string ErrorMessage)> GetUserAccountByIdAsync(int userId)
        {
            try
            {
                var user = await _context.Users
                    .Include(u => u.LogInInfo)
                    .Include(u => u.PreferredActivityAreas)
                    .ThenInclude(p => p.Area)
                    .FirstOrDefaultAsync(u => u.Id == userId);

                if (user == null)
                {
                    return (false, null, "找不到對應的使用者。");
                }
                // 檢查PreferredActivityAreas是否為null
                if (user.PreferredActivityAreas == null)
                {
                    // 如果PreferredActivityAreas為null，則返回一個空列表
                    var selectedAreas = new List<string>();
                }
                else
                {
                    // 嘗試訪問Area屬性
                    var selectedAreas = user.PreferredActivityAreas.Select(p => p.Area.Name).ToList();
                }
                var userAccountViewModel = new UserAccountViewModel
                {
                    Id = user.Id,
                    Account = user.LogInInfo.Account,
                    Nickname = user.Nickname,
                    Email = user.LogInInfo.Email,
                    Mobile = user.Mobile,
                    Birthday = user.Birthday,
                    Gender = user.Gender,
                    PersonalURL = user.PersonalUrl,
                    PersonalProfile = user.PersonalProfile,
                    EdmSubscription = user.EdmSubscription,
                    Image = user.Image,
                    //LastLogInAt = user.LogInInfo.LastLogInAt,
                    Status = user.Status,
                    CreatedAt = user.CreatedAt,
                    EditedAt = user.EditedAt,
                    SelectedAreas = user.PreferredActivityAreas.Select(p => p.AreaId).ToList()

                };

                return (true, userAccountViewModel, null);
            }
            catch (Exception ex)
            {
                return (false, null, ex.Message);
            }
        }
        //更新使用者資料
        public async Task<(bool IsSuccess, string ErrorMessage)> UpdateUserAccountByIdAsync(int userId, UserAccountViewModel model)
        {
            try
            {
                var user = await _context.Users
                    .Include(u => u.LogInInfo)
                    .FirstOrDefaultAsync(u => u.Id == userId);

                if (user == null)
                {
                    return (false, "找不到對應的使用者。");
                }

                // 更新使用者資料
                user.Nickname = model.Nickname;
                user.LogInInfo.Email = model.Email;
                user.Mobile = model.Mobile;
                user.Birthday = model.Birthday;
                user.Gender = (byte?)model.Gender;
                user.PersonalUrl = model.PersonalURL;
                user.PersonalProfile = model.PersonalProfile;
                user.EdmSubscription = model.EdmSubscription;
                user.Image = model.Image; 
                user.EditedAt = DateTime.Now;

                await _context.SaveChangesAsync();

                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
