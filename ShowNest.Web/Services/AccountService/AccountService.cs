using ApplicationCore.Entities;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ShowNest.Web.Configurations;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Web;


namespace ShowNest.Web.Services.AccountService
{
    public class AccountService
    {
        private readonly DatabaseContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly HttpClient _httpClient;
        private readonly FacebookSettings _facebookSettings;
        private readonly ITempDataDictionary _tempData;
        // 設定一個帳戶異常狀態
        public class AccountException : Exception
        {
            public AccountException(string message) : base(message)
            {
            }
        }

        public AccountService(DatabaseContext context, IHttpContextAccessor httpContextAccessor, HttpClient httpClient, IOptions<FacebookSettings> facebookSettings) { 
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _httpClient = httpClient;
            _facebookSettings = facebookSettings.Value;

        }
        //註冊
        public async Task<(bool IsSuccess, string ErrorMessage)> RegisterUserAsync(RegisterViewModel model, bool isValid, bool isGoogleLogin = false)
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

                // Google 登入路線
                if (!isGoogleLogin)
                {
                    if (string.IsNullOrEmpty(model.Password) || string.IsNullOrEmpty(model.ConfirmPassword))
                    {
                        return (false, "密碼和確認密碼不能為空。");
                    }

                    if (model.Password != model.ConfirmPassword)
                    {
                        return (false, "密碼和確認密碼不匹配。");
                    }
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
                    ImageUrl = user.Image,
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
                    .Include(u => u.PreferredActivityAreas)
                    .FirstOrDefaultAsync(u => u.Id == userId);
                if (user == null)
                {
                    return (false, "找不到對應的使用者。");
                }

                // 檢查Account是否需要更新
                if (user.LogInInfo.Account != model.Account)
                {
                    // 檢查新的Account是否重複
                    var existingAccountUser = await _context.LogInInfos
                        .FirstOrDefaultAsync(u => u.Account == model.Account && u.UserId != user.Id);
                    if (existingAccountUser != null)
                    {
                        return (false, "帳號已存在");
                    }
                    // 如果新的Account與原本的不同且不存在重複，則更新
                    user.LogInInfo.Account = model.Account;
                }
                // 檢查Email是否需要更新
                if (user.LogInInfo.Email != model.Email)
                {
                    // 檢查新的Email是否重複
                    var existingEmailUser = await _context.LogInInfos
                        .FirstOrDefaultAsync(u => u.Email == model.Email && u.UserId != user.Id);

                    if (existingEmailUser != null)
                    {
                        return (false, "Email已存在");
                    }
                    // 如果新的Email與原本的不同且不存在重複，則更新
                    user.LogInInfo.Email = model.Email;
                }

                // 更新使用者資料
                user.Nickname = model.Nickname;
                user.Mobile = model.Mobile;
                user.Birthday = model.Birthday;
                user.Gender = (byte?)model.Gender;
                user.PersonalUrl = model.PersonalURL;
                user.PersonalProfile = model.PersonalProfile;
                user.EdmSubscription = model.EdmSubscription;
                user.Image = model.ImageUrl;
                user.EditedAt = DateTime.Now;
                user.LogInInfo.EditedAt = DateTime.Now;

                // 確保不會NULL
                model.SelectedAreas = model.SelectedAreas ?? new List<int>();
                // 將現有的偏好設定轉換成一個集合，以便於查詢
                var existingAreaIds = user.PreferredActivityAreas.Select(p => p.AreaId).ToList();

                // 根據選擇的區域更新偏好設定
                foreach (var areaId in model.SelectedAreas)
                {
                    // 如果區域已經被選中，則跳過
                    if (existingAreaIds.Contains(areaId))
                    {
                        existingAreaIds.Remove(areaId); // 從現有的區域ID列表中移除，以便後續處理
                        continue;
                    }

                    var area = await _context.Areas.FindAsync(areaId);
                    if (area != null)
                    {
                        user.PreferredActivityAreas.Add(new PreferredActivityArea
                        {
                            UserId = user.Id,
                            AreaId = area.Id
                        });
                    }
                }
                // 從資料庫中刪除已取消選擇的區域的偏好設定
                var areasToRemove = user.PreferredActivityAreas.Where(p => existingAreaIds.Contains(p.AreaId)).ToList();
                _context.PreferredActivityAreas.RemoveRange(areasToRemove);

                // 更新LoginInfo的EditedAt欄位
                user.LogInInfo.EditedAt = DateTime.Now;

                await _context.SaveChangesAsync();

                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
        //雜湊
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

        //Google登入
        public string ValidGoogleLogin(string? formCredential, string? formToken, string? cookiesToken)
        {
            // 驗證 Google Token
            GoogleJsonWebSignature.Payload? payload = VerifyGoogleToken(formCredential, formToken, cookiesToken).Result;
            if (payload == null)
            {
                // 驗證失敗
                return "驗證 Google 授權失敗";
            }
            else
            {
                //驗證成功，取使用者資訊內容
                return "驗證 Google 授權成功" + "<br>" +
                       "GId:" + payload.Subject + "<br>" +
                       "Email:" + payload.Email + "<br>" +
                       "Name:" + payload.Name + "<br>" +
                       "Picture:" + payload.Picture;
            }
        }

        // GOOGLE檢查Token
        public async Task<GoogleJsonWebSignature.Payload?> VerifyGoogleToken(string? formCredential, string? formToken, string? cookiesToken)
        {
            // 檢查空值
            if (formCredential == null || formToken == null && cookiesToken == null)
            {
                return null;
            }

            GoogleJsonWebSignature.Payload? payload;
            try
            {
                // 驗證 token
                if (formToken != cookiesToken)
                {
                    return null;
                }

                // 驗證憑證
                IConfiguration Config = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();
                string GoogleApiClientId = Config.GetSection("GoogleApiClientId").Value;
                var settings = new GoogleJsonWebSignature.ValidationSettings()
                {
                    Audience = new List<string>() { GoogleApiClientId }
                };
                payload = await GoogleJsonWebSignature.ValidateAsync(formCredential, settings);
                if (!payload.Issuer.Equals("accounts.google.com") && !payload.Issuer.Equals("https://accounts.google.com"))
                {
                    return null;
                }
                if (payload.ExpirationTimeSeconds == null)
                {
                    return null;
                }
                else
                {
                    DateTime now = DateTime.Now.ToUniversalTime();
                    DateTime expiration = DateTimeOffset.FromUnixTimeSeconds((long)payload.ExpirationTimeSeconds).DateTime;
                    if (now > expiration)
                    {
                        return null;
                    }
                }
            }
            catch
            {
                return null;
            }
            return payload;
        }

        // Google 登入或註冊
        public async Task<(bool IsSuccess, string RedirectUrl, string ErrorMessage)> RegisterOrLoginWithGoogle(string? formCredential, string? formToken, string? cookiesToken, string eventId = null)
        {
            try
            {
                var payload = await VerifyGoogleToken(formCredential, formToken, cookiesToken);
                if (payload == null)
                {
                    return (false, null, "驗證 Google 授權失敗");
                }
                var email = payload.Email;
                var name = payload.Name;
                var openId = payload.Subject;
                var pictureUrl = payload.Picture;
                // 檢查用戶是否已經存在
                var existingUser = _context.LogInInfos.FirstOrDefault(u => u.Email == email || u.GId == openId);
                if (existingUser == null)
                {
                    // 用戶不存在，進行註冊
                    var newUser = new User
                    {
                        Nickname = name,
                        Image = pictureUrl,
                        CreatedAt = DateTime.Now
                    };
                    _context.Users.Add(newUser);
                    await _context.SaveChangesAsync(); // 先儲存 User 記錄
                    // 生成一個隨機密碼並儲存到變數中
                    var randomPassword = GenerateRandomPassword();
                    // 將隨機密碼儲存到 Session 中
                    _httpContextAccessor.HttpContext.Session.SetString("TempPassword", randomPassword);
                    _httpContextAccessor.HttpContext.Session.SetString("IsGoogleRegister", "true");
                    // 創建一個 LogInInfo 實例，並將 GId 設置為 Google 登入後獲得的 GId
                    var newLoginInfo = new LogInInfo
                    {
                        Account = name,
                        Email = email,
                        Password = HashPassword(randomPassword), // 使用變數中的隨機密碼
                        UserId = newUser.Id, // 使用新創建的 User 記錄的 Id
                        GId = openId, // 將 GId 寫入到 LogInInfo.GId 中
                        CreatedAt = DateTime.Now
                    };
                    _context.LogInInfos.Add(newLoginInfo);
                    await _context.SaveChangesAsync(); // 再儲存 LogInInfo 記錄
                    // 創建一個 ClaimsIdentity 實例，並將使用者的資訊添加到它的 Claims 集合中
                    var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, newUser.Nickname),
                new Claim(ClaimTypes.NameIdentifier, newUser.Id.ToString())
            };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    // 使用 SignInAsync 方法將使用者登入到應用程式中
                    await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        new AuthenticationProperties()
                        {
                            IsPersistent = true
                        });
                    // 返回重定向到修改密碼頁面的結果
                    return (true, "/Account/ChangePassword", null);
                }
                else
                {
                    // 用戶已經存在，直接將用戶登入
                    var user = _context.Users.FirstOrDefault(u => u.Id == existingUser.UserId);
                    if (user != null)
                    {
                        var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Nickname),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                };
                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                        await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(claimsIdentity),
                            new AuthenticationProperties()
                            {
                                IsPersistent = true
                            });

