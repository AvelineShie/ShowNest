using ApplicationCore.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ShowNest.Web.Services.AccountService
{
    public class AccountService
    {
        private readonly DatabaseContext _context;
        private readonly HttpContext _httpContext;

        //設定一個帳戶異常狀態
        public class AccountException : Exception
        {
            public AccountException(string message) : base(message)
            {
            }
        }
        public AccountService(DatabaseContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContext = httpContextAccessor.HttpContext;
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
                   // new Claim(ClaimTypes.Role, role.OrganizationId.ToString())
                };
                    // 只有在角色存在時才添加角色相關的Claim
                    if (role != null)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role.OrganizationId.ToString()));
                    }
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await _httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        new AuthenticationProperties()
                        {
                            IsPersistent = true
                        });

                    return (true, null);
                }
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
