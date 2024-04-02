using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShowNest.Web.Services.AccountService
{
    public class AccountService
    {
        private readonly DatabaseContext _context;
        private readonly HttpContext _httpContext;

        public AccountService(DatabaseContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContext = httpContextAccessor.HttpContext;
        }

        // 登入方法
        public async Task<(bool IsSuccess, string ErrorMessage)> LogInAsync(LoginViewModel login)
        {
            var dbUser = await _context.LogInInfos
                .FirstOrDefaultAsync(a => (a.Account == login.Account || a.Email == login.Account) && a.Password == login.Password);

            if (dbUser != null)
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == dbUser.UserId);
                var role = await _context.OrganizationAndUserMappings.FirstOrDefaultAsync(o => o.Id == user.Id);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Nickname),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, role.OrganizationId.ToString())
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await _httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    new AuthenticationProperties()
                    {
                        IsPersistent = true
                    });

                return (true, null);
            }
            else
            {
                return (false, "帳號或密碼錯誤");
            }
        }
    }
}
