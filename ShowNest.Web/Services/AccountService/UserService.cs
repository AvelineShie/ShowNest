using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ShowNest.Web.Services.AccountService
{
    public class UserService
    {
        private readonly DatabaseContext _context;
        public UserService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> RegisterUserAsync(RegisterModel model, bool isValid)
        {
            // 驗證檢核模型
            if (!isValid)
            {
                return false;
            }

            // 檢查資料庫中是否已經存在相同的帳號或電子郵件
            var existingUser = await _context.LogInInfos
                .FirstOrDefaultAsync(u => u.Account == model.Account || u.Email == model.Email);

            if (existingUser != null)
            {
                //要寫提示錯誤
                // 如果找到匹配的帳號或電子郵件，則返回失敗
                return false;
            }

            // 創建新的使用者實例
            var user = new User
            {
                Birthday = model.Birthday,
                CreatedAt = DateTime.Now
            };

            // 將新的使用者儲存到資料庫中
            _context.Users.Add(user);
            await _context.SaveChangesAsync(); // 這裡需要先儲存 User 以獲得 ID

            // 創建新的登入資訊實例
            var loginInfo = new LogInInfo
            {
                Account = model.Account,
                Email = model.Email,
                Password = HashPassword(model.Password),
                UserId = user.Id, // 使用 User 的 ID
                CreatedAt = DateTime.Now
            };

            // 將新的登入資訊儲存到資料庫中
            _context.LogInInfos.Add(loginInfo);
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }

        // 密碼雜湊
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
