using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace ShowNest.Web.WebAPI
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly UserAccountAPIService _userAccountAPIService;

        public UserAccountController(UserAccountAPIService userAccountAPIService)
        {
            _userAccountAPIService = userAccountAPIService;
        }

        //[HttpGet]
        public IActionResult GetUserOrderList()
        {
            string userId = "2";
           // var userId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            return Ok(_userAccountAPIService.GetUserOrderDetailListByUserId(userId));
        }
    }
}