                        // 返回重定向到主頁面的結果
                        return (true, $"/Events/EventPage?eventId={eventId}", null);
                    }
                    else
                    {
                        // 如果找不到用戶，則返回一個錯誤訊息
                        return (false, null, "用戶不存在");
                    }
                }
            }
            catch (Exception ex)
            {
                // 在這裡處理異常，例如記錄錯誤訊息或返回一個錯誤訊息
                return (false, null, $"註冊失敗: {ex.Message}");
            }
        }
        // 產生亂碼當作密碼
        public string GenerateRandomPassword(int length = 8)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] uintBuffer = new byte[4];
                while (length-- > 0)
                {
                    rng.GetBytes(uintBuffer);
                    uint num = BitConverter.ToUInt32(uintBuffer, 0);
                    res.Append(valid[(int)(num % valid.Length)]);
                }
            }
            return res.ToString();
        }


        ////FB登入功能
        //public async Task<(bool IsSuccess, string ErrorMessage)> HandleFacebookLoginAsync(string code, string state)
        //{
        //    // 從session中檢索原始的狀態參數
        //    var originalState = _httpContextAccessor.HttpContext.Session.GetString("FacebookState");

        //    // 驗證狀態參數
        //    if (originalState != state)
        //    {
        //        return (false, "OAuth state was missing or invalid.");
        //    }
        //    try
        //    {
        //        // 獲取 access token
        //        var accessToken = await GetAccessTokenAsync(code);
        //        // 獲取用戶資訊
        //        var userInfo = await GetUserInfoAsync(accessToken);
        //        // 處理 Facebook 登入
        //        var result = await ProcessFacebookLogin(userInfo.ToString());

        //        return (result.Item1, result.Item2);
        //    }
        //    catch (Exception ex)
        //    {
        //        return (false, ex.Message);
        //    }
        //}
        //public async Task<Tuple<bool, string>> ProcessFacebookLogin(string userInfo)
        //{
        //    var userAccount = JsonConvert.DeserializeObject<FBUserViewModel>(userInfo);
        //    // 檢查資料庫中是否已經有該Facebook用戶的資料
        //    var existingUser = await _context.Fblogininfos
        //        .FirstOrDefaultAsync(u => u.FacebookId == userAccount.FacebookId);

        //    if (existingUser != null)
        //    {
        //        // 如果已經有，則進行登入處理
        //        // 這裡假設你已經有一個方法來進行登入處理，例如LogInAsync(userAccount)
        //        // 首先，我們需要從Users資料表中找到相關的LogInInfo資料
        //        var user = await _context.Users
        //            .Include(u => u.LogInInfo) // 加載與User相關聯的LogInInfo
        //            .FirstOrDefaultAsync(u => u.Id == existingUser.Id);

        //        if (user != null && user.LogInInfo != null)
        //        {
        //            var loginResult = await LogInAsync(new LoginViewModel { Account = userAccount.Email, Password = user.LogInInfo.Password });
        //            return new Tuple<bool, string>(loginResult.IsSuccess, string.Empty); // 登入成功，錯誤訊息為空
        //        }
        //    }
        //    //else
        //    //FB路不通，暫停
        //    return new Tuple<bool, string>(false, "未知錯誤"); // 登入失敗，返回錯誤訊息
        //    //    }
        //    //}
        //}
        ////拿TOKEN
        //public async Task<string> GetAccessTokenAsync(string code)
        //{
        //    var appId = _facebookSettings.ClientId;
        //    var appSecret = _facebookSettings.ClientSecret;
        //    var redirectUri = _facebookSettings.CallbackPath;

        //    var tokenEndpoint = $"https://graph.facebook.com/v13.0/oauth/access_token?client_id={appId}&redirect_uri={HttpUtility.UrlEncode(redirectUri)}&client_secret={appSecret}&code={code}";

        //    var response = await _httpClient.GetAsync(tokenEndpoint);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var content = await response.Content.ReadAsStringAsync();
        //        var tokenResponse = JsonConvert.DeserializeObject<dynamic>(content);
        //        return tokenResponse.access_token;
        //    }
        //    else
        //    {
        //        throw new Exception("無法獲取access token");
        //    }
        //}
        ////換資料
        //public async Task<dynamic> GetUserInfoAsync(string accessToken)
        //{
        //    var userInfoEndpoint = $"https://graph.facebook.com/v13.0/me?fields=id,name,email&access_token={accessToken}";

        //    var response = await _httpClient.GetAsync(userInfoEndpoint);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var content = await response.Content.ReadAsStringAsync();
        //        var userInfo = JsonConvert.DeserializeObject<dynamic>(content);
        //        return userInfo;
        //    }
        //    else
        //    {
        //        throw new Exception("無法獲取用戶資訊");
        //    }
        //}
        ////解決OAuth state問題
        //public void FacebookLogin()
        //{
        //    var state = GenerateRandomString(); // 實現這個方法來生成隨機字串
        //     _httpContextAccessor.HttpContext.Session.SetString("FacebookState", state); // 將state值存儲在session中

        //    var redirectUrl = $"https://www.facebook.com/v13.0/dialog/oauth?client_id={_facebookSettings.ClientId}&redirect_uri={HttpUtility.UrlEncode(_facebookSettings.CallbackPath)}&scope=email&state={state}";
        //    _httpContextAccessor.HttpContext.Response.Redirect(redirectUrl);
        //}
        ////產生亂數字串提供給認證亂碼用
        //private string GenerateRandomString(int length = 32)
        //{
        //    const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        //    StringBuilder res = new StringBuilder();
        //    using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
        //    {
        //        byte[] uintBuffer = new byte[4];
        //        while (length-- > 0)
        //        {
        //            rng.GetBytes(uintBuffer);
        //            uint num = BitConverter.ToUInt32(uintBuffer, 0);
        //            res.Append(valid[(int)(num % valid.Length)]);
        //        }
        //    }
        //    return res.ToString();
        //}

    }
}
