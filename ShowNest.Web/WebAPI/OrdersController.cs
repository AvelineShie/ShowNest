using Microsoft.AspNetCore.Mvc;
using ShowNest.Web.ViewModels.Orders;
using System.Security.Claims;
using static Infrastructure.Services.OrderAPIService;


namespace ShowNest.Web.WebAPI
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderQueryService _orderAPIService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly OrderTicketService _orderTicketService;

        public OrdersController(IOrderQueryService orderAPIService, IHttpContextAccessor httpContextAccessor,
            OrderTicketService orderTicketService)
        {
            _orderAPIService = orderAPIService;
            _httpContextAccessor = httpContextAccessor;
            _orderTicketService = orderTicketService;
        }

        [HttpGet]
        public IActionResult GetOrderDetail(int orderId)
        {
            //string userId = "2";
            var userId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            return Ok(_orderAPIService.GetOrderDetailByOrderId(userId, orderId));
        }

        //[HttpPost]
        //public async Task<IActionResult> UpdateOrderDetail (int orderId, string contactPersonJson)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var order = await _orderTicketService.UpdateOrderDetailContactInfoByOrderId(contactPersonJson,orderId);
        //    if (order is null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(order);
        //}
        [HttpPost]
        public async Task<IActionResult> UpdateOrderDetail(OrderContactPerson param)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            
            try
            {
				int orderId = param.OrderID;
				string contactPersonJson = param.ContactPersonJson;
				var order = await _orderTicketService.UpdateOrderDetailContactInfoByOrderId(contactPersonJson, orderId);

				return Ok(order);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> CreateOrder(CreateOrderRequest request)
        {
            var userIdString = _httpContextAccessor.HttpContext.User.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var userId = Convert.ToInt32(userIdString);

            var response = await _orderTicketService.CreateOrder(userId, request);
            
            return Ok(response);
        }
    }
}