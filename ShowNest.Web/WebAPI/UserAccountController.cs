using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace ShowNest.Web.WebAPI
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly IUserAccountAPIService _userAccountAPIService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserAccountController(IUserAccountAPIService userAccountAPIService, IHttpContextAccessor httpContextAccessor)
        {
            _userAccountAPIService = userAccountAPIService;
            _httpContextAccessor = httpContextAccessor;
        }

        //[HttpGet]
        public IActionResult GetUserOrderList()
        {
            string userId = "2";
           //var userId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            return Ok(_userAccountAPIService.GetUserOrderDetailListByUserId(userId));
        }
    }
}
